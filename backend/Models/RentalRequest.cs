using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class RentalRequest
    {
        [Key]
        public int RequestId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }

        public DateTime RequestedStartDate { get; set; }
        public DateTime RequestedEndDate { get; set; }

        public string RequestStatus { get; set; } // Pending, Approved, Rejected
        public string Purpose { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal EstimatedCost { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DateTime? ApprovedAt { get; set; }
        public string? AdminComments { get; set; }

        public User User { get; set; }
        public Car Car { get; set; }
    }
}
