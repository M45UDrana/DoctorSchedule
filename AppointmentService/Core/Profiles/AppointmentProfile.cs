using AppointmentService.Core.Dtos;
using AppointmentService.Core.Models;
using AutoMapper;
using ScheduleService;

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

            CreateMap<GrpcScheduleModel, Schedule>()
                .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.ScheduleId))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.DoctorName))
                .ForMember(dest => dest.StartTime, opt => opt.Ignore())
                .ForMember(dest => dest.Appointments, opt => opt.Ignore());
        }
    }
}