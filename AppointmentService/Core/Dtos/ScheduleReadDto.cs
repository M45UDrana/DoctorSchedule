namespace AppointmentService.Core.Dtos
{
    public class ScheduleReadDto
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public DateTime StartTime { get; set; }
    }
}