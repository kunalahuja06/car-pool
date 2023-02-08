namespace Car_Pool.Models
    
{
    public class RideRequest
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public string RideDate { get; set; }
        public string RideTime { get; set; }
    }
}
