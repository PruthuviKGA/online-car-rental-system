using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<RentalRequest> RentalRequests => Set<RentalRequest>();
        public DbSet<Rental> Rentals => Set<Rental>();
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }

                protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Rental → User
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rentals)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Rental → Car
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            // Rental → RentalRequest
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.RentalRequest)
                .WithMany(req => req.Rentals)
                .HasForeignKey(r => r.RequestId)
                .OnDelete(DeleteBehavior.Restrict);

            // RentalRequest → User
            modelBuilder.Entity<RentalRequest>()
                .HasOne(req => req.User)
                .WithMany(u => u.RentalRequests)
                .HasForeignKey(req => req.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // RentalRequest → Car
            modelBuilder.Entity<RentalRequest>()
                .HasOne(req => req.Car)
                .WithMany(c => c.RentalRequests)
                .HasForeignKey(req => req.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            // Feedback → User
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Feedback → Car
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Car)
                .WithMany(c => c.Feedbacks)
                .HasForeignKey(f => f.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            // Feedback → Rental
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Rental)
                .WithMany(r => r.Feedbacks)
                .HasForeignKey(f => f.RentalId)
                .OnDelete(DeleteBehavior.Restrict);

            // MaintenanceRecord → Car
            modelBuilder.Entity<MaintenanceRecord>()
                .HasOne(m => m.Car)
                .WithMany(c => c.MaintenanceRecords)
                .HasForeignKey(m => m.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
