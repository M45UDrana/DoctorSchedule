using AutoMapper;
using ScheduleService.Core.Dtos;
using ScheduleService.Core.Models;

namespace ScheduleService.Core.Profiles
{
    public class SchedulesProfile : Profile
    {
        public SchedulesProfile()
        {
            // Source -> Target
            CreateMap<Schedule, ScheduleReadDto>();
            CreateMap<ScheduleCreateDto, Schedule>();
        }
    }
}