using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Models
{
    public class ClientesRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Port=3306;Database=placemybet;Uid=root;SslMode=none";
            MySql.Data.MySqlClient.MySqlConnection con = new MySqlConnection(connString);

            return con;
        }

        internal List<ApuestaCliente> Obtener(string email)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select dinero_apostado,tipo_mercado,cuota,overunder ,N_Evento, from evento inner join mercado inner join apuesta on mercado.id_mercado = apuesta.mercado on mercado.id_mercado = evento.mercado_idmercado where email = '" + email + "'" ;

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaCliente apucli = null;
                List<ApuestaCliente> apcl = new List<ApuestaCliente>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetString(2) + " " + res.GetBoolean(3) + " " + res.GetDouble(4));
                    apucli = new ApuestaCliente(res.GetInt32(0), res.GetInt32(1), res.GetString(2), res.GetBoolean(3), res.GetDouble(4));
                    apcl.Add(apucli);
                }
                con.Close();
                return apcl;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }

        internal List<Cliente> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from cliente";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Cliente e = null;

            List<Cliente> Clientes = new List<Cliente>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3) + " " + res.GetInt32(4) + " " + res.GetString(5));
                e = new Cliente(res.GetString(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetInt32(4), res.GetString(5));
                Clientes.Add(e);
            }
            return Clientes;
        }
    }
}