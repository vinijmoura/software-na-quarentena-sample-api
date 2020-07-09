using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwNaQuarentena.Api.Repositories;

namespace SwNaQuarentena.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaySomethingController : ControllerBase
    {
        private readonly ILogger<SaySomethingController> _logger;
        public SaySomethingController(ILogger<SaySomethingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{personName}/quote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetQuoteByPersonName([FromServices] IQuoteRepository quoteRepository
            , [FromRoute] string personName)
        {
            string quote = quoteRepository.GetAQuoteByPersonName(personName);
            return string.IsNullOrEmpty(quote) ? (IActionResult) NotFound() : Ok(quote);
        }
            

    }
}
