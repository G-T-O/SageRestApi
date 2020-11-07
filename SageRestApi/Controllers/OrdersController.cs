using System.Threading.Tasks;
using Application.Interfaces.Services;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SageRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private ISageOrderService _sageOrderService;
        public OrdersController(ISageOrderService sageOrderService)
        {
            _sageOrderService = sageOrderService;
        }

        // POST api/<ClientsController>
        [HttpPost]
        public async Task<IActionResult> AddClient(Order order)
        {
            return Ok(await _sageOrderService.AddAsync(order));
        }

        // PUT api/<ClientsController>/5
        [HttpPut]
        public async Task<IActionResult> Put(Order order)
        {
            return Ok(await _sageOrderService.UpdateAsync(order));
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{ct_Num}")]
        public async Task<IActionResult> Delete(string orderNum)
        {
            return Ok(await _sageOrderService.DeleteAsync(orderNum));
        }
    }
}