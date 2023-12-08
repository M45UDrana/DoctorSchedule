using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Core.Models
{
    public class Schedule
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ExternalID { get; set; }

        [Required]
        public string DoctorName { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}