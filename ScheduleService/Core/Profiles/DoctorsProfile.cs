using AutoMapper;
using ScheduleService.Core.Dtos;
using ScheduleService.Core.Models;

namespace ScheduleService.Core.Profiles
{
    public class DoctorsProfile : Profile
    {
        public DoctorsProfile()
        {
            // Source -> Target
            CreateMap<Doctor, DoctorReadDto>();
            CreateMap<DoctorCreateDto, Doctor>();
        }
    }
}