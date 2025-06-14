using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string Role { get; set; } = "User"; // User, Admin
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public ICollection<RentalRequest> RentalRequests { get; set; }
        //public ICollection<Rental> Rentals { get; set; }
        //public ICollection<Feedback> Feedbacks { get; set; }
    }
}