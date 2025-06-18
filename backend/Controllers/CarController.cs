using backend.Models;
using backend.Services;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // ADMIN - ADD CAR
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCar([FromBody] CarDto dto)
        {
            _carService.AddCar(dto);
            return Ok(new { message = "Car added successfully" });
        }

        // ADMIN - UPDATE CAR
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int carId, [FromBody] CarDto dto)
        {
            _carService.UpdateCar(carId, dto);
            return Ok(new { message = "Car updated successfully" });
        }

        // ADMIN - DELETE CAR
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int carId)
        {
            _carService.DeleteCar(carId);
            return NoContent();
        }

        // ADMIN/USER - GET BY ID
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetCarById(int carId)
        {
            var car = _carService.GetCarById(carId);
            return car == null ? NotFound() : Ok(car);
        }

        // ADMIN/USER - GET ALL
        [Authorize]
        [HttpGet]
        public IActionResult GetAllCars()
        {
            return Ok(_carService.GetAllCars());
        }
    }
}