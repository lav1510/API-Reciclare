using Microsoft.AspNetCore.Mvc;
using RecicalreApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecicalreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainereController : ControllerBase
    {
        private static IList<Container> Containere = new List<Container>();

        // GET: api/<StationsController>
        [HttpGet]
        public IEnumerable<Container> Get()
        {
            return Containere;
        }

        // GET api/<StationsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var container = Containere.FirstOrDefault(s => s.Id == id);

            if (container == null)
                return NotFound();

            return Ok(container);
        }

        // POST api/<StationsController>
        [HttpPost]
        public IActionResult Post([FromBody] Container container)
        {
            //var a  = Stations.FirstOrDefault(s => s.Id == station.Id) != null;
            //var b = Stations.Any(s => s.Id == station.Id);

            if (Containere.Any(s => s.Id == container.Id))
                return BadRequest($"Station with {container.Id} already exist");

            Containere.Add(container);
            return CreatedAtAction("Get", container.Id);
        }

        // PUT api/<StationsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Container newContainerData)
        {
            var container = Containere.FirstOrDefault(s => s.Id == id);
            if (container == null)
                return NotFound();

            newContainerData.Id = id;
            Containere[Containere.IndexOf(container)] = newContainerData;

            return Ok(Containere[Containere.IndexOf(container)]);
        }

        // DELETE api/<StationsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var container = Containere.FirstOrDefault(s => s.Id == id);
            if (container != null)
                Containere.Remove(container);
            return Ok();
        }
    }
}