namespace backend.Models;
public class RentalRequest
{
    public int RequestId { get; set; }

    // Foreign Keys
    public int UserId { get; set; }
    public int CarId { get; set; }
    public int? ApprovedByAdminId { get; set; }

    // Data
    public DateTime RequestedStartDate { get; set; }
    public DateTime RequestedEndDate { get; set; }
    public string RequestStatus { get; set; } = "Pending"; // Pending, Approved, Rejected
    public string Purpose { get; set; } = null!;
    public decimal EstimatedCost { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public string? AdminComments { get; set; }

    // Navigation
    public User? User { get; set; }
    public Car? Car { get; set; }
    public User? ApprovedByAdmin { get; set; }
    public Rental? Rental { get; set; }
}
