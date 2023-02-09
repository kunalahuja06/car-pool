using Car_Pool.Models;
using Car_Pool.Models.Bookings;
using Car_Pool.Models.User;
using Car_Pool.Services.Contracts;
using Car_Pool.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Pool.Services
{
    public class UserRides : IUserRides
    {
        private readonly DBContext _context;
        public UserRides(DBContext context)
        {
            _context = context;
        }
        public List<Bookings> GetUserBookings(int UserId)
        {
            IQueryable<Bookings> bookings = _context.Bookings.Where(x => x.UserId == UserId);
            return bookings.ToList();

        }
        public List<AvailableRides> GetUserOffers(int OfferId)
        {
            IQueryable<AvailableRides> offers = _context.AvailableRides.Where(x => x.UserId == OfferId);
            return offers.ToList();
        }
    }
}

