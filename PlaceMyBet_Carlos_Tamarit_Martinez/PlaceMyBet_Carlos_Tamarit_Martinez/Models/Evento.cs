using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Models
{
    public class Evento
    {
        public Evento(int nºEvento, string nombre_Equipo_Visitante, string nombre_Equipo_Local)
        {
            NºEvento = nºEvento;
            Nombre_Equipo_Visitante = nombre_Equipo_Visitante;
            Nombre_Equipo_Local = nombre_Equipo_Local;
        }

        public int NºEvento { get; set; }
        public string Nombre_Equipo_Visitante { get; set; }
        public string Nombre_Equipo_Local { get; set; }
    }

    public class EventoDTO
    {
        public EventoDTO(string nombre_Equipo_Visitante, string nombre_Equipo_Local)
        {
            Nombre_Equipo_Visitante = nombre_Equipo_Visitante;
            Nombre_Equipo_Local = nombre_Equipo_Local;
        }

        public string Nombre_Equipo_Visitante { get; set; }
        public string Nombre_Equipo_Local { get; set; }
    }
}