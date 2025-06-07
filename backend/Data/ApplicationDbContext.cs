using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // DbSets
        public DbSet<User> Users => Set<User>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<RentalRequest> RentalRequests => Set<RentalRequest>();
        public DbSet<Rental> Rentals => Set<Rental>();
        public DbSet<Feedback> Feedbacks => Set<Feedback>();
        public DbSet<MaintenanceRecord> MaintenanceRecords => Set<MaintenanceRecord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-many: User -> RentalRequests
            modelBuilder.Entity<RentalRequest>()
                .HasOne(r => r.User)
                .WithMany(u => u.RentalRequests)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ApprovedByAdmin optional relationship
            modelBuilder.Entity<RentalRequest>()
                .HasOne(r => r.ApprovedByAdmin)
                .WithMany()
                .HasForeignKey(r => r.ApprovedByAdminId)
                .OnDelete(DeleteBehavior.Restrict);

            // RentalRequest -> Rental (1-to-1)
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.RentalRequest)
                .WithOne(rr => rr.Rental)
                .HasForeignKey<Rental>(r => r.RequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Feedback -> Rental (1-to-1)
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Rental)
                .WithOne(r => r.Feedback)
                .HasForeignKey<Feedback>(f => f.RentalId)
                .OnDelete(DeleteBehavior.Cascade);

            // Car -> MaintenanceRecords
            modelBuilder.Entity<MaintenanceRecord>()
                .HasOne(m => m.Car)
                .WithMany(c => c.MaintenanceRecords)
                .HasForeignKey(m => m.CarId);
        }
    }
}
