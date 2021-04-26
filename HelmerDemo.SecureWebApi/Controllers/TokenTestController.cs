using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelmerDemo.SecureWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenTestController : ControllerBase
    {
        // GET: api/<TokenTestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TokenTestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TokenTestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TokenTestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TokenTestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
