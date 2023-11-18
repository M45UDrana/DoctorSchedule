using AppointmentService.Core.Abstractions.Repositories;
using AppointmentService.Core.Models;
using AppointmentService.Data;

namespace ScheduleService.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateAppointment(int scheduleId, Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }

            appointment.ScheduleId = scheduleId;
            _context.Appointments.Add(appointment);
        }

        public void CreateSchedule(Schedule schedule)
        {
            if(schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }
            _context.Schedules.Add(schedule);
        }

        public bool ExternalScheduleExists(int externalScheduleId)
        {
            return _context.Schedules.Any(s => s.ExternalID == externalScheduleId);
        }

        public IEnumerable<Schedule> GetAllSchedules()
        {
            return _context.Schedules.ToList();
        }

        public Appointment GetAppointment(int scheduleId, int appointmentId)
        {
            return _context.Appointments
                .Where(a => a.ScheduleId == scheduleId && a.Id == appointmentId).FirstOrDefault();
        }

        public IEnumerable<Appointment> GetAppointmentsForSchedule(int scheduleId)
        {
            return _context.Appointments
                .Where(a => a.ScheduleId == scheduleId);
        }

        public bool ScheduleExits(int scheduleId)
        {
            return _context.Schedules.Any(s => s.Id == scheduleId);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}