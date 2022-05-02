using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    /// 
    public abstract class Vehiculo
    {
        #region Atributos

        private String chasis;
        private ConsoleColor color;
        private EMarca marca;

        #endregion

        #region Constructor

        public Vehiculo(String chasis, EMarca marca , ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region Enumerados
        public enum EMarca
        {
            Chevrolet,
            Ford,
            Renault,
            Toyota,
            BMW,
            Honda,
            HarleyDavidson
        }
        public enum ETamanio
        {
            Chico,
            Mediano,
            Grande
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }
        #endregion

        #region Metodo
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual String Mostrar()
        {
            return (String)this;
        }
        #endregion

        #region Sobrecargas de operadores

        public static explicit operator String(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CHASIS: " + p.chasis);
            sb.AppendLine("MARCA : " + p.marca.ToString());
            sb.AppendLine("COLOR : " + p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1==v2);
        }
        #endregion
    }
}
