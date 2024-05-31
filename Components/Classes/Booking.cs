namespace CarPeak.Components.Classes
{
    public class Booking
    {
        public Booking()
        {
            DateFrom = DateTime.Now.Date;
            DateTo = DateTime.Now.Date;
        }
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; } // Add this property
        public string CarName { get; set; } // Add this property
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
