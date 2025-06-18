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
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _service;

        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Add([FromBody] FeedbackDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            _service.AddFeedback(userId, dto);
            return Ok(new { message = "Feedback submitted." });
        }

        [Authorize(Roles = "User")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] FeedbackDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            _service.UpdateFeedback(id, userId, dto);
            return Ok(new { message = "Feedback updated." });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var feedback = _service.GetFeedbackById(id);
            return feedback == null ? NotFound() : Ok(feedback);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllFeedback());
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteFeedback(id);
            return NoContent();
        }
    }
}