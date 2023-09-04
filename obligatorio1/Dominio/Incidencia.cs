using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
   //Creamos la clase y realizamos su respectivo constructor
    public class Incidencia
    {
        public Incidencia(Jugador unJugador, string tipo, int minuto, Partido unPartido)
        {
            this.Tipo = tipo;
            this.Minuto = minuto;
            this.unJugador = unJugador;
            this.unPartido = unPartido;
        }
        //Estos son los atributos de la clase.

        public Jugador unJugador { get; set; }
        public string Tipo { get; set; } //Gol, Amonestacion, etc
        public int Minuto { get; set; } 
        public Partido unPartido { get; set; }
    }
}
