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
        Boolean Agregar(T agregar);
        /// <summary>
        /// Elimina elementos de tipo T de una lista
        /// </summary>
        /// <param name="remover"></param>
        /// <returns></returns>
        List<T> Eliminar(T remover);

        /// <summary>
        /// Corregido. Metodo generico de dos tipos, que evalua que tipo y que elemento se deben modificar
        /// </summary>
        /// <typeparam name="G"></typeparam>
        /// <param name="elemento"></param>
        /// <param name="modificar"></param>
        /// <param name="cualNombre"></param>
        /// <returns></returns>
        List<T> Modificar<G>(T elemento, G modificar, Int32 cualNombre);


    }
}
