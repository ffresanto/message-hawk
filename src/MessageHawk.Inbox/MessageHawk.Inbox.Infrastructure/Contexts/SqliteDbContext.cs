using MessageHawk.Inbox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageHawk.Inbox.Infrastructure.Contexts
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
        {
        }

        public DbSet<Envelope> Envelopes { get; set; }
    }
}
