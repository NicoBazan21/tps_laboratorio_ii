using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MisExcepciones
    {
        /*public MisExcepciones() : base()
        {

        }
        public MisExcepciones(String informe) : base(informe)
        {

        }

        public MisExcepciones(String informe, Exception eGenerica) : base(informe, eGenerica)
        {

        }*/
    }
    public class IndiceNoValidoException : Exception
    {
        public IndiceNoValidoException(String mensaje) : base(mensaje, null)
        {

        }

        public IndiceNoValidoException(String mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }

    public class ListaVaciaException : Exception
    {
        public ListaVaciaException(String mensaje) : base(mensaje, null)
        {

        }

        public ListaVaciaException(String mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }

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
