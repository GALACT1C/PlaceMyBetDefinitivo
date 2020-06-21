using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Models
{
    public class EventosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Port=3306;Database=placemybet;Uid=root;SslMode=none";
            MySql.Data.MySqlClient.MySqlConnection con = new MySqlConnection(connString);

            return con;
        }
        internal List<Evento> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from evento";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Evento e = null;
                List<Evento> eventos = new List<Evento>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2));
                    e = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2));
                    eventos.Add(e);
                }
                con.Close();
                return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }

        internal List<EventoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from evento";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                EventoDTO et = null;
                List<EventoDTO> eventosDTO = new List<EventoDTO>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + " " + res.GetString(1) + " " + res.GetString(2));
                    et = new EventoDTO(res.GetString(1), res.GetString(2));
                    eventosDTO.Add(et);
                }
                con.Close();
                return eventosDTO;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }

        internal void Save(Evento e)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into evento(N_Evento,Nombre_Equipo_Visitante,Nombre_Equipo_Local) values('" + e.NºEvento +  "','" + e.Nombre_Equipo_Visitante + "','" + e.Nombre_Equipo_Local + "');'";
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }

        internal List<Evento> RetrievebyId(int NºEvento)
        {
            var repo = new EventosRepository();
            List<Evento> eventos = repo.RetrievebyId(NºEvento);
            return eventos;
        }

        internal List<MercadoCuota> ObtencionCuota(int id)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select Tipo_Mercado,Cuota_Over,Cuota_Under,Id_Evento from mercado inner join evento on mercado.id_evento = evento.id_evento where N_Evento = " + id;

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoCuota mc = null;
                List<MercadoCuota> mercuo = new List<MercadoCuota>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetDouble(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2));
                    mc = new MercadoCuota(res.GetDouble(0), res.GetDouble(1), res.GetDouble(2));
                    mercuo.Add(mc);
                }
                con.Close();
                return mercuo;
            }
            catch (MySqlException mc)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }

    }
}