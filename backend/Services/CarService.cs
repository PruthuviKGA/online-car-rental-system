using backend.Data;
using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public class CarService : ICarService
    {
        private readonly CarRentalDbContext _context;

        public CarService(CarRentalDbContext context)
        {
            _context = context;
        }

        public void AddCar(CarDto dto)
        {
            var car = new Car
            {
                Make = dto.Make,
                Model = dto.Model,
                Year = dto.Year,
                Color = dto.Color,
                LicensePlate = dto.LicensePlate,
                PricePerDay = dto.PricePerDay,
                CarStatus = dto.CarStatus,
                Category = dto.Category,
                Mileage = dto.Mileage,
                FuelType = dto.FuelType,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void UpdateCar(int carId, CarDto dto)
        {
            var car = _context.Cars.Find(carId);
            if (car == null) throw new Exception("Car not found");

            car.Make = dto.Make;
            car.Model = dto.Model;
            car.Year = dto.Year;
            car.Color = dto.Color;
            car.LicensePlate = dto.LicensePlate;
            car.PricePerDay = dto.PricePerDay;
            car.CarStatus = dto.CarStatus;
            car.Category = dto.Category;
            car.Mileage = dto.Mileage;
            car.FuelType = dto.FuelType;
            car.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }

        public void DeleteCar(int carId)
        {
            var car = _context.Cars.Find(carId);
            if (car == null) throw new Exception("Car not found");

            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        public Car GetCarById(int carId)
        {
            return _context.Cars.Find(carId);
        }

        public List<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }
    }
}
