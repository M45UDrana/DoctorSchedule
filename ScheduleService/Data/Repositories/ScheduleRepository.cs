using ScheduleService.Core.Abstractions.Repositories;
using ScheduleService.Core.Models;

namespace ScheduleService.Data.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext _context;

        public ScheduleRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateSchedule(int doctorId, Schedule schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }

            schedule.DoctorId = doctorId;
            _context.Schedules.Add(schedule);
        }

        public Schedule GetSchedule(int doctorId, int scheduleId)
        {
            return _context.Schedules
                .Where(shd => shd.DoctorId == doctorId && shd.Id == scheduleId).FirstOrDefault();
        }

        public IEnumerable<Schedule> GetSchedulesForDoctor(int doctorId)
        {
            return _context.Schedules
                .Where(shd => shd.DoctorId == doctorId);
        }

        public IEnumerable<Schedule> GetAllSchedules()
        {
            return _context.Schedules.ToList();
        }

        public bool DoctorExits(int doctorId)
        {
            return _context.Doctors.Any(doc => doc.Id == doctorId);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}