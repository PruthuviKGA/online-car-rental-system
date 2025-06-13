using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public IActionResult GetAllActiveUsers()
        {
            var users = _userService.GetAllActiveUsers();
            return Ok(users);
        }

        [HttpGet("users/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound("User not found");
            return Ok(user);
        }

        [HttpPut("users/{id}")]
        public IActionResult UpdateUserActiveStatus(int id, [FromQuery] bool isActive)
        {
            var result = _userService.UpdateUserActiveStatus(id, isActive);
            if (!result) return NotFound(new { message = "User not found or cannot be modified." });

            var status = isActive ? "activated" : "deactivated";
            return Ok(new { message = $"User {id} has been {status}." });
        }

        [HttpDelete("users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var success = _userService.DeleteUser(id);
            if (!success) return NotFound(new { message = "User not found or cannot be deleted." });

            return Ok(new { message = $"User {id} has been deleted successfully." });
        }
    }
}
