using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Models
{
    public class Apuesta
    {
        public Apuesta(int nºApuesta, double dinero_Apostado, int mercado, string cuota, bool overunder, string dNI_Cliente)
        {
            NºApuesta = nºApuesta;
            Dinero_Apostado = dinero_Apostado;
            Cuota = cuota;
            OverUnder = overunder;
            Mercado = mercado;
            DNI_Cliente = dNI_Cliente;
        }

        public int NºApuesta { get; set; }
        public double Dinero_Apostado { get; set; }
        public string Cuota { get; set; }
        public bool OverUnder { get; set; }
        public int Mercado { get; set; }
        public string DNI_Cliente { get; set; }
    }

    public class ApuestaDTO
    {
        public ApuestaDTO(double dinero_Apostado, int mercado, string cuota, bool overunder, string dNI_Cliente)
        {
            Dinero_Apostado = dinero_Apostado;
            Cuota = cuota;
            OverUnder = overunder;
            Mercado = mercado;
            DNI_Cliente = dNI_Cliente;
        }

        public double Dinero_Apostado { get; set; }
        public string Cuota { get; set; }
        public bool OverUnder { get; set; }
        public int Mercado { get; set; }
        public string DNI_Cliente { get; set; }
    }

    public class ApuestaCliente
    {
        public ApuestaCliente(double dinero_Apostado, int mercado, string cuota, bool overunder, double tipo_apuesta)
        {
            Dinero_Apostado = dinero_Apostado;
            Cuota = cuota;
            OverUnder = overunder;
            Mercado = mercado;
            Tipo_Apuesta = tipo_apuesta;
        }

        public double Dinero_Apostado { get; set; }
        public string Cuota { get; set; }
        public bool OverUnder { get; set; }
        public int Mercado { get; set; }
        public double Tipo_Apuesta { get; set; }
    }



}