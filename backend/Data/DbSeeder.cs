using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(CarRentalDbContext context)
        {
            // Check if admin user already exists
            if (!await context.Users.AnyAsync(u => u.Role == "Admin"))
            {
                var adminUser = new User
                {
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@carrental.com",
                    PhoneNumber = "+1234567890",
                    Address = "Admin Address",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                    Role = "Admin",
                    IsActive = true
                };

                context.Users.Add(adminUser);
                await context.SaveChangesAsync();
            }
        }
    }
}