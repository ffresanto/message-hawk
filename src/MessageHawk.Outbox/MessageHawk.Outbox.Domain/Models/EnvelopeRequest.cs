namespace MessageHawk.Outbox.Domain.Models
{
    public class EnvelopeRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
