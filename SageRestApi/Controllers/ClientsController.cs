using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SageRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _client;
        public ClientsController(IClientRepository client)
        {
            _client = client;
        }
        // GET: api/<ClientsController>
        [HttpGet]
        public Client Get()
        {
            Client client = new Client()
            {

            };
            return client;
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(string id)
        {
            return await _client.GetByIdAsync(id);
        }

        // POST api/<ClientsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
