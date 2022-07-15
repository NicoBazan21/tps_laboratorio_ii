using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class SerealizadoresException : Exception
    {
        public SerealizadoresException() : base()
        {

        }
        public SerealizadoresException(String informe) : base(informe)
        {

        }
    }
}
