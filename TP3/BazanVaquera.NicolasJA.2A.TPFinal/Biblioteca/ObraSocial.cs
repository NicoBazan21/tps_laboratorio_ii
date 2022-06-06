using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    /// <summary>
    /// Clase Generica ObraSocial donde T es de tipo Persona y derivados, e implmenta la Interfaz 
    /// Generica IOperaciones<T> donde T pertenece a elementos genericos de una Lista
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObraSocial<T>
        : IOperaciones<T>
        where T : Persona
    {
        #region Atributo
        private List<T> lista;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor sin parametros, inicializa la lista de tipos T
        /// </summary>
        public ObraSocial()
        {
            this.lista = new List<T>();
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// propiedad de lectura escritura para la Lista
        /// </summary>
        public List<T> Lista
        {
            get
            {
                return this.lista;
            }
            set
            {
                this.lista = value;
            }
        }
        #endregion

        #region Funciones
        /// <summary>
        /// Proveniente de la interfaz
        /// </summary>
        /// <returns></returns>
        public String Mostrar()
        {
            StringBuilder msj = new StringBuilder();

            foreach (T item in this.lista)
            {
                msj.AppendLine(item.ToString());
            }
            
            return msj.ToString();
        }
        /// <summary>
        /// Proveniente de la interfaz
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public List<T> Agregar(T elemento)
        {
            if(this != elemento)
            {
                this.lista.Add(elemento);
            }            
            return  this.lista;
        }
        /// <summary>
        /// Proveniente de la interfaz
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public List<T> Eliminar(T elemento)
        {
            if(this == elemento)
            {
                this.lista.Remove(elemento);
            }
            return this.lista;
        }
        /// <summary>
        /// Proveniente de la interfaz
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="modificar"></param>
        /// <returns></returns>
        public List<T>Modificar(T elemento, String modificar)
        {
            Int32 indice;
            if(this == elemento)
            {
                indice = this.ObtenerIndice(elemento);

                this.lista[indice].NombreCompleto = modificar;
            }

            return this.lista;
        }
        /// <summary>
        /// Proveniente de la interfaz
        /// </summary>
        /// <param name="modificar"></param>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public List<T>Modificar(String modificar, T elemento)
        {
            Int32 indice;
            if(this == elemento)
            {
                indice = this.ObtenerIndice(elemento);

                this.lista[indice].ApellidoDoctor = modificar;
            }

            return this.lista;
        }
        /// <summary>
        /// Proveniente de la interfaz
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="modificar"></param>
        /// <returns></returns>
        public List<T>Modificar(T elemento, Int32 modificar)
        {
            Int32 indice;
            if (this == elemento)
            {
                indice = this.ObtenerIndice(elemento);

                this.lista[indice].Dni = modificar;
            }

            return this.lista;
        }
        /// <summary>
        /// Proveniente de la interfaz
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="modificar"></param>
        /// <returns></returns>
        public List<T>Modificar(T elemento, Derivacion modificar)
        {
            Int32 indice;
            if (this == elemento)
            {
                indice = this.ObtenerIndice(elemento);

                this.lista[indice].Derivacion = modificar;
            }

            return this.lista;
        }
        /// <summary>
        /// Proveniente de la interfaz
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="modificar"></param>
        /// <returns></returns>
        public List<T> Modificar(T elemento, DateTime modificar)
        {
            Int32 indice;
            if (this == elemento)
            {
                indice = this.ObtenerIndice(elemento);

                this.lista[indice].Fecha = modificar;
            }

            return this.lista;
        }
        /// <summary>
        /// Escribe en el parametro el indice del dni si este esta incluido en la Lista de tipo T
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="indice"></param>
        /// <returns></returns>
        public bool BuscarDni(Int32 dni, out Int32 indice)
        {
            indice = 0;

            foreach (T item in this.lista)
            {
                if (item.Dni == dni)
                {
                    return true;
                }
                indice++;
            }
            return false;
        }
        /// <summary>
        /// Retorna el indice de un elementoS
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public Int32 ObtenerIndice(T elemento)
        {
            Int32 indice = 0;

            foreach (T item in this.lista)
            {
                if(item.Equals(elemento))
                {
                    return indice;
                }
                indice++;
            }
            return indice;
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// verifica si el elemnento de tipo T se enecuentra en la Lista de tipo TS
        /// </summary>
        /// <param name="obra"></param>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public static bool operator ==(ObraSocial<T> obra, T elemento)
        {
            foreach (T item in obra.lista)
            {
                if(item.Equals(elemento))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// verifica si noS el elemnento de tipo T se enecuentra en la Lista de tipo TS
        /// </summary>
        /// <param name="obra"></param>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public static bool operator !=(ObraSocial<T> obra, T elemento)
        {
            return !(obra == elemento);
        }
        #endregion

    }
}
