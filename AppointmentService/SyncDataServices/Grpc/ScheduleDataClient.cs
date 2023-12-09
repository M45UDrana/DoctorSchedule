using AppointmentService.Core.Models;
using AutoMapper;
using Grpc.Net.Client;
using ScheduleService;

namespace AppointmentService.SyncDataServices.Grpc
{
    public class ScheduleDataClient : IScheduleDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ScheduleDataClient(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public IEnumerable<Schedule> ReturnAllSchedules()
        {
            var channel = GrpcChannel.ForAddress(_configuration["GrpcSchedule"]);
            var client = new GrpcSchedule.GrpcScheduleClient(channel);
            var request = new GetAllRequest();

            try
            {
                var reply = client.GetAllSchedules(request);
                return _mapper.Map<IEnumerable<Schedule>>(reply.Schedule);
            }
            catch
            {
                return null;
            }
        }
    }
}