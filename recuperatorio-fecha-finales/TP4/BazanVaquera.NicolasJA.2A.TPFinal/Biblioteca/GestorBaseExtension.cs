using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca
{
    public static class GestorBaseExtension
    {
        /// <summary>
        /// Vacia las listas de la base de datos
        /// </summary>
        /// <param name="instancia"></param>
        public static void EliminarTodoo(this GestorBase<Turno> instancia)
        {
            try
            {
                String delete = string.Empty;

                instancia.Comando = new SqlCommand();

                delete = "DELETE FROM turnosDB DELETE FROM clientesDB";

                instancia.EjecutarComando(delete);

            }
            catch (Exception)
            {
                throw new ErrorConSQLException("Hubo un error con la base de datos");
            }
            finally
            {
                if (instancia.Conexion.State == ConnectionState.Open)
                {
                    instancia.Conexion.Close();
                }
            }
        }
    }
}
