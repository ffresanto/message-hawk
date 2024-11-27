using MessageHawk.Outbox.Domain.Interfaces.Services;
using MessageHawk.Outbox.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MessageHawk.Outbox.WebAPI.Controllers
{
    public class MessageController(IEnvelopeService envelopeService) : Controller
    {
        private const string BAD_REQUEST_MESSAGE = "Failed to send the envelope. Please check the provided data and try again.";
        private const string OK_REQUEST_MESSAGE = "The operation was successfully completed. The envelope has been sent.";

        [HttpPost("send-envelope")]
        [SwaggerOperation(Summary = "Send an envelope with the provided data, returning the operation status.")]
        [SwaggerResponse(200, OK_REQUEST_MESSAGE, typeof(string))]
        [SwaggerResponse(400, BAD_REQUEST_MESSAGE, typeof(string))]

        public async Task<ActionResult> PostSendEnvelope([FromBody] EnvelopeRequest request)
        {
            var response = await envelopeService.SendEnvelope(request);

            if (!response) return BadRequest(BAD_REQUEST_MESSAGE);

            return Ok(OK_REQUEST_MESSAGE);
        }
    }
}
