using System.Collections.Generic;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class Persona
    {
        public string id { get; set; }
        public string nombre { get; set; }
    }
    [Authorize]
    public class ValuesController : ApiController
    {  // GET api/values
        [HttpGet]
        public IList<Persona> Get()
        {
            var personas = new List<Persona> {
                new Persona { id = "1", nombre = "nombre" },
                new Persona { id = "1", nombre = "nombre" }
            };
            return personas;
        }

        // GET api/values/5
        [HttpGet]
        public Persona Get(int id)
        {
            var result = new Persona { id = id.ToString(), nombre = "nombre" };
            return result;
        }

        // POST api/values
        [HttpPost]
        public IHttpActionResult Post([FromBody] Persona value)
        {
            return RedirectToRoute("GetID", new { id = value.id });
        }

        // PUT api/values/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Persona value)
        {
            return RedirectToRoute("GetID", new { id = id });
        }

        // DELETE api/values/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(id);
        }
    }
}
