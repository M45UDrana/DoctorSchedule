using AppointmentService.Core.Models;

namespace AppointmentService.SyncDataServices.Grpc
{
    public interface IScheduleDataClient
    {
        IEnumerable<Schedule> ReturnAllSchedules();
    }
}