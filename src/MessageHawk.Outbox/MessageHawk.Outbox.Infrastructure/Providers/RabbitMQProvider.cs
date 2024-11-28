using MessageHawk.Outbox.Domain.Interfaces.Providers;
using RabbitMQ.Client;

namespace MessageHawk.Outbox.Infrastructure.Providers
{
    public class RabbitMqProvider : IRabbitMqProvider
    {
        public Task PublishMessageAsync<T>(T message)
        {
            throw new NotImplementedException();
        }
    }
}
