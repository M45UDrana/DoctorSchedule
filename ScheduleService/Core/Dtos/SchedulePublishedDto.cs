namespace ScheduleService.Core.Dtos
{
    public class SchedulePublishedDto
    {
        public int Id { get; set; }
        public int DoctorName {get; set; }
        public DateTime StartTime { get; set; }
        public string Event { get; set; }
    }
}