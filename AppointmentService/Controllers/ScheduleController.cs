using AppointmentService.Core.Abstractions.Repositories;
using AppointmentService.Core.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentService.Controllers
{
    [Route("api/a/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public ScheduleController(IAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ScheduleReadDto>> GetSchedules()
        {
            var scheduleItems = _repository.GetAllSchedules();

            return Ok(_mapper.Map<IEnumerable<ScheduleReadDto>>(scheduleItems));
        }
    }
}