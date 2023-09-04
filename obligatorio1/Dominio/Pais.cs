using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pais
    {
        //Creamos la clase y realizamos su respectivo constructor
        public Pais(string nombre, string codigoA3)
        {
            this.Nombre = nombre;
            this.CodigoA3 = codigoA3;
           
        }
        //Estos son los atributos de la clase.
        public string Nombre { get; set; }
        public string CodigoA3 { get; set; }

        #region Validadores
        //Validamos que el pais no puede ser null, no puede estar vacio su nombre.
        public void ValidarPais()
        {
            if (this.Nombre == "")
            {
                throw new Exception("el pais no debe ser null");
            }
        }
        //Validamos que el CodigoA3 tiene que ser diferencia a 3, si es igual es incorrecto.
        public void ValidarCodigoA3()
        {
            if (this.CodigoA3.Length!=3)
            {
                throw new Exception("El codigo A3 en incorrecto");
            }
        }
        public void ValidarNombre()
        {
            if (this.Nombre == "")
            {
                throw new Exception("El nombre no puede ser vacio");
            }
        }
        #endregion

    }
}
