using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{    
    public class RentalRequestService : IRentalRequestService
    {
        private readonly CarRentalDbContext _context;

        public RentalRequestService(CarRentalDbContext context)
        {
            _context = context;
        }

        public void CreateRequest(int userId, RentalRequestDto dto)
        {
            var request = new RentalRequest
            {
                UserId = userId,
                CarId = dto.CarId,
                RequestedStartDate = dto.RequestedStartDate,
                RequestedEndDate = dto.RequestedEndDate,
                Purpose = dto.Purpose,
                EstimatedCost = dto.EstimatedCost,
                RequestStatus = "Pending",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.RentalRequests.Add(request);
            _context.SaveChanges();
        }

        public void UpdateStatus(int requestId, UpdateRequestStatusDto dto)
        {
            var request = _context.RentalRequests.Find(requestId);
            if (request == null) throw new Exception("Request not found");

            request.RequestStatus = dto.RequestStatus;
            request.AdminComments = dto.AdminComments;
            request.UpdatedAt = DateTime.UtcNow;
            request.ApprovedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }

        public List<RentalRequest> GetAllRequests()
        {
            return _context.RentalRequests.Include(r => r.User).Include(r => r.Car).ToList();
        }

        public List<RentalRequest> GetUserRequests(int userId)
        {
            return _context.RentalRequests
                .Where(r => r.UserId == userId)
                .Include(r => r.Car)
                .ToList();
        }

        public RentalRequest GetRequestById(int requestId)
        {
            return _context.RentalRequests
                .Include(r => r.User)
                .Include(r => r.Car)
                .FirstOrDefault(r => r.RequestId == requestId);
        }

        public void DeleteRequest(int requestId)
        {
            var request = _context.RentalRequests.Find(requestId);
            if (request == null) throw new Exception("Request not found");

            _context.RentalRequests.Remove(request);
            _context.SaveChanges();
        }
    }
}