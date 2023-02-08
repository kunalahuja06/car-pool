//using Car_Pool.Services.Contracts;
//using Microsoft.AspNetCore.Mvc;

//namespace Car_Pool.API.Controllers
//{
//    public class UserController : Controller
//    {
//        //private readonly IUserRides _userRides;
//        public UserController(IUserRides userRides)
//        {
//            _userRides = userRides;
//        }
//        [HttpPost]
//        [Route("user/GetUserBookings")]
//        public IActionResult getUserBookings(int UserId)
//        {
//            try
//            {
//                if (UserId <= 0)
//                {
//                    return BadRequest("Invalid UserId");
//                }
//                else
//                {
//                    var userBookings = _userRides.GetUserBookings(UserId);
//                    return Ok(new
//                    {
//                        StatusCode = 200,
//                        UserBookings = userBookings
//                    });
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//    }
//}
