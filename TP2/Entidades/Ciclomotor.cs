using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region Constructor
        /// <summary>
        /// Crea la instancia Ciclomotor
        /// </summary>
        /// <param name="marca"></param>Recibe Marca
        /// <param name="chasis"></param>Recibe Chasis
        /// <param name="color"></param>Recibe Color
        public Ciclomotor(EMarca marca, String chasis, ConsoleColor color) : base(chasis,marca,color)
        {
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Muestra los datos del Ciclomotor
        /// </summary>
        /// <returns></returns>
        public override String Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : " + this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
