
using Car_Pool.Models;
using Car_Pool.Models.Bookings;
using Car_Pool.Models.Offers;
using Car_Pool.Services.Contracts;
using Car_Pool.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Pool.Models.User;

namespace Car_Pool.Services
{
    public class CarRides : ICarRides
    {
        private readonly DBContext _context;
        public CarRides(DBContext context) 
        {
            _context = context;
        }
        public List<AvailableRides> GetAvailableRides(RideRequest rideRequest)
        {
            IQueryable<AvailableRides> availableRides = _context.AvailableRides
                .Where(x =>
                    (x.Source == rideRequest.Source && _context.Stops.Any(y => y.OfferId == x.OfferId && y.StopName == rideRequest.Source)) &&
                    (x.Destination == rideRequest.Destination && _context.Stops.Any(y => y.OfferId == x.OfferId && y.StopName == rideRequest.Destination)) &&
                    x.RideDate == rideRequest.RideDate && 
                    x.RideTime == rideRequest.RideTime && 
                    x.Seats_Available > 0 && 
                    !x.Booking_Status);
            
            return availableRides.ToList();
        }
        public BookingStatus BookRide(int OfferId)
        {
            BookingStatus bookingStatus = new BookingStatus();
            var availableRides = _context.AvailableRides.Where(x => x.OfferId == OfferId).FirstOrDefault();
            if (availableRides.Seats_Available > 0)
            {
                availableRides.Seats_Available = availableRides.Seats_Available - 1;
                if (availableRides.Seats_Available == 0)
                {
                    availableRides.Booking_Status = true;
                }
                _context.Bookings.Add(new Bookings
                {
                    UserId = availableRides.UserId,
                    OfferId = availableRides.OfferId,
                    Source = availableRides.Source,
                    Destination = availableRides.Destination,
                    RideDate = availableRides.RideDate,
                    RideTime = availableRides.RideTime,
                    Price_Paid = availableRides.Price_Offerred
                });
                _context.SaveChanges();
                var user = _context.Users.Where(x => x.UserId == availableRides.UserId).FirstOrDefault();
                bookingStatus.Status = true;
                bookingStatus.BookingDetails = new BookingDetails
                {
                    RiderName = user.UserName,
                    Source = availableRides.Source,
                    Destination = availableRides.Destination,
                    RideDate = availableRides.RideDate,
                    RideTime = availableRides.RideTime,
                    Price_Paid = availableRides.Price_Offerred
                };
                return bookingStatus;
            }
            else
            {
                bookingStatus.Status = false;
                bookingStatus.BookingDetails = null;
                return bookingStatus;
            }
        }
        public bool UpdateRide(int BookingId)
        {
            var booking = _context.Bookings.Where(x => x.BookingId == BookingId).FirstOrDefault();
            booking.IsCompleted = true;
            var availableRides = _context.AvailableRides.Where(x => x.OfferId == booking.OfferId).FirstOrDefault();
            availableRides.Seats_Available = availableRides.Seats_Available + 1;
            if (availableRides.Seats_Available > 0)
            {
                availableRides.Booking_Status = false;
            }
            _context.SaveChanges();
            return true;
        }
        public bool AddOffer(AddOffer offer)
        {
            var user = _context.Users.Where(x => x.UserId == offer.UserId).FirstOrDefault();
            _context.AvailableRides.Add(new AvailableRides
            {
                UserId = offer.UserId,
                RiderName = user.UserName,
                Source = offer.Source,
                Destination = offer.Destination,
                RideDate = offer.RideDate,
                RideTime = offer.RideTime,
                Price_Offerred = offer.Price_Offerred,
                Seats_Available = offer.Seats_Available,
                Booking_Status = false
            });
            _context.SaveChanges();
            return true;
        }
    }
}
