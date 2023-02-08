using Car_Pool.Models.Bookings;
using Car_Pool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Pool.Models.Offer_Rides;
using Car_Pool.Models.Available_Rides;

namespace Car_Pool.Services.Contracts
{
    public interface ICarRides
    {
        List<AvailableRides> GetAvailableRides(RideRequest request);
        BookingStatus BookRide(int OfferId);
        bool UpdateRide(int BookingId);
        bool AddOffer(AddOffer offer);
    }
}
