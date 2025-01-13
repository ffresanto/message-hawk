using MessageHawk.Inbox.Domain.Entities;

namespace MessageHawk.Inbox.Domain.Interfaces.Repositories
{
    public interface IEnvelopeRepository
    {
        public Task SaveEnvelope(Envelope envelope);

        public Task<List<Envelope>> GetAllEnvelopes();
    }
}
