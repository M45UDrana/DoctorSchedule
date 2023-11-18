using System.ComponentModel.DataAnnotations;

namespace ScheduleService.Core.Models
{
    public class Schedule
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
        
        public Doctor Doctor { get; set;}
    }
}