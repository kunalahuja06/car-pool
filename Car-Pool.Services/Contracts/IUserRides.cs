using Car_Pool.Models;
using Car_Pool.Models.Bookings;
using Car_Pool.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Pool.Services.Contracts
{
    public interface IUserRides
    {
        List<Bookings> GetUserBookings(int UserId);
        List<AvailableRides> GetUserOffers(int UserId);
    }
}
