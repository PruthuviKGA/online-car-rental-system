namespace backend.DTOs
{ 
    public class RentalDto
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public decimal TotalCost { get; set; }
        public string RentalStatus { get; set; }
        public int StartMileage { get; set; }
        public int EndMileage { get; set; }
    }
}