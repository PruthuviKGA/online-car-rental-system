using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{  
    public class RentalService : IRentalService
    {
        private readonly CarRentalDbContext _context;

        public RentalService(CarRentalDbContext context)
        {
            _context = context;
        }

        public void AddRental(RentalDto dto)
        {
            var rental = new Rental
            {
                RequestId = dto.RequestId,
                UserId = dto.UserId,
                CarId = dto.CarId,
                ActualStartDate = dto.ActualStartDate,
                ActualEndDate = dto.ActualEndDate,
                TotalCost = dto.TotalCost,
                RentalStatus = dto.RentalStatus,
                StartMileage = dto.StartMileage,
                EndMileage = dto.EndMileage,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Rentals.Add(rental);

            // Set car status to Rented
            var car = _context.Cars.Find(dto.CarId);
            if (car != null)
            {
                car.CarStatus = "Rented";
                car.UpdatedAt = DateTime.UtcNow;
            }

            _context.SaveChanges();
        }

        public void UpdateRental(int id, RentalDto dto)
        {
            var rental = _context.Rentals.Find(id);
            if (rental == null) throw new Exception("Rental not found");

            rental.ActualStartDate = dto.ActualStartDate;
            rental.ActualEndDate = dto.ActualEndDate;
            rental.TotalCost = dto.TotalCost;
            rental.RentalStatus = dto.RentalStatus;
            rental.StartMileage = dto.StartMileage;
            rental.EndMileage = dto.EndMileage;
            rental.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }

        public void DeleteRental(int id)
        {
            var rental = _context.Rentals.Find(id);
            if (rental == null) throw new Exception("Rental not found");

            _context.Rentals.Remove(rental);
            _context.SaveChanges();
        }

        public Rental GetRentalById(int id)
        {
            return _context.Rentals
                .Include(r => r.User)
                .Include(r => r.Car)
                .Include(r => r.RentalRequest)
                .FirstOrDefault(r => r.RentalId == id);
        }

        public List<Rental> GetAllRentals()
        {
            return _context.Rentals
                .Include(r => r.User)
                .Include(r => r.Car)
                .Include(r => r.RentalRequest)
                .ToList();
        }
    }
}