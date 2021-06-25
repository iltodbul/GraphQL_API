using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GraphQL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        // GET: api/<DemoController>
        [HttpGet]
        public ActionResult<IEnumerable<Demo>> Get()
        {
            var demo = new Demo()
            {
                Id = 123,
                CreatedIn = DateTime.Now,
                Name = "Demo Product1",
                IsAvailable = true
            };
            return new List<Demo> {demo, demo, demo};

        }

        // GET api/<DemoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DemoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DemoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DemoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Ako imashe baza shteshe da e iztrito.";
        }
    }
}
