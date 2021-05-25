using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SageRestApi.Controllers
{
    [Route("api/sage/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        /// <summary>
        /// Create an invoice
        /// </summary>
        /// <response code="200">Success while creating the invoice</response>
        /// <response code="400">Error while creating the invoice</response>
        /// <response code="401">Bad credentials</response>
        /// <response code="500">Internal server error</response>
        [SwaggerOperation(Tags = new[] { "Create an invoice" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // add model API error
        [Produces(MediaTypeNames.Application.Json)]
        [HttpPost]
        public void CreateInvoice([FromBody] string value)
        {
        }
    }
}