using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class ErrorConSQLException : Exception
    {
        public ErrorConSQLException(String mensaje) : base(mensaje, null)
        {

        }

        public ErrorConSQLException(String mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
