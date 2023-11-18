using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Core.Dtos
{
    public class AppointmentCreateDto
    {
        [Required]
        public string PatientName { get; set; }
    }
}