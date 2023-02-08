using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Pool.Models
{
    public class BookingDetails
    {
        [Key]
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int OfferId { get; set; }
        public string RiderName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string RideDate { get; set; }
        public string RideTime { get; set; }
        public int Price_Paid { get; set; }
    }
}
