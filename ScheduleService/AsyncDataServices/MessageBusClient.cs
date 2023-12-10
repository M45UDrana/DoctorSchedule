using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using ScheduleService.Core.Dtos;

namespace ScheduleService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        //Host and Port from config file
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"])
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            }
            catch
            {
                throw new Exception();
            }
        }

        public void PublishNewSchedule(SchedulePublishedDto schedulePublishedDto)
        {
            var message = JsonSerializer.Serialize(schedulePublishedDto);

            if (_connection.IsOpen)
            {
                SendMessage(message);
            } 
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "trigger",
                            routingKey: "",
                            basicProperties: null,
                            body: body);
        }

        public void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }
    }
}