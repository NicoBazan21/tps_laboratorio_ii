using System;

namespace Biblioteca
{
    public class Persona
    {
    
        #region Atributos
        private String nombreCompleto;
        private Int32 dni;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto, a fin de serializacion
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Constructor que inicializa los atributos Nombre y Dni
        /// </summary>
        /// <param name="nombreCompleto"></param>
        /// <param name="dni"></param>
        public Persona(String nombreCompleto, Int32 dni)
        {
            this.nombreCompleto = nombreCompleto;
            this.dni = dni;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad para el Atributo nombre
        /// </summary>
        public String NombreCompleto
        {
            get
            {
                return this.nombreCompleto;
            }
            set
            {
                this.nombreCompleto = value;
            }
        }
        /// <summary>
        /// Propiedad para el atributo Dni
        /// </summary>
        public Int32 Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }
        /// <summary>
        /// Propiedad virtual para el atributo Derivacion
        /// </summary>
        public virtual Derivacion Derivacion { get; set;}
        /// <summary>
        /// propiedad virtual para el atributo Fecha
        /// </summary>
        public virtual DateTime Fecha { get; set; }
        /// <summary>
        /// propiedad virtual para el atributo ApellidoDoc
        /// </summary>
        public virtual String ApellidoDoctor { get; set; }

        #endregion

        #region Funciones
        /// <summary>
        /// Retorna un String de los datos de la instancia
        /// </summary>
        /// <returns></returns>
        private String Mostrar()
        {
            return "Nombre completo: " + this.nombreCompleto + " dni: " + this.dni + "\n";
        }
        #endregion

        #region Sobrecarga de operadores y sobreescritura de Metodos
        /// <summary>
        /// Soobreescritura de ToString para llamar a Mostrar
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
        /// <summary>
        /// Verifica que se traten de dos objetos del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Persona)
            {
                return this == (Persona)obj;
            }
            return false;
        }
        /// <summary>
        /// Verifica que los objetos sean iguales segun criterios
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Persona p1, Persona p2)
        {
            return p1.dni == p2.dni;
        }
        /// <summary>
        /// verifica que los objetos sean distintos
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Persona p1, Persona p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
