using backend.Models;
using backend.DTOs;

namespace backend.Services
{
    public interface IRentalService
    {
        void AddRental(RentalDto dto);
        void UpdateRental(int id, RentalDto dto);
        void DeleteRental(int id);
        Rental GetRentalById(int id);
        List<Rental> GetAllRentals();
    }
}