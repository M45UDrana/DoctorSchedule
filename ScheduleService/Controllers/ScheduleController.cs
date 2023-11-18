using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Core.Abstractions.Repositories;
using ScheduleService.Core.Dtos;
using ScheduleService.Core.Models;

namespace ScheduleService.Controllers
{
    [Route("api/Doctor/{doctorId}/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _repository;
        private readonly IMapper _mapper;

        public ScheduleController(IScheduleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ScheduleReadDto>> GetSchedulesForDoctor(int doctorId)
        {
            if (!_repository.DoctorExits(doctorId))
            {
                return NotFound();
            }

            var Schedules = _repository.GetSchedulesForDoctor(doctorId);

            return Ok(_mapper.Map<IEnumerable<ScheduleReadDto>>(Schedules));
        }

        [HttpGet("{scheduleId}", Name = "GetScheduleForDoctor")]
        public ActionResult<ScheduleReadDto> GetScheduleForDoctor(int doctorId, int scheduleId)
        {
            if (!_repository.DoctorExits(doctorId))
            {
                return NotFound();
            }

            var schedule = _repository.GetSchedule(doctorId, scheduleId);

            if(schedule == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ScheduleReadDto>(schedule));
        }

        [HttpPost]
        public ActionResult<ScheduleReadDto> CreateScheduleForDoctor(int doctorId, ScheduleCreateDto scheduleDto)
        {

            if (!_repository.DoctorExits(doctorId))
            {
                return NotFound();
            }

            var schedule = _mapper.Map<Schedule>(scheduleDto);

            _repository.CreateSchedule(doctorId, schedule);
            _repository.SaveChanges();

            var scheduleReadDto = _mapper.Map<ScheduleReadDto>(schedule);

            return CreatedAtRoute(nameof(GetScheduleForDoctor),
                new { doctorId, scheduleId = scheduleReadDto.Id}, scheduleReadDto);
        }
    }
}