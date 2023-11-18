using System.ComponentModel.DataAnnotations;

namespace ScheduleService.Core.Dtos
{
    public class ScheduleCreateDto
    {
        [Required]
        public DateTime StartTime { get; set; }
    }
}