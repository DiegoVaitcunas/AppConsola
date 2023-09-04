using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public interface IValidable
    {
        void ValidarFecha(){}
        void ValidarStrings(){}
        void ValidarAltura(){}
    }
}
