using backend.Models;
using backend.DTOs;

namespace backend.Services
{
    public interface IMaintenanceService
    {
        void Add(MaintenanceDto dto);
        void Update(int id, MaintenanceDto dto);
        MaintenanceRecord GetById(int id);
        List<MaintenanceRecord> GetAll();
        void Delete(int id);
    }
}
