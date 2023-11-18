namespace AppointmentService.Core.Dtos
{
    public class AppointmentReadDto
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public string PatientName { get; set; }
    }
}