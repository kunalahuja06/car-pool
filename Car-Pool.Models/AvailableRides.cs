using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Pool.Models
{
    public class AvailableRides
    {
        public int UserId { get; set; }
        [Key]
        public int OfferId { get; set; }
        public string? RiderName { get; set; }
        public string? Source { get; set; }
        public string? Destination { get; set; }
        public DateTime RideDate { get; set; }
        public string? RideTime { get; set; }
        public int Price_Offerred { get; set; }
        public int Seats_Available { get; set; }
        public bool Booking_Status { get; set; }
    }
}
