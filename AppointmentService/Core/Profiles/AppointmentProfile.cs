using AppointmentService.Core.Dtos;
using AppointmentService.Core.Models;
using AutoMapper;

namespace AppointmentService.Core.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            // Source -> Target
            CreateMap<Schedule, ScheduleReadDto>();
            CreateMap<AppointmentCreateDto, Appointment>();
            CreateMap<Appointment, AppointmentCreateDto>();
        }
    }
}