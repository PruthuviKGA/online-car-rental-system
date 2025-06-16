using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }

        [ForeignKey("RentalRequest")]
        public int RequestId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }

        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalCost { get; set; }
        public string RentalStatus { get; set; } // Ongoing, Completed, Cancelled
        public int StartMileage { get; set; }
        public int EndMileage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public RentalRequest RentalRequest { get; set; }
        public User User { get; set; }
        public Car Car { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
