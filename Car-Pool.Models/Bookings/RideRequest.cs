namespace Car_Pool.Models.Bookings

{
    public class RideRequest
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime RideDate { get; set; }
        public string RideTime { get; set; }
    }
}
