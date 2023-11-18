using AppointmentService.Core.Models;

namespace AppointmentService.Core.Abstractions.Repositories
{
    public interface IAppointmentRepository
    {
        bool SaveChanges();

        // Schedules
        IEnumerable<Schedule> GetAllSchedules();
        void CreateSchedule(Schedule schedule);
        bool ScheduleExits(int scheduleId);
        bool ExternalScheduleExists(int externalScheduleId);

        // Appointments
        IEnumerable<Appointment> GetAppointmentsForSchedule(int ScheduleId);
        Appointment GetAppointment(int ScheduleId, int appointmentId);
        void CreateAppointment(int ScheduleId, Appointment appointment);
    }
}