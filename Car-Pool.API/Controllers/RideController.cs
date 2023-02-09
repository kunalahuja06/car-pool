using Car_Pool.Models.Bookings;
using Car_Pool.Models.Offers;
using Car_Pool.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Car_Pool.API.Controllers
{
    public class RideController : Controller
    {
        private readonly ICarRides _carRides;
        public RideController(ICarRides carRides)
        {
            _carRides = carRides;
        }
        [HttpPost]
        [Route("ride/GetAvailableRides")]
        public IActionResult GetAvailableRides([FromBody] RideRequest rideRequest)
        {
            try
            {
                var availableRides = _carRides.GetAvailableRides(rideRequest);
                return Ok(new
                {
                    StatusCode = 200,
                    AvailableRides=availableRides
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("ride/BookRide")]
        public IActionResult BookRide( int OfferId)
        {
            try
            {
                if (OfferId <= 0)
                {
                    return BadRequest("Invalid OfferId");
                }
                else
                {
                    BookingStatus bookingStatus = _carRides.BookRide(OfferId);
                    if (bookingStatus.Status)
                    {
                        return Ok(new
                        {
                            Message = "Ride Booked Successfully",
                            BookingDetails = bookingStatus.BookingDetails
                        });
                    }
                    else
                    {
                        return Ok("Ride Not Booked");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("ride/UpdateRide")]
        public IActionResult UpdateRide(int BookingId)
        {
            try
            {
                if (BookingId <= 0)
                {
                    return BadRequest("Invalid BookingId");
                }
                else
                {
                    bool status = _carRides.UpdateRide(BookingId);
                    if (status)
                    {
                        return Ok(new
                        {
                            StatusCode=200,
                            Message="Ride Updated Successfully"
                        });
                    }
                    else
                    {
                        return Ok("Ride Not Updated");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("ride/CreateOffer")]
        public IActionResult CreateOffer([FromBody] AddOffer offer)
        {
            try
            {
                if (offer == null)
                {
                    return BadRequest("Invalid Offer");
                }
                else
                {
                    bool status = _carRides.AddOffer(offer);
                    if (status)
                    {
                        return Ok(new
                        {
                            StatusCode = 200,
                            Message = "Ride Offer Created Successfully"
                        });
                    }
                    else
                    {
                        return Ok("Ride Offer Not Created");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
