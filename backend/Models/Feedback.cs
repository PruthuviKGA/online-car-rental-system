namespace backend.Models;
public class Feedback
{
    public int FeedbackId { get; set; }

    // Foreign Keys
    public int RentalId { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }

    // Data
    public int Rating { get; set; } // 1 to 5
    public string Comments { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    // Navigation
    public Rental? Rental { get; set; }
    public User? User { get; set; }
    public Car? Car { get; set; }
}
