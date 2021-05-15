using System.Threading.Tasks;
using Application.IServices;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(string id)
        {
            
            return await _clientService.GetByIdAsync(id);
        }

        // POST api/<ClientsController>
        [HttpPost]
        public async Task<IActionResult> AddClient(Client client)
        {
            return Ok(await _clientService.AddAsync(client));
        }

        // PUT api/<ClientsController>/5
        [HttpPut]
        public async Task<IActionResult> Put(Client client)
        {
            return Ok(await _clientService.UpdateAsync(client));
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{ct_Num}")]
        public async Task<IActionResult> Delete(string ct_Num)
        {
            return Ok(await _clientService.DeleteAsync(ct_Num));
        }
    }
}