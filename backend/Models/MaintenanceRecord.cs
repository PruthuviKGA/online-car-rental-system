using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class MaintenanceRecord
    {
        [Key]
        public int MaintenanceId { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }

        public string MaintenanceType { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Cost { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        public Car Car { get; set; }
    }
}
