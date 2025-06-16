using backend.Models;
using backend.DTOs;

namespace backend.Services
{
    public interface IFeedbackService
    {
        void AddFeedback(int userId, FeedbackDto dto);
        void UpdateFeedback(int id, int userId, FeedbackDto dto);
        Feedback GetFeedbackById(int id);
        List<Feedback> GetAllFeedback();
        void DeleteFeedback(int id);
    }
}