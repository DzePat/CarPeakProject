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
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
