namespace backend.DTOs
{
    public class CarDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public decimal PricePerDay { get; set; }
        public string CarStatus { get; set; }
        public string Category { get; set; }
        public int Mileage { get; set; }
        public string FuelType { get; set; }
    }
}