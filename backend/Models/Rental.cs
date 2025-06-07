namespace backend.Models;
public class Rental
{
    public int RentalId { get; set; }

    // Foreign Keys
    public int RequestId { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }

    // Data
    public DateTime ActualStartDate { get; set; }
    public DateTime ActualEndDate { get; set; }
    public decimal TotalCost { get; set; }
    public string RentalStatus { get; set; } = "Ongoing"; // Ongoing, Completed
    public int StartMileage { get; set; }
    public int EndMileage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation
    public RentalRequest? RentalRequest { get; set; }
    public User? User { get; set; }
    public Car? Car { get; set; }
    public Feedback? Feedback { get; set; }
}
