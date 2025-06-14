using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<RentalRequest> RentalRequests { get; set; }
    }
}
