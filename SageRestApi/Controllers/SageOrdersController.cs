using System.Net.Mime;
using System.Threading.Tasks;
using Application.IServices;
using Core.Dto.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SageRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SageOrdersController : ControllerBase
    {
        private readonly ISageOrderService _sageOrderService;
        public SageOrdersController(ISageOrderService sageOrderService)
        {
            _sageOrderService = sageOrderService;
        }
        /// <summary>
        /// Create an order
        /// </summary>
        /// <response code="200">Success while creating the order</response>
        /// <response code="400">Error while creating the order</response>
        /// <response code="401">Bad credentials</response>
        /// <response code="500">Internal server error</response>
        [SwaggerOperation(Tags = new[] { "Order" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // add model API error
        [Produces(MediaTypeNames.Application.Json)]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderRequest order)
        {
            return Ok(await _sageOrderService.Create(order));
        }

        /// <summary>
        /// Delete an order from an ID
        /// </summary>
        /// <response code="200">Success while deleting the order</response>
        /// <response code="400">Error while deleting the order</response>
        /// <response code="401">Bad credentials</response>
        /// <response code="500">Internal server error</response>
        [SwaggerOperation(Tags = new[] { "Order" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // add model API error
        [Produces(MediaTypeNames.Application.Json)]
        [HttpDelete("{orderCode}")]
        public async Task<IActionResult> DeleteOrder(string orderCode)
        {
            return Ok(await _sageOrderService.Delete(orderCode));
        }
    }
}