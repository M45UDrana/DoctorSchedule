using AppointmentService.Core.Dtos;
using AppointmentService.Core.Models;
using AutoMapper;

namespace AppointmentService.Core.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            // Source -> Destination
            CreateMap<Schedule, ScheduleReadDto>();
            CreateMap<AppointmentCreateDto, Appointment>();
            CreateMap<Appointment, AppointmentCreateDto>();
            CreateMap<SchedulePublishedDto, Schedule>()
                .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.Id));
        }
    }
}