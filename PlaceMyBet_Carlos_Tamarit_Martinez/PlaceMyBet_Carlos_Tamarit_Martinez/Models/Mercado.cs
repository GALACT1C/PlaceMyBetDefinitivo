using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Models
{
    public class Mercado
    {
        public Mercado(int id_Mercado, double tipo_Mercado, double cuota_Over, double cuota_Under, double apostado_Over, double apostado_Under, int id_evento)
        {
            this.id_Mercado = id_Mercado;
            Tipo_Mercado = tipo_Mercado;
            Cuota_Over = cuota_Over;
            Cuota_Under = cuota_Under;
            Apostado_Over = apostado_Over;
            Apostado_Under = apostado_Under;
            Id_Evento = id_evento;

        }

        public int id_Mercado { get; set; }
        public double Tipo_Mercado { get; set; }
        public double Cuota_Over { get; set; }
        public double Cuota_Under { get; set; }
        public double Apostado_Over { get; set; }
        public double Apostado_Under { get; set; }
        public double Id_Evento { get; set; }

    }

    public class MercadoDTO
    {
        public MercadoDTO(double tipo_Cuota, double cuota_Over, double cuota_Under, double apostado_Over, double apostado_Under, int id_evento)
        {
            Tipo_Mercado = tipo_Cuota;
            Cuota_Over = cuota_Over;
            Cuota_Under = cuota_Under;
            Apostado_Over = apostado_Over;
            Apostado_Under = apostado_Under;
            Id_Evento = id_evento;
        }

        public double Tipo_Mercado { get; set; }
        public double Cuota_Over { get; set; }
        public double Cuota_Under { get; set; }
        public double Apostado_Over { get; set; }
        public double Apostado_Under { get; set; }
        public double Id_Evento { get; set; }

    }

    public class MercadoCuota
    {
        public MercadoCuota(double tipo_Cuota, double cuota_Over, double cuota_Under)
        {
            Tipo_Mercado = tipo_Cuota;
            Cuota_Over = cuota_Over;
            Cuota_Under = cuota_Under;
        }

        public double Tipo_Mercado { get; set; }
        public double Cuota_Over { get; set; }
        public double Cuota_Under { get; set; }

    }

    public class MercadoApuesta
    {
        public MercadoApuesta(string dni,double tipo_mercado, bool overunder, double cuota, double dinero_apostado)
        {
            Dni = dni;
            Tipo_Mercado = tipo_mercado;
            Overunder = overunder;
            Cuota = cuota;
            Dinero_apostado = dinero_apostado;
        }

        public string Dni { get; set; }
        public double Tipo_Mercado { get; set; }
        public bool Overunder { get; set; }
        public double Cuota { get; set; }
        public double Dinero_apostado { get; set; }

    }
}