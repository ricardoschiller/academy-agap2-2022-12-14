using Agap2IT.Academy.SuperMarket.Business;
using Agap2IT.Academy.SuperMarket.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Agap2IT.Academy.SuperMarket.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        // GET: api/<ClientsController>
        [HttpGet("GetAllClients")]
        public async Task<List<Client>> GetAllClients()
        {
            var clientsBO = new ClientsBO();

            var opResult = await clientsBO.GetAllClients();

            if (opResult.HasSucceeded)
            {
                return opResult.Result;
            }
            else
            {
                return null;
            }    
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientsController>
        [HttpPost("AddClient")]
        public void Post([FromBody] Client client)
        {
            //adicionar no business
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
