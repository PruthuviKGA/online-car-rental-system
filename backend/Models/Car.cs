using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal PricePerDay { get; set; }
        public string CarStatus { get; set; } // Available, Rented, UnderMaintenance
        public string Category { get; set; }
        public int Mileage { get; set; }
        public string FuelType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<RentalRequest> RentalRequests { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }
    }
}

