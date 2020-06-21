using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Models
{
    public class Cliente
    {
        public Cliente(string dni, string cuentabancaria, string nombre, string apellidos, int edad, string email)
        {
            this.Dni = dni;
            this.Cuentabancaria = cuentabancaria;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
            this.Email = email;
        }

        public string Dni { get; set; }
        public string Cuentabancaria { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        

    }
}