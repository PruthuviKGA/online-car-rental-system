using backend.Models;
using backend.DTOs;

namespace backend.Services
{
    public interface IRentalRequestService
    {
        void CreateRequest(int userId, RentalRequestDto dto);
        void UpdateStatus(int requestId, UpdateRequestStatusDto dto);
        List<RentalRequest> GetAllRequests();
        List<RentalRequest> GetUserRequests(int userId);
        RentalRequest GetRequestById(int requestId);
        void DeleteRequest(int requestId);
    }
}
