using AppointmentService.Core.Abstractions.Repositories;
using AppointmentService.Core.Dtos;
using AppointmentService.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentService.Controllers
{
    [Route("api/a/schedule/{scheduleId}/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppointmentReadDto>> GetAppointmentsForSchedule(int scheduleId)
        {

            if (!_repository.ScheduleExits(scheduleId))
            {
                return NotFound();
            }

            var appointments = _repository.GetAppointmentsForSchedule(scheduleId);

            return Ok(_mapper.Map<IEnumerable<AppointmentReadDto>>(appointments));
        }

        [HttpGet("{appointmentId}", Name = "GetAppointmentForSchedule")]
        public ActionResult<AppointmentReadDto> GetAppointmentForSchedule(int scheduleId, int appointmentId)
        {
            if (!_repository.ScheduleExits(scheduleId))
            {
                return NotFound();
            }

            var appointment = _repository.GetAppointment(scheduleId, appointmentId);

            if(appointment == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AppointmentReadDto>(appointment));
        }

        [HttpPost]
        public ActionResult<AppointmentReadDto> CreateAppointmentForSchedule(int scheduleId, AppointmentCreateDto appointmentDto)
        {
            if (!_repository.ScheduleExits(scheduleId))
            {
                return NotFound();
            }

            var appointment = _mapper.Map<Appointment>(appointmentDto);

            _repository.CreateAppointment(scheduleId, appointment);
            _repository.SaveChanges();

            var appointmentReadDto = _mapper.Map<AppointmentReadDto>(appointment);

            return CreatedAtRoute(nameof(GetAppointmentForSchedule),
                new { scheduleId, appointmentId = appointmentReadDto.Id}, appointmentReadDto);
        }
    }
}