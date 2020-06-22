using PlaceMyBet_Carlos_Tamarit_Martinez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Controllers
{
    //[Authorize]
    //(Roles = "Admin")
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<ApuestaDTO> Get()
        {
            var repo = new ApuestasRepository();
            //List<Apuesta> apuestas = repo.Retrieve();
            List<ApuestaDTO> apuestasDTO = repo.RetrieveDTO();
            return apuestasDTO;
        }

        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            /*var repo = new ApuestasRepository();
            Apuesta a1 = repo.Retrieve();*/
            return null;
        }

        // POST: api/Apuestas
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestasRepository();
            repo.Save(apuesta);
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
