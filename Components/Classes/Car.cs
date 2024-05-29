namespace CarPeak.Components.Classes
{
    public class Car
    {

        public int Id { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public int? Size { get; set; }
        public string Color { get; set; }
        public string Gearbox { get; set; }
        public double? PricePerDay { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }

        public bool AllFieldsFilled()
        {
            return (Model != null && Year != null && Size != 0 && Color != null && Gearbox != null && PricePerDay != 0 && City != null && ImageUrl != null);
        }
    }
}
