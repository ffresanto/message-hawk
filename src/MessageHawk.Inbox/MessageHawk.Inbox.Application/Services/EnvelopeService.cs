using MessageHawk.Inbox.Domain.Entities;
using MessageHawk.Inbox.Domain.Interfaces.Repositories;
using MessageHawk.Inbox.Domain.Interfaces.Services;

namespace MessageHawk.Inbox.Application.Services
{
    public class EnvelopeService(IEnvelopeRepository envelopeRepository) : IEnvelopeService
    {
        public Task<List<Envelope>> GetEnvelopes()
        {
            return envelopeRepository.GetAllEnvelopes();
        }
    }
}
