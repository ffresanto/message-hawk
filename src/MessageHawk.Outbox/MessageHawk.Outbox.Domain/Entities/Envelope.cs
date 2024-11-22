﻿using MessageHawk.Outbox.Domain.Models;

namespace MessageHawk.Outbox.Domain.Entities
{
    public class Envelope
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime SentDate { get; set; } = DateTime.Now;

        public Envelope ConvertRequestToEntity(EnvelopeRequest request)
        {
            Name = request.Name;
            Message = request.Message;

            return this;
        }
    }
}
