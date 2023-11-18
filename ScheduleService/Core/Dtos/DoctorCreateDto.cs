
using System.ComponentModel.DataAnnotations;

namespace ScheduleService.Core.Dtos
{
    public class DoctorCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ChamberAddress { get; set; }
    }
}