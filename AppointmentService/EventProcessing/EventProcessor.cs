using System.Text.Json;
using AppointmentService.Core.Abstractions.Repositories;
using AppointmentService.Core.Dtos;
using AppointmentService.Core.Models;
using AutoMapper;

namespace AppointmentService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.SchedulePublished:
                    addSchedule(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notifcationMessage)
        {
            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notifcationMessage);

            switch(eventType.Event)
            {
                case "Schedule_Published":
                    return EventType.SchedulePublished;
                default:
                    return EventType.Undetermined;
            }
        }

        private void addSchedule(string schedulePublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IAppointmentRepository>();
                
                var schedulePublishedDto = JsonSerializer.Deserialize<SchedulePublishedDto>(schedulePublishedMessage);

                try
                {
                    var schedule = _mapper.Map<Schedule>(schedulePublishedDto);
                    if(!repository.ExternalScheduleExists(schedule.ExternalID))
                    {
                        repository.CreateSchedule(schedule);
                        repository.SaveChanges();
                    }

                }
                catch
                {
                    throw new Exception();
                }
            }
        }
    }

    enum EventType
    {
        SchedulePublished,
        Undetermined
    }
}