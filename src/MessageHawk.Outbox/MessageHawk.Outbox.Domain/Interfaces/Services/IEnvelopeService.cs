using MessageHawk.Outbox.Domain.Models;

namespace MessageHawk.Outbox.Domain.Interfaces.Services
{
    public interface IEnvelopeService
    {
        public Task<bool> SendEnvelope(EnvelopeRequest request);
    }
}
