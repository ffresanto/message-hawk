using MessageHawk.Inbox.Domain.Entities;

namespace MessageHawk.Inbox.Domain.Interfaces.Services
{
    public interface IEnvelopeService
    {
        public Task<List<Envelope>> GetEnvelopes();
    }
}
