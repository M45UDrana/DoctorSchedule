using ScheduleService.Core.Abstractions.Repositories;
using ScheduleService.Core.Models;

namespace ScheduleService.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }
            _context.Doctors.Add(doctor);
        }

        public Doctor GetDoctorById(int id)
        {
            return _context.Doctors.FirstOrDefault(doc => doc.Id == id);
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}