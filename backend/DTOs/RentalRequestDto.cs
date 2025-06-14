namespace backend.DTOs
{        
        public class RentalRequestDto
        {
            public int CarId { get; set; }
            public DateTime RequestedStartDate { get; set; }
            public DateTime RequestedEndDate { get; set; }
            public string Purpose { get; set; }
            public decimal EstimatedCost { get; set; }
        }

        public class UpdateRequestStatusDto
        {
            public string RequestStatus { get; set; } // Approved, Rejected
            public string AdminComments { get; set; }
        }

}