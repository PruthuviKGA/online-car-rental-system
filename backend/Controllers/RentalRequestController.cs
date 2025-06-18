using backend.Models;
using backend.Services;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalRequestController : ControllerBase
    {
        private readonly IRentalRequestService _service;

        public RentalRequestController(IRentalRequestService service)
        {
            _service = service;
        }

        // USER: Submit request
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Create(RentalRequestDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            _service.CreateRequest(userId, dto);
            return Ok(new { message = "Rental request submitted." });
        }

        // ADMIN: Update request status
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateStatus(int requestId, UpdateRequestStatusDto dto)
        {
            _service.UpdateStatus(requestId, dto);
            return Ok(new { message = "Request status updated." });
        }

        // ADMIN: Get all requests
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllRequests());
        }

        // USER: Get their own requests
        [Authorize(Roles = "User")]
        [HttpGet("my")]
        public IActionResult GetMine()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return Ok(_service.GetUserRequests(userId));
        }

        // ALL: Get by ID
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int requestId)
        {
            var request = _service.GetRequestById(requestId);
            return request == null ? NotFound() : Ok(request);
        }

        // ADMIN: Delete
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int requestId)
        {
            _service.DeleteRequest(requestId);
            return NoContent();
        }
    }
}