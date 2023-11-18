using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Core.Abstractions.Repositories;
using ScheduleService.Core.Dtos;
using ScheduleService.Core.Models;

namespace ScheduleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DoctorReadDto>> GetDoctors()
        {

            var doctorItem = _repository.GetAllDoctors();

            return Ok(_mapper.Map<IEnumerable<DoctorReadDto>>(doctorItem));
        }

        [HttpGet("{id}", Name = "GetDoctorById")]
        public ActionResult<DoctorReadDto> GetDoctorById(int id)
        {
            var doctorItem = _repository.GetDoctorById(id);
            if (doctorItem != null)
            {
                return Ok(_mapper.Map<DoctorReadDto>(doctorItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<DoctorReadDto> CreateDoctor(DoctorCreateDto doctorCreateDto)
        {
            var doctorModel = _mapper.Map<Doctor>(doctorCreateDto);
            _repository.CreateDoctor(doctorModel);
            _repository.SaveChanges();

            var doctorReadDto = _mapper.Map<DoctorReadDto>(doctorModel);

            return CreatedAtRoute(nameof(GetDoctorById), new { Id = doctorReadDto.Id}, doctorReadDto);
        } 
    }
}