using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        //Atributo
        private double numero;

        #region Constructores
        /// <summary>
        /// constructor por defecto que llama a la sobrecarga que recibe un double
        /// para asignarle 0
        /// </summary>
        public Operando() : this(0)
        {
        }
        /// <summary>
        /// sobrecarga del constructor por defecto
        /// </summary>
        /// <param name="numero"></param>recibe un double y lo asigna al atributo privado
        public Operando(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// sobrecarga del constructor por defecto
        /// </summary>
        /// <param name="strNumero"></param>recibe un string de numero y llama a 
        /// propiedad numero para que lo asigne al atributo
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// metodo que validara que el operando recibido sea un numero y no palabras o letras
        /// </summary>
        /// <param name="strNumero"></param> recibe el string a validar
        /// <returns></returns>retorna un numero correspondiente al string o caso contrario retorna 0
        private double ValidarOperando(String strNumero)
        {
            double hola = 1;

            if (double.TryParse(strNumero, out hola))
            {
                return hola;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// propiedad Get del atributo numero
        /// </summary>invoca al metodo ValidarOperando para validar que el valor
        /// recibido sea de tipo numerico y que no contenga letras o palabras
        private String Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        #endregion

        #region Metodos binarios y sus sobrecargas
        /// <summary>
        /// Es binario validara que el string recibido no contenga
        /// valores mas altos que 1 o menores a 0 segun su codigo ascii
        /// </summary>
        /// <param name="binario"></param> recibe el string a validar
        /// <returns></returns>retorna true si el numero es de tipo binario
        /// retorna false si el string no es un numero binario
        private bool EsBinario(String binario)
        {
            StringBuilder binario_sb = new StringBuilder(binario);

            for (int i = 0; i < binario_sb.Length; i++)
            {
                if (binario_sb[i] > 49 || binario_sb[i] < 48)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// convierte un numero binario en decimal
        /// </summary>
        /// <param name="numero"></param>recibe el string que debe convertir a decimal
        /// <returns></returns>retorna el string convertido en decimal
        public String BinarioDecimal(String numero)
        {
            if (EsBinario(numero))
            {
                int rta = 0;
                int iterador = numero.Length - 1;
                for (int i = 0; i <= numero.Length - 1; i++)
                {
                    if (numero[i] == 49)
                    {
                        rta += (int)Math.Pow(2, iterador);
                    }
                    iterador--;
                }

                numero = "" + rta;
                return numero;
            }
            else
            {
                return "Valor inválido";
            }
        }
        /// <summary>
        /// sobrecarga de Decimalbinario que validara que el parametro recibdo
        /// contenga solo numeros y no letras
        /// </summary>
        /// <param name="numero"></param>recibe el string a validar
        /// <returns></returns>retorna el numero en formato string
        /// caso contrario retorna un string = "Valor inválido"
        public String DecimalBinario(String numero)
        {
            double aux;
            if (double.TryParse(numero, out aux))
            {
                if (aux < 0)
                {
                    aux = aux * (-1);
                }
                return DecimalBinario(aux);
            }
            else
            {
                return "Valor inválido";
            }
        }
        /// <summary>
        /// este metodo convertira un numero de tipo double a un numero binario
        /// </summary>
        /// <param name="numero"></param>recibe el double que se debe convertir
        /// <returns></returns>retorna el double recibido convertiro
        /// en binario en formato string 
        public String DecimalBinario(double numero)
        {
            String binario = "";

            numero = Math.Floor(numero);
            int num = (int)numero;

            if (num != 0)
            {
                while (num > 0)
                {
                    binario = num % 2 + binario;
                    num /= 2;
                }
            }
            else
            {
                binario += "0";
            }

            return binario;
        }

        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// sobrecarga del operador + que recibe dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1"></param>recibe el primer objeto de tipo operando
        /// <param name="n2"></param>recibe el segundo objeto de tipo operando
        /// <returns></returns>retorna la suma entre los atributos de estos dos objetos
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// sobrecarga del operador - que recibe dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1"></param>recibe el primer objeto de tipo operando
        /// <param name="n2"></param>recibe el segundo objeto de tipo operando
        /// <returns></returns>retorna la resta entre los atributos de estos dos objetos
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero + (-n2.numero);
        }
        /// <summary>
        /// sobrecarga del operador * que recibe dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1"></param>recibe el primer objeto de tipo operando
        /// <param name="n2"></param>recibe el segundo objeto de tipo operando
        /// <returns></returns>retorna la multiplicacion entre los atributos de estos
        /// dos objetos
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// sobrecarga del operador / que recibe dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1"></param>recibe el primer objeto de tipo operando
        /// <param name="n2"></param>recibe el segundo objeto de tipo operando
        /// <returns></returns>retorna la division entre los atributos de estos objetos
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
        #endregion
    }
}
