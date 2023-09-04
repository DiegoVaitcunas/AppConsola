using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Seleccion
    {
        public Seleccion()
        {

        }
        public Seleccion(Pais unPais)
        {
            this.unPais = unPais;
            this.jugadores = new List<Jugador>();
        }
        public void AgregarJugador(Jugador jugador)
        {
            this.jugadores.Add(jugador);
        }
        public List<Jugador> jugadores { get; set; }
        public Pais unPais { get; set; }

        #region validadores
        public void ValidarListaJugadores()
        {
            if (this.jugadores.Count <= 11)
            {
                throw new Exception("la lista de jugadores no puede ser menor a 11");
            }
        }
        #endregion
        public override string ToString()
        {
            return $"Nombre: {this.unPais.Nombre}";
        }
    }
}


      


