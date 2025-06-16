namespace backend.DTOs
{ 
    public class FeedbackDto
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}