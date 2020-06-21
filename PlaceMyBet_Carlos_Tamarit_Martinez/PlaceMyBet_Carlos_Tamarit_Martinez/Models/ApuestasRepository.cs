using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Models
{
    public class ApuestasRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server = localhost; Port = 3306; Database = placemybet; Uid = root; SslMode = none";
            MySql.Data.MySqlClient.MySqlConnection con = new MySqlConnection(connString);

            return con;
        }
        internal List<Apuesta> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuesta";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta d = null;
                List <Apuesta> apuestas = new List<Apuesta>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetInt32(2) + " " + res.GetString(3) + " " + res.GetBoolean(4) + " " + res.GetString(5));
                    d = new Apuesta(res.GetInt32(0), res.GetDouble(1), res.GetInt32(2), res.GetString(3), res.GetBoolean(4), res.GetString(5));
                    apuestas.Add(d);
                }
                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }

        internal List<ApuestaDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuesta";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO dt = null;
                List<ApuestaDTO> apuestasDTO = new List<ApuestaDTO>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetDouble(0) + " " + res.GetInt32(1) + " " + res.GetString(2) + " " + res.GetBoolean(3) + " " + res.GetString(4));
                    dt = new ApuestaDTO(res.GetDouble(0), res.GetInt32(1), res.GetString(2), res.GetBoolean(3), res.GetString(4));
                    apuestasDTO.Add(dt);
                }
                con.Close();
                return apuestasDTO;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }

        internal void Save(Apuesta a)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");

            culInfo.NumberFormat.NumberDecimalSeparator = ".";

            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into apuesta(Dinero_Apostado,Cuota,OverUnder,Mercado,DNI_Cliente) values(" + a.Dinero_Apostado + "," + a.Cuota + "," + a.OverUnder + "," + a.Mercado + ",'" + a. DNI_Cliente + "');";
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

            if (a.OverUnder == true)
            {
                command.CommandText = "update mercado set Apostado_Over = Apostado_Over+" + a.Dinero_Apostado + " where id_Mercado=" + a.Mercado;
            }
            else
            {
                command.CommandText = "update mercado set Apostado_Under = Apostado_Under+" + a.Dinero_Apostado + " where id_Mercado=" + a.Mercado;
            }
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

            command.CommandText = "select Apostado_Over,Apostado_Under from mercado where id_Mercado+" + a.Mercado + ";";
            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            double Probabilidad_Over = 0;
            double Probabilidad_Under = 0;
            double Dinero_Over = 0;
            double Dinero_Under = 0;

            if (res.Read())
            {
                Dinero_Over = res.GetDouble(0);
                Dinero_Under = res.GetDouble(1);

                Probabilidad_Over = Dinero_Over / (Dinero_Over + Dinero_Under);
                Probabilidad_Under = Dinero_Under / (Dinero_Under + Dinero_Over);

            }
            con.Close();

            double cuota_over = 1 / Probabilidad_Over * 0.95;
            double cuota_under = 1 / Probabilidad_Under * 0.95;

            if (Dinero_Over == 0 && a.OverUnder == false)
            {
                cuota_over = 0;
            }
            else if(Dinero_Under == 0 && a.OverUnder == true)
            {
                cuota_under = 0;
            }

            command.CommandText = "update mercado set Cuota_Over='" + cuota_over + "',Cuota_Under= '"+cuota_under+"' where id_Mercado=" +a.Mercado;

        }

        internal List<Apuesta> RetrievebyId(int NºApuesta)
        {
            var repo = new ApuestasRepository();
            List<Apuesta> apuestas = repo.RetrievebyId(NºApuesta);
            return apuestas;
        }

    }
}