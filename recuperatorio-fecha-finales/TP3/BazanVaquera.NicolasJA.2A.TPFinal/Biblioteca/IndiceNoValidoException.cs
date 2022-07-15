using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class IndiceNoValidoException : Exception
    {
        public IndiceNoValidoException(String mensaje) : base(mensaje, null)
        {

        }

        public IndiceNoValidoException(String mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
