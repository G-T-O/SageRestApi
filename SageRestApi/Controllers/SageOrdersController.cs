using System.Threading.Tasks;
using Application.Interfaces.Services;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

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


        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(string id)
        {
            return await _sageOrderService.GetByIdAsync(id);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            return Ok(await _sageOrderService.AddAsync(order));
        }

        [HttpPut]
        public async Task<IActionResult> Put(Order order)
        {
            return Ok(await _sageOrderService.UpdateAsync(order));
        }

        [HttpDelete("{orderNum}")]
        public async Task<IActionResult> Delete(string orderNum)
        {
            return Ok(await _sageOrderService.DeleteAsync(orderNum));
        }
    }
}