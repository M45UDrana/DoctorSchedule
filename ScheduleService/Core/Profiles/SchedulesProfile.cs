using AutoMapper;
using ScheduleService.Core.Dtos;
using ScheduleService.Core.Models;

namespace ScheduleService.Core.Profiles
{
    public class SchedulesProfile : Profile
    {
        public SchedulesProfile()
        {
            // Source -> Destination
            CreateMap<Doctor, DoctorReadDto>();
            CreateMap<DoctorCreateDto, Doctor>();
            CreateMap<Schedule, ScheduleReadDto>();
            CreateMap<ScheduleCreateDto, Schedule>();
            CreateMap<ScheduleReadDto, SchedulePublishedDto>();
            CreateMap<Schedule, GrpcScheduleModel>()
                .ForMember(dest => dest.ScheduleId, opt => opt.MapFrom(src =>src.Id));
        }
    }
}