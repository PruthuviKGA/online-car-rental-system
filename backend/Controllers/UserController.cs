using backend.Models;
using backend.Services;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto dto)
        {
            var result = _userService.RegisterUser(dto);
            if (!result.Success)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = "Registration successful. Awaiting admin approval." });
        }

        [Authorize(Roles = "User")]
        [HttpGet("me")]
        public IActionResult GetMyProfile()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = _userService.GetUserById(userId);
            return user == null ? NotFound("User not found") : Ok(user);
        }

        [Authorize(Roles = "User")]
        [HttpPut("me")]
        public IActionResult UpdateProfile([FromBody] UserUpdateDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _userService.UpdateUserProfile(userId, dto);
            if (!result) return BadRequest("Update failed");
            return Ok(new { message = "Profile updated successfully" });
        }
    }
}
