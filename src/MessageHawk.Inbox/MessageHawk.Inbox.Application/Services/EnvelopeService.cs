using MessageHawk.Inbox.Domain.Entities;
using MessageHawk.Inbox.Domain.Interfaces.Repositories;
using MessageHawk.Inbox.Domain.Interfaces.Services;

namespace MessageHawk.Inbox.Application.Services
{
    public class EnvelopeService(IEnvelopeRepository envelopeRepository) : IEnvelopeService
    {
        public async Task<List<Envelope>> GetEnvelopes()
        {
            return await envelopeRepository.GetAllEnvelopes();
        }

        public async Task SaveEnvelope(Envelope envelope)
        {
            await envelopeRepository.SaveEnvelope(envelope);
        }
    }
}
