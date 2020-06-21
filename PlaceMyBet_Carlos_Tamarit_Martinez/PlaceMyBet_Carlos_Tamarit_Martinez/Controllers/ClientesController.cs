using System;
using System.Collections.Generic;
using System.Linq;
using PlaceMyBet_Carlos_Tamarit_Martinez.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Controllers
{
    public class ClientesController : ApiController
    {
        // GET: api/Clientes
        public IEnumerable<Cliente> Get()
        {
            var repo = new Models.ClientesRepository();
            List<Cliente> a = repo.Retrieve();
            return a;
        }

        // GET: api/Clientes/5
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/Clientes?email=email
        public List<ApuestaCliente> Obtener(string email)
        {
            var repo = new ClientesRepository();
            List<ApuestaCliente> apc = repo.Obtener(email);
            return apc;
        }

        // POST: api/Clientes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
        }
    }
}
