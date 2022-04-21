using Microsoft.AspNetCore.Mvc;
using RecicalreApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReciclareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduseController : ControllerBase
    {
        private static IList<Produse> Produse = new List<Produse>();

        // GET: api/<StationsController>
        [HttpGet]
        public IEnumerable<Produse> Get()
        {
            return Produse;
        }

        // GET api/<StationsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produs = Stations.FirstOrDefault(s => s.Id == id);

            if (produs == null)
                return NotFound();

            return Ok(produs);
        }

        // POST api/<StationsController>
        [HttpPost]
        public IActionResult Post([FromBody] Produs produs)
        {
            //var a  = Stations.FirstOrDefault(s => s.Id == station.Id) != null;
            //var b = Stations.Any(s => s.Id == station.Id);

            if (Produse.Any(s => s.Id == produs.Id))
                return BadRequest($"Station with {station.Id} already exist");

            Produse.Add(station);
            return CreatedAtAction("Get", produs.Id);
        }

        // PUT api/<StationsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produs newProdusData)
        {
            var produs = Produse.FirstOrDefault(s => s.Id == id);
            if (produs == null)
                return NotFound();

            newProdusData.Id = id;
            Produse[Produse.IndexOf(station)] = newProdusData;

            return Ok(Produse[Produse.IndexOf(produs)]);
        }

        // DELETE api/<StationsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produs = Produse.FirstOrDefault(s => s.Id == id);
            if (produs != null)
                Produse.Remove(produs);
            return Ok();
        }
    }
}
