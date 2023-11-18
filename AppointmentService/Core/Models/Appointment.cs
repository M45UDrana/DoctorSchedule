using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Core.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public int Id { get; set; }
        

        [Required]
        public int ScheduleId { get; set; }

        [Required]
        public string PatientName { get; set; }

        public Schedule Schedule { get; set; }
    }
}