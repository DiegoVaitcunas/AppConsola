using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Persona
    {
        public string NombreCompleto { get; set; }
        public Persona(string nombreCompleto)
        {
            this.NombreCompleto = nombreCompleto;
         
        }
        public Persona() { }
    }
}
