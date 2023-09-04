using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Resenia
    {
        #region Constructor
        public Resenia(Periodista unPeriodista, Partido unPartido, DateTime fecha, string titulo, string contenido)
        {
            this.Fecha = fecha;
            this.Titulo = titulo;
            this.Contenido = contenido;
        }
        #endregion
        public Periodista unPeriodista { get; set; }
        public Partido unPartido { get; set; }
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
    }
}
