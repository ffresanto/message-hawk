using MessageHawk.Outbox.Domain.Entities;
using MessageHawk.Outbox.Domain.Interfaces.Providers;
using MessageHawk.Outbox.Domain.Interfaces.Services;
using MessageHawk.Outbox.Domain.Models;

namespace MessageHawk.Outbox.Application.Services
{
    public class EnvelopeService(IRabbitMqProvider rabbitMqProvider) : IEnvelopeService
    {
        public async Task<bool> SendEnvelope(EnvelopeRequest request)
        {
            var envelope = new Envelope().ConvertRequestToEntity(request);

            await rabbitMqProvider.PublishMessageAsync<Envelope>(envelope, "message-hawk-outbox");

            return true;
        }
    }
}
