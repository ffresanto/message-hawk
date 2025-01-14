namespace MessageHawk.Inbox.Domain.Interfaces.Providers
{
    public interface IRabbitMqProvider
    {
        public Task<bool> StartConsuming(string queueName);
    }
}
