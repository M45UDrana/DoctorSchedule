using ScheduleService.Core.Dtos;

namespace ScheduleService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewSchedule(SchedulePublishedDto schedulePublishedDto);
    }
}