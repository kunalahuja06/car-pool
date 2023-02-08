//using Car_Pool.Models.Models;
//using Car_Pool.Models.Models.Bookings;
//using Car_Pool.Models.Models.User;
//using Car_Pool.Services.Contracts;
//using Car_Pool.Services.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Car_Pool.Services
//{
//    public class UserRides:IUserRides
//    {
//        private readonly DBContext _context;
//        public UserRides(DBContext context)
//        {
//            _context = context;
//        }
//        public List<BookingDetails> GetUserBookings(int UserId)
//        {
//            IQueryable <Bookings> bookings= _context.Bookings.Where(x => x.UserId == UserId);
            
//        }
//    }
//}

