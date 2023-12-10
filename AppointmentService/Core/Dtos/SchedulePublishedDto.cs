namespace AppointmentService.Core.Dtos
{
    public class SchedulePublishedDto
    {
        public int Id { get; set; }
        public string DoctorName {get; set; }
        public DateTime StartTime { get; set; }
        public string Event { get; set; }
    }
}