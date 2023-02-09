using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Pool.Models.Offers
{
    public class Stops
    {
        [Key]
        public int StopId { get; set; }
        public string? StopName { get; set; }
        public int OfferId { get; set; }
    }
}
