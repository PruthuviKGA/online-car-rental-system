using backend.Data;
using backend.DTOs;
using backend.Models;
using backend.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly CarRentalDbContext _context;
        private readonly IConfiguration _config;

        public UserService(CarRentalDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string Login(UserLoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);
            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials.");

            if (!user.IsActive)
                throw new UnauthorizedAccessException("User is not active.");

            return JwtHelper.GenerateJwtToken(user, _config);
        }

        // User Endpoints for Admin
        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        public List<User> GetAllActiveUsers()
        {
            return _context.Users
                .Where(u => u.Role != "Admin" && u.IsActive)
                .ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public bool UpdateUserActiveStatus(int id, bool isActive)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null || user.Role == "Admin") return false;

            user.IsActive = isActive;
            user.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null || user.Role == "Admin") return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        //User Endpoints for User
        public ServiceResponse RegisterUser(UserRegisterDto dto)
        {
            if (_context.Users.Any(u => u.Email == dto.Email))
            {
                return new ServiceResponse { Success = false, Message = "Email already exists" };
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                PasswordHash = hashedPassword,
                Role = "User",
                IsActive = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return new ServiceResponse { Success = true };
        }

        public bool UpdateUserProfile(int userId, UserUpdateDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null) return false;

            user.PhoneNumber = dto.PhoneNumber;
            user.Address = dto.Address;
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();
            return true;
        }

    }
}
