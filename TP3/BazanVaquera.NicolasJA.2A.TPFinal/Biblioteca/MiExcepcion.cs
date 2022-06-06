using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MiExcepcion : Exception
    {
        public MiExcepcion() : base()
        {

        }
        public MiExcepcion(String informe) : base(informe)
        {

        }

        public MiExcepcion(String informe, Exception eGenerica) : base(informe, eGenerica)
        {

        }

    }
}
