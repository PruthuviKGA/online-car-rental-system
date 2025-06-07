namespace backend.Models;
public class MaintenanceRecord
{
    public int MaintenanceId { get; set; }
    public int CarId { get; set; }

    public string MaintenanceType { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Cost { get; set; }
    public DateTime MaintenanceDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Completed

    // Navigation
    public Car? Car { get; set; }
}
