using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region Enumerados
        public enum ETipo 
        {
            CuatroPuertas,
            CincoPuertas
        }

        #endregion

        #region Atributo

        private ETipo tipo;

        #endregion

        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color) : this(marca, chasis, color,ETipo.CuatroPuertas)
        {
        }
        /// <summary>
        /// Crea la instancia Sedan
        /// </summary>
        /// <param name="marca"></param>Recibe marca
        /// <param name="chasis"></param>Recibe chasis
        /// <param name="color"></param>Recibe color
        /// <param name="tipo"></param>Recibe tipo
        public Sedan(EMarca marca, String chasis, ConsoleColor color, ETipo tipo) : base(chasis,marca,color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        #endregion

        #region Metodo
        /// <summary>
        /// Muestra los datos completos de la instancia
        /// </summary>
        /// <returns></returns>
        public override String Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.Append("TAMAÑO : " + this.Tamanio);
            sb.AppendLine(" : TIPO : " + this.tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
