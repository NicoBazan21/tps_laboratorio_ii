using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class ListaVaciaException : Exception
    {
        public ListaVaciaException(String mensaje) : base(mensaje, null)
        {

        }

        public ListaVaciaException(String mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
