namespace backend.DTOs
{ 
    public class MaintenanceDto
    {
        public int CarId { get; set; }
        public string MaintenanceType { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Status { get; set; }
    }
}