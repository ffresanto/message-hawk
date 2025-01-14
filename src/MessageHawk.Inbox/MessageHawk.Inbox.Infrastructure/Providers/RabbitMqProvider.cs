using MessageHawk.Inbox.Domain.Entities;
using MessageHawk.Inbox.Domain.Interfaces.Providers;
using MessageHawk.Inbox.Domain.Interfaces.Repositories;
using MessageHawk.Inbox.Infrastructure.Configurations;
using MessageHawk.Inbox.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace MessageHawk.Inbox.Infrastructure.Providers
{
    public class RabbitMqProvider : IRabbitMqProvider
    {
        private readonly ConnectionFactory _factory;
        private readonly RabbitMqConfiguration _rabbitMqConfiguration;
        private readonly IEnvelopeRepository _envelopeRepository;

        public RabbitMqProvider(IOptions<RabbitMqConfiguration> rabbitMqConfiguration, IEnvelopeRepository envelopeRepository)
        {
            _envelopeRepository = envelopeRepository;
            _rabbitMqConfiguration = rabbitMqConfiguration.Value;

            _factory = new ConnectionFactory
            {
                HostName = _rabbitMqConfiguration.HostName,
                UserName = _rabbitMqConfiguration.UserName,
                Password = _rabbitMqConfiguration.Password
            };
        }

        public async Task<bool> StartConsuming(string queueName)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var envelope = JsonConvert.DeserializeObject<Envelope>(message);

                if (envelope == null) return;

                await _envelopeRepository.SaveEnvelope(envelope);

            };

            channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

            return await Task.FromResult(true);
        }

    }
}
