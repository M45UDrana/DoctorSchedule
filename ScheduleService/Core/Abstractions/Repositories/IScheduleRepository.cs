using ScheduleService.Core.Models;

namespace ScheduleService.Core.Abstractions.Repositories
{
    public interface IScheduleRepository
    {
        Schedule GetSchedule(int doctorId, int scheduleId);
        void CreateSchedule(int doctorId, Schedule schedule);
        IEnumerable<Schedule> GetSchedulesForDoctor(int doctorId);
        IEnumerable<Schedule> GetAllSchedules();
        bool DoctorExits(int doctorId);
        bool SaveChanges();
    }
}