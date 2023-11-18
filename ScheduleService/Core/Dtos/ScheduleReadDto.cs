namespace ScheduleService.Core.Dtos
{
    public class ScheduleReadDto
    {
        public int Id { get; set; }
        public int DoctorId {get; set; }
        public DateTime StartTime { get; set; }
    }
}