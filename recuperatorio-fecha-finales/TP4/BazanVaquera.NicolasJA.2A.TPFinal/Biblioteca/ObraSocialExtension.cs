using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class ObraSocialExtension
    {
        /// <summary>
        /// Obtener indice extension generico, obtiene la instancia de la obra social Generica y el elemento
        /// luego obtiene el indice del elemento en la lista y lo retorna
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hola"></param>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public static Int32 ObtenerIndicee<T>(this ObraSocial<T> hola, T elemento) where T : Persona
        {
            Int32 indice = 0;

            foreach (T item in hola.Lista)
            {
                if (item.Equals(elemento))
                {
                    return indice;
                }
                indice++;
            }
            return -1;
        }
    }
}
