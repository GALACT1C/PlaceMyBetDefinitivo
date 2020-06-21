using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Models
{
    public class MercadosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Port=3306;Database=placemybet;Uid=root;SslMode=none";
            MySql.Data.MySqlClient.MySqlConnection con = new MySqlConnection(connString);

            return con;
        }
        internal List<Mercado> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
                List<Mercado> mercados = new List<Mercado>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));
                    m = new Mercado(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
                    mercados.Add(m);
                }
                con.Close();
                return mercados;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }

        internal List<MercadoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoDTO mt = null;
                List<MercadoDTO> mercadosDTO = new List<MercadoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetDouble(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetInt32(5));
                    mt = new MercadoDTO(res.GetDouble(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetInt32(5));
                    mercadosDTO.Add(mt);
                }
                con.Close();
                return mercadosDTO;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }

        internal List<MercadoApuesta> RetrieveApuesta(int id)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select dni_cliente,mercado,overunder,cuota,dinero_apostado from mercado inner join apuesta on mercado = id_mercado where id_mercado = " + id;

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoApuesta ma = null;
                List<MercadoApuesta> merapu = new List<MercadoApuesta>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetDouble(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4));
                    ma = new MercadoApuesta(res.GetString(0), res.GetDouble(1), res.GetBoolean(2), res.GetDouble(3), res.GetDouble(4));
                    merapu.Add(ma);
                }
                con.Close();
                return merapu;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }

        internal void Save(Mercado m)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into mercado(id_Mercado,Tipo_Mercado,Cuota_Over,Cuota_Under,Apostado_Over,Apostado_Under, id_Evento) values('" + m.id_Mercado + "','" + m.Tipo_Mercado + "','" + m.Cuota_Over + "','" + m.Cuota_Under + "','" +  m.Apostado_Over + "','" + m.Apostado_Under + "','" + m.Id_Evento + "');'";
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        } 

        internal List<Mercado> RetrievebyId(int id_Mercado)
        {
            var repo = new MercadosRepository();
            List<Mercado> mercados = repo.RetrievebyId(id_Mercado);
            return mercados;
        }
    }
}