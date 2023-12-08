using AutoMapper;
using Grpc.Core;
using ScheduleService.Core.Abstractions.Repositories;

namespace ScheduleService.SyncDataServices.Grpc
{
    public class GrpcScheduleService : GrpcSchedule.GrpcScheduleBase
    {
        private readonly IScheduleRepository _repository;
        private readonly IMapper _mapper;

        public GrpcScheduleService(IScheduleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override Task<ScheduleResponse> GetAllSchedules(GetAllRequest request, ServerCallContext context)
        {
            var response = new ScheduleResponse();
            var schedules = _repository.GetAllSchedules();

            foreach(var schedule in schedules)
            {
                var grpcScheduleModel = _mapper.Map<GrpcScheduleModel>(schedule);
                grpcScheduleModel.DoctorName = "Add Doctor Name By Id"; //TODO
                response.Schedule.Add(grpcScheduleModel);
            }

            return Task.FromResult(response);
        }
    }
}