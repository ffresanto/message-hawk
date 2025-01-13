using MessageHawk.Inbox.Domain.Entities;
using MessageHawk.Inbox.Domain.Interfaces.Repositories;
using MessageHawk.Inbox.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MessageHawk.Inbox.Infrastructure.Repositories
{
    public class EnvelopeRepository : IEnvelopeRepository
    {
        private readonly SqliteDbContext _context;

        public EnvelopeRepository(SqliteDbContext context)
        {
            _context = context;
        }

        public async Task<List<Envelope>> GetAllEnvelopes()
        {
            return await _context.Envelopes.ToListAsync();
        }

        public async Task SaveEnvelope(Envelope envelope)
        {
            await _context.Envelopes.AddAsync(envelope);
        }
    }
}
