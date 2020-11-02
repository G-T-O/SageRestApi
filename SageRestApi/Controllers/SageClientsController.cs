using System.Threading.Tasks;
using Application.Interfaces.Sage.Repositories;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SageRestApi.Controllers
{
    [Route("api/sage/[controller]")]
    [ApiController]
    public class SageClientsController : ControllerBase
    {
        private readonly ISageClientRepository _client;
        public SageClientsController(ISageClientRepository client)
        {
            _client = client;
        }
        // GET: api/<ClientsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _client.GetAllAsync());
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(string id)
        {
            return await _client.GetByIdAsync(id);
        }

        // POST api/<ClientsController>
        [HttpPost]
        public async Task<IActionResult> AddClient(Client client)
        {
            return Ok(await _client.AddAsync(client));
        }

        // PUT api/<ClientsController>/5
        [HttpPut]
        public async Task<IActionResult> Put(Client client)
        {
            return Ok(await _client.UpdateAsync(client));
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{ct_Num}")]
        public async Task<IActionResult> Delete(string ct_Num)
        {
            return Ok(await _client.DeleteAsync(ct_Num));
        }
    }
}