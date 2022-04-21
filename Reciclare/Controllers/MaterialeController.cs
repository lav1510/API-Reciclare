using Microsoft.AspNetCore.Mvc;
using RecicalreApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecicalreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialeController : ControllerBase
    {
        private static IList<Material> Materiale = new List<Material>();

        // GET: api/<StationsController>
        [HttpGet]
        public IEnumerable<Material> Get()
        {
            return Materiale;
        }

        // GET api/<StationsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var material = Materiale.FirstOrDefault(s => s.Id == id);

            if (material == null)
                return NotFound();

            return Ok(material);
        }

        // POST api/<StationsController>
        [HttpPost]
        public IActionResult Post([FromBody] Material material)
        {
            //var a  = Stations.FirstOrDefault(s => s.Id == station.Id) != null;
            //var b = Stations.Any(s => s.Id == station.Id);

            if (Materiale.Any(s => s.Id == material.Id))
                return BadRequest($"Station with {material.Id} already exist");

            Materiale.Add(material);
            return CreatedAtAction("Get", material.Id);
        }

        // PUT api/<StationsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Material newMaterialData)
        {
            var material = Materiale.FirstOrDefault(s => s.Id == id);
            if (material == null)
                return NotFound();

            newMaterialData.Id = id;
            Materiale[Materiale.IndexOf(material)] = newMaterialData;

            return Ok(Materiale[Materiale.IndexOf(material)]);
        }

        // DELETE api/<StationsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var material = Materiale.FirstOrDefault(s => s.Id == id);
            if (material != null)
                Materiale.Remove(material);
            return Ok();
        }
    }
}
