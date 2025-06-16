using backend.Models;
using backend.Services;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _service;

        public RentalController(IRentalService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(RentalDto dto)
        {
            _service.AddRental(dto);
            return Ok(new { message = "Rental created." });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RentalDto dto)
        {
            _service.UpdateRental(id, dto);
            return Ok(new { message = "Rental updated." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteRental(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllRentals());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rental = _service.GetRentalById(id);
            return rental == null ? NotFound() : Ok(rental);
        }
    }
}