using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region Constructor
        /// <summary>
        /// Crea la instancia Suv
        /// </summary>
        /// <param name="marca"></param>Recibe marca
        /// <param name="chasis"></param>Recibe chasis
        /// <param name="color"></param>Recibe color
        public Suv(EMarca marca, string chasis, ConsoleColor color): base(chasis, marca, color)
        {
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de la Instancia suv
        /// </summary>
        /// <returns></returns>
        public override String Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : " + this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
