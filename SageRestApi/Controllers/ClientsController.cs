using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading.Tasks;
using Application.IServices;
using Core.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SageRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService client)
        {
            _clientService = client;
        }

        /// <summary>
        /// Retrieve Sage client informations from a Sage Code
        /// </summary>
        /// <response code="200">Success while retrieving the client</response>
        /// <response code="400">Error while retrieving the client</response>
        /// <response code="401">Bad credentials</response>
        /// <response code="500">Internal server error</response>
        [SwaggerOperation(Tags = new[] { "Informations client" })]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // add model API error
        [Produces(MediaTypeNames.Application.Json)]
        [HttpGet]
        public async Task<ActionResult<Client>> GetClient([Required] string sageCode)
        {
            return await _clientService.GetByIdAsync(sageCode);
        }

        /// <summary>
        /// Create a client and retrieve it's new Sage code
        /// </summary>
        /// <response code="200">Success while creating the client</response>
        /// <response code="400">Error while creating the client</response>
        /// <response code="401">Bad credentials</response>
        /// <response code="500">Internal server error</response>
        [SwaggerOperation(Tags = new[] { "Informations client" })]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // add model API error
        [Produces(MediaTypeNames.Application.Json)]
        [HttpPost]
        public async Task<IActionResult> CreateClient(Client client)
        {
            return Ok(_clientService.Create(client));
        }

        /// <summary>
        /// Update a client
        /// </summary>
        /// <response code="200">Success while updating the client</response>
        /// <response code="400">Error while updating the client</response>
        /// <response code="401">Bad credentials</response>
        /// <response code="500">Internal server error</response>
        [SwaggerOperation(Tags = new[] { "Informations client" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // add model API error
        [Produces(MediaTypeNames.Application.Json)]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(Client client)
        {
            return Ok(_clientService.Update(client));
        }

        /// <summary>
        /// Delete a client with a Sage code
        /// </summary>
        /// <response code="200">Success while deleting the client</response>
        /// <response code="400">Error while deleting the client</response>
        /// <response code="401">Bad credentials</response>
        /// <response code="500">Internal server error</response>
        [SwaggerOperation(Tags = new[] { "Informations client" })]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // add model API error
        [Produces(MediaTypeNames.Application.Json)]
        [HttpDelete("{ct_Num}")]
        public async Task<IActionResult> DeleteClient(string ct_Num)
        {
            return Ok(_clientService.Delete(ct_Num));
        }
    }
}