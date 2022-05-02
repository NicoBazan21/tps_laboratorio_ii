using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        private List<Vehiculo> vehiculos;
        private Int32 espacioDisponible;

        public enum ETipo
        {
            Ciclomotor,
            Sedan,
            SUV,
            Todos
        }

        #region "Constructores"
        /// <summary>
        /// Constructor privado que inicializa la Lista de vehiculos
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Crea la instancia Taller
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static String Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (String.Compare(v.GetType().Name, tipo.ToString(), true) == 0
                    || tipo == ETipo.Todos)
                {
                    sb.AppendLine(v.Mostrar());
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            Boolean elVehiculoEsta = false;
            if (taller.vehiculos.Count < taller.espacioDisponible)
            {
                foreach (Vehiculo item in taller.vehiculos)
                {
                    if (item == vehiculo)
                    {
                        elVehiculoEsta = true;
                    }
                }
                if (!elVehiculoEsta)
                {
                    taller.vehiculos.Add(vehiculo);
                }
            }
            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    taller.vehiculos.Remove(v);
                    return taller;
                }
            }
            return taller;
        }
        #endregion
    }
}
