using backend.Models;
using backend.DTOs;

namespace backend.Services
{
    public interface ICarService
    {
        void AddCar(CarDto dto);
        void UpdateCar(int carId, CarDto dto);
        void DeleteCar(int carId);
        Car GetCarById(int carId);
        List<Car> GetAllCars();
    }
}