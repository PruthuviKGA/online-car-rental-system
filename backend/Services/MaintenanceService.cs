using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{ 
    public class MaintenanceService : IMaintenanceService
    {
        private readonly CarRentalDbContext _context;

        public MaintenanceService(CarRentalDbContext context)
        {
            _context = context;
        }

        public void Add(MaintenanceDto dto)
        {
            var record = new MaintenanceRecord
            {
                CarId = dto.CarId,
                MaintenanceType = dto.MaintenanceType,
                Description = dto.Description,
                Cost = dto.Cost,
                MaintenanceDate = dto.MaintenanceDate,
                CreatedAt = DateTime.UtcNow,
                Status = dto.Status
            };
            _context.MaintenanceRecords.Add(record);
            _context.SaveChanges();
        }

        public void Update(int id, MaintenanceDto dto)
        {
            var record = _context.MaintenanceRecords.FirstOrDefault(x => x.MaintenanceId == id);
            if (record == null) throw new Exception("Record not found.");

            record.CarId = dto.CarId;
            record.MaintenanceType = dto.MaintenanceType;
            record.Description = dto.Description;
            record.Cost = dto.Cost;
            record.MaintenanceDate = dto.MaintenanceDate;
            record.Status = dto.Status;
            _context.SaveChanges();
        }

        public MaintenanceRecord GetById(int id)
        {
            return _context.MaintenanceRecords.Include(x => x.Car).FirstOrDefault(x => x.MaintenanceId == id);
        }

        public List<MaintenanceRecord> GetAll()
        {
            return _context.MaintenanceRecords.Include(x => x.Car).ToList();
        }

        public void Delete(int id)
        {
            var record = _context.MaintenanceRecords.Find(id);
            if (record == null) throw new Exception("Record not found.");
            _context.MaintenanceRecords.Remove(record);
            _context.SaveChanges();
        }
    }
}