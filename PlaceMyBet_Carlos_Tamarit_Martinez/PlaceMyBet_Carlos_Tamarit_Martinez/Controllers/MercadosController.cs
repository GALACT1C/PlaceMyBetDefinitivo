using PlaceMyBet_Carlos_Tamarit_Martinez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<MercadoDTO> Get()
        {
            var repo = new MercadosRepository();
            //List<Mercado> mercados = repo.Retrieve();
            List<MercadoDTO> mercadosDTO = repo.RetrieveDTO();
            return mercadosDTO;
        }

        // GET: api/Mercados/5
        public Mercado Get(int id)
        {
            /*var repo = new MercadosRepository();
            Mercado m1 = repo.Retrieve();*/
            return null;
        }

        // GET: api/Mercados?id=id
        public List<MercadoApuesta> Obtener(int id)
        {
            var repo = new MercadosRepository();
            List<MercadoApuesta> mca = repo.RetrieveApuesta(id);
            return mca;
        }

        // POST: api/Mercados
        public void Post(Mercado mercado)
        {
            var repo = new MercadosRepository();
            repo.Save(mercado);
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
