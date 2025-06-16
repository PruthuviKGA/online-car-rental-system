using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        [ForeignKey("Rental")]
        public int RentalId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }

        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; }

        public Rental Rental { get; set; }
        public User User { get; set; }
        public Car Car { get; set; }
    }
}