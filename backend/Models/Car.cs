namespace backend.Models;
public class Car
{
    public int CarId { get; set; }
    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int Year { get; set; }
    public string Color { get; set; } = null!;
    public string LicensePlate { get; set; } = null!;
    public decimal PricePerDay { get; set; }
    public string CarStatus { get; set; } = "Available"; // Available, Rented, UnderMaintenance
    public string Category { get; set; } = null!;
    public int Mileage { get; set; }
    public string FuelType { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation
    public ICollection<RentalRequest>? RentalRequests { get; set; }
    public ICollection<Rental>? Rentals { get; set; }
    public ICollection<Feedback>? Feedbacks { get; set; }
    public ICollection<MaintenanceRecord>? MaintenanceRecords { get; set; }
}
