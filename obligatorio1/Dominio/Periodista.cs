using System;

namespace Dominio
{
    //Periodista, tiene herencia de Persona.
    public class Periodista : Persona
    {
        #region Constructor
        //Creamos la clase y realizamos su respectivo constructor
        public Periodista(string nombreCompleto, string email, string contrasenia) : base(nombreCompleto) 
        {
            this.Id = generateId();
            this.NombreCompleto = nombreCompleto;
            this.Email = email;
            this.Password = contrasenia;
            this.ValidarCamposVacios();
            this.ValidarMail();
            this.ValidarPassword();
            this.ValidarDuplicado();
        }
        public Periodista(){}
        public static int generateId()
        {
            ContadorId++;   //Generando el autonumerico
            return ContadorId;
        }
        #endregion

        //Atributos de Periodista.
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public static int ContadorId { get; set; } = 0;

        #region Validadores
        //Validacion de contraseña que pide en la letra.
        public void ValidarPassword()
        {
            if (this.Password.Length < 8)
            {
                throw new Exception("La contraseña debe ser mayor a 8 caracteres");
            }
        }
        //Validacion de mail que pide en la letra.
        public void ValidarCamposVacios()
        {
            if (this.NombreCompleto =="" || this.Password == "" || this.Email == "")
            {
                throw new Exception("Ningun campo puede estar vacio");
            }
        }
        public void ValidarMail()
        {
            int validar = this.Email.IndexOf("@");
            if (validar == -1 || validar == this.Email.Length-1 || validar == 0)
            {
                throw new Exception("El Email es incorrecto");
            }
        }
        public void ValidarDuplicado()
        {
            Sistema unSistema = Sistema.Instancia;
            foreach(Periodista p in unSistema.Periodistas)
            {
                if (p.Email.Equals(this.Email))
                {
                    throw new Exception("El email ya existe, presione nuevamente enter para ir al menu principal, su usuario no ha sido creado.");
                }else if (p.Id.Equals(this.Id))
                {
                   throw new Exception("El usuario ya existe");
                }
            }
        }
        #endregion
        //Metodo ToString para imprimir en pantalla lo solicitado.
        public override string ToString()
        {
            return $"Codigo de de identificacion: {this.Id} \n Nombre: {this.NombreCompleto} \n Email: {this.Email} \n";
        }


    }
}

