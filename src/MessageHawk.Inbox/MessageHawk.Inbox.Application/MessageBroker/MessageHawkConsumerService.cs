using MessageHawk.Inbox.Domain.Interfaces.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageHawk.Inbox.Application.MessageBroker
{
    public class MessageHawkConsumerService(IRabbitMqProvider rabbitMqProvider,IServiceScopeFactory serviceScopeFactory) : BackgroundService
    {
        private const string QUEUE_NAME = "message-hawk-outbox";

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    await rabbitMqProvider.StartConsuming(QUEUE_NAME);
                }

                await Task.Delay(1000, stoppingToken);  
            }
        }
    }
}
