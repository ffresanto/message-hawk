namespace MessageHawk.Outbox.Domain.Interfaces.Providers
{
    public interface IRabbitMqProvider
    {
        public Task PublishMessageAsync<T>(T message);
    }
}
