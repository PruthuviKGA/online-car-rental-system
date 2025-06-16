using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{ 
    public class FeedbackService : IFeedbackService
    {
        private readonly CarRentalDbContext _context;

        public FeedbackService(CarRentalDbContext context)
        {
            _context = context;
        }

        public void AddFeedback(int userId, FeedbackDto dto)
        {
            var feedback = new Feedback
            {
                RentalId = dto.RentalId,
                UserId = userId,
                CarId = dto.CarId,
                Rating = dto.Rating,
                Comments = dto.Comments,
                CreatedAt = DateTime.UtcNow
            };

            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public void UpdateFeedback(int id, int userId, FeedbackDto dto)
        {
            var feedback = _context.Feedbacks.FirstOrDefault(f => f.FeedbackId == id && f.UserId == userId);
            if (feedback == null) throw new Exception("Feedback not found or unauthorized.");

            feedback.Rating = dto.Rating;
            feedback.Comments = dto.Comments;
            _context.SaveChanges();
        }

        public Feedback GetFeedbackById(int id)
        {
            return _context.Feedbacks
                .Include(f => f.User)
                .Include(f => f.Car)
                .Include(f => f.Rental)
                .FirstOrDefault(f => f.FeedbackId == id);
        }

        public List<Feedback> GetAllFeedback()
        {
            return _context.Feedbacks
                .Include(f => f.User)
                .Include(f => f.Car)
                .Include(f => f.Rental)
                .ToList();
        }

        public void DeleteFeedback(int id)
        {
            var feedback = _context.Feedbacks.Find(id);
            if (feedback == null) throw new Exception("Feedback not found.");
            _context.Feedbacks.Remove(feedback);
            _context.SaveChanges();
        }
    }
}