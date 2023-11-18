using ScheduleService.Core.Models;

namespace ScheduleService.Core.Abstractions.Repositories
{
    public interface IDoctorRepository
    {
        void CreateDoctor(Doctor doctor);
        Doctor GetDoctorById(int id);
        IEnumerable<Doctor> GetAllDoctors();
        bool SaveChanges();
    }
}