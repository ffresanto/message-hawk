using MessageHawk.Inbox.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MessageHawk.Inbox.WebAPI.Controllers
{
    public class MessageController(IEnvelopeService envelopeService) : Controller
    {
        [HttpGet("get-all-envelope")]
        [SwaggerOperation(Summary = "Returns all envelopes saved in the database.")]
        public async Task<ActionResult> GetAllEnvelope()
        {
            return Ok(await envelopeService.GetEnvelopes());
        }
    }
}
