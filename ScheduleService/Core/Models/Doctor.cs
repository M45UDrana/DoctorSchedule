using System.ComponentModel.DataAnnotations;

namespace ScheduleService.Core.Models
{
    public class Doctor
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ChamberAddress { get; set; }
        
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}