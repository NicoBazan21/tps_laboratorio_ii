using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public interface IOperaciones<T> 
    {
        /// <summary>
        /// Cuerpo de funcion Mostrar
        /// </summary>
        /// <returns></returns>
        String Mostrar();

        /// <summary>
        /// Agrega elementos a una Lista de tipo T
        /// </summary>
        /// <param name="agregar"></param>
        /// <returns></returns>
        List<T> Agregar(T agregar);
        /// <summary>
        /// Elimina elementos de tipo T de una lista
        /// </summary>
        /// <param name="remover"></param>
        /// <returns></returns>
        List<T> Eliminar(T remover);
        
        /// <summary>
        /// Modifica un elemento Generico
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="modificar"></param>
        /// <returns></returns>
        List<T> Modificar(T elemento, String modificar);
        /// <summary>
        /// Sobrecarga de modificar, este tambien modifica un elemento Generico
        /// </summary>
        /// <param name="modificar"></param>
        /// <param name="elemento"></param>
        /// <returns></returns>
        List<T> Modificar(String modificar, T elemento);
        /// <summary>
        /// Modifica un elemento generico
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="modificar"></param>
        /// <returns></returns>
        List<T> Modificar(T elemento, Int32 modificar);
        /// <summary>
        /// Modifica un elemento generico
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="modificar"></param>
        /// <returns></returns>
        List<T> Modificar(T elemento, Derivacion modificar);
        /// <summary>
        /// Modifica un elemento generico
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="modificar"></param>
        /// <returns></returns>
        List<T> Modificar(T elemento, DateTime modificar);
        

    }
}
