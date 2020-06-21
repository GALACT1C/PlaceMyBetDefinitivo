using System;
using System.Collections.Generic;
using PlaceMyBet_Carlos_Tamarit_Martinez.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<EventoDTO> Get()
        {
            var repo = new EventosRepository();
            //List<Evento> eventos = repo.Retrieve();
            List<EventoDTO> eventosDTO = repo.RetrieveDTO();
            return eventosDTO;
        }

        // GET: api/Eventos/5
        public Evento Get(int id)
        {
            /*var repo = new EventosRepository();
            Evento e1 = repo.Retrieve();*/
            return null;
        }

        // GET: api/Eventos?id=id
        public List <MercadoCuota> Obtener(int id)
        {
            var repo = new EventosRepository();
            List <MercadoCuota> lmc = repo.ObtencionCuota(id);
            return lmc;
        }

        // POST: api/Eventos
        public void Post([FromBody]Evento evento)
        {
            var repo = new EventosRepository();
            repo.Save(evento);
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
