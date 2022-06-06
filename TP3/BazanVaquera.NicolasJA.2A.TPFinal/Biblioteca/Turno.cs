using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Turno : Persona
    {
        #region Atributos
        private Derivacion derivacion;
        private DateTime fecha;
        private String apellidoDoctor;
        #endregion

        #region Constructores
        public Turno()
        {

        }

        public Turno(Persona p, DateTime fecha, String apellidoDoctor, Derivacion derivacion) : base(p.NombreCompleto, p.Dni)
        {
            this.derivacion = derivacion;
            this.fecha = fecha;
            this.apellidoDoctor = apellidoDoctor;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura escritura del atributo Derivacion
        /// </summary>
        public override Derivacion Derivacion
        {
            get
            {
                return this.derivacion;
            }
            set
            {
                this.derivacion = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura escritura del atributo Fecha
        /// </summary>
        public override DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura escritura del atributo Apellido
        /// </summary>
        public override String ApellidoDoctor
        {
            get
            {
                return this.apellidoDoctor;
            }
            set
            {
                this.apellidoDoctor = value;
            }
        }
        #endregion

        #region Funcion
        /// <summary>
        /// Retorna un string con los datos de la isntancia
        /// </summary>
        /// <returns></returns>
        private String Mostrar()
        {
            return base.ToString() + " Derivacion: "+this.derivacion+" con: " + this.ApellidoDoctor +" "+ this.fecha.ToString();
        }
        #endregion

        #region Sobrecarga de operadores y Sobreescritura de metodos
        /// <summary>
        /// sobreescritura del metodo To string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
        /// <summary>
        /// verifica que los objetos sean iguales dependiendo del criterio
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>

        public static bool operator ==(Turno t1, Turno t2)
        {
            if (t1.Dni == t2.Dni)
            {
                if(t1.fecha.Day == t2.fecha.Day &&
                    t1.fecha.Month == t2.fecha.Month)
                {
                    if(t1.fecha.Hour == t2.fecha.Hour)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                if (t1.fecha.Day == t2.fecha.Day &&
                    t1.fecha.Month == t2.fecha.Month)
                {
                    if(t1.apellidoDoctor == t2.apellidoDoctor)
                    {
                        if(t1.fecha.Hour == t2.fecha.Hour)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                return false;
            }
        }
        /// <summary>
        /// verifica que los objetos sean distintos
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator !=(Turno t1, Turno t2)
        {
            return !(t1 == t2);
        }

        /// <summary>
        /// verifica que se traten de dos objetos del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Turno)
            {
                return this == (Turno)obj;
            }
            return false;
        }
        #endregion
    }
}
