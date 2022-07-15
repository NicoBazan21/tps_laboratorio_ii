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
    public class GestorBase<T> where T : Persona
    {
        #region Atributos
        private static String cadena_conexion;
        private SqlConnection conexion;
        private SqlCommand comando;
        #endregion

        #region Constructores
        /// <summary>
        /// constructor estatico por defecto que inicializa la cadena de conexion
        /// </summary>
        static GestorBase()
        {
            GestorBase<T>.cadena_conexion = @"Server=BAZAN\MSSQLSERVER01;Database=TP4BazanVaquera;Trusted_Connection=True;";
        }

        /// <summary>
        /// constructor de instancia
        /// </summary>
        public GestorBase()
        {
            this.conexion = new SqlConnection(GestorBase<T>.cadena_conexion);
        }
        #endregion

        #region Propiedad

        public SqlCommand Comando
        {
            get
            {
                return this.comando;
            }
            set
            {
                this.comando = value;
            }
        }
        public SqlConnection Conexion
        {
            get
            {
                return this.conexion;
            }
            set
            {
                this.conexion = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo asincronico que devuelve una Tarea con una Lista Generica de tipos T
        /// Se encarga de verificar si el elemento recibido es un Turno o una Persona
        /// Entonces dependiendo de que tipo sea, ejecutara una deterinada accion para traer
        /// los datos requeridos
        /// </summary>
        /// <param name="criterio"></param>
        /// <returns></returns>
        public async Task<List<T>> LeerDatos(T criterio)
        {
            List<T> lista = new List<T>();
            try
            {
                lista = await Task.Run(() =>
                {
                    try
                    {
                        String consulta;
                        if (criterio is Turno)
                        {
                            consulta = "select clientesDB.dni,clientesDB.nombreCompleto,turnosDB.nombreDoctor,turnosDB.idDerivacion,turnosDB.fecha,turnosDB.hora from clientesDB inner join turnosDB on clientesDB.dni = turnosDB.dni";
                        }
                        else
                        {
                            consulta = "select * from ClientesDB";
                        }
                        SqlCommand comando = new SqlCommand(consulta, this.conexion);
                        this.conexion.Open();
                        SqlDataReader lector = comando.ExecuteReader();

                        if (criterio is Turno)
                        {
                            while (lector.Read())
                            {
                                int dni = lector.GetInt32(0);
                                String nombre = lector.GetString(1);
                                String nombreDoc = lector.GetString(2);
                                Derivacion derivacion = (Derivacion)lector.GetInt32(3);
                                DateTime fecha = new DateTime(lector.GetDateTime(4).Year,
                                    lector.GetDateTime(4).Month,
                                    lector.GetDateTime(4).Day,
                                    lector.GetInt32(5), 0, 0);

                                Persona cliente = new Persona(nombre, dni);
                                Turno turno = new Turno(cliente, fecha, nombreDoc, derivacion);
                                lista.Add((T)((Persona)turno));
                            }
                        }
                        else
                        {
                            while (lector.Read())
                            {
                                int dni = lector.GetInt32(0);
                                String nombre = lector.GetString(1);

                                Persona cliente = new Persona(nombre, dni);
                                lista.Add((T)cliente);
                            }
                        }
                        this.conexion.Close();
                    }
                    catch(Exception)
                    {
                        return lista = null;
                    }
                    return lista;
                });
                if(lista is null)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return lista;
        }


        /// <summary>
        /// Agregar, verifica si es Persona o Turno y ejecuta los comandos necesarios para agregar
        /// a la base de datos
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public bool Agregar(T elemento)
        {
            Boolean todoOk = true;
            try
            {
                this.comando = ObtenerComando(elemento);
                String insert = string.Empty;
                if (elemento is Turno)
                {
                    insert = "insert into turnosDB(dni, nombreDoctor, idDerivacion,fecha,hora) values(";
                    insert += "@dni, @nombreDoctor, @idDerivacion, @fecha, @hora)";
                }
                else
                {
                    insert = "insert into clientesDB(dni,nombreCompleto) values(";
                    insert += "@dni, @nombreCompleto)";
                }
                todoOk = EjecutarComando(insert);
            }
            catch (Exception)
            {
                throw new ErrorConSQLException("Error durante el agregado.");
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return todoOk;
        }

        /// <summary>
        /// Modificar, verifica si es Persona o Turno y ejecuta los comandos necesarios para modificar
        /// a la base de datos        
        /// /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public bool Modificar(T elemento)
        {
            Boolean todoOk = true;
            try
            {
                String update = string.Empty;
                this.comando = ObtenerComando(elemento);

                if(elemento is Turno)
                {
                    update = "update turnosDB ";
                    update += "SET nombreDoctor = @nombreDoctor, idDerivacion = @idDerivacion," +
                        " fecha = @fecha, hora = @hora ";
                    update += "WHERE dni = @dni";
                }
                else
                {
                    update = "update clientesDB ";
                    update += "SET nombreCompleto = @nombreCompleto ";
                    update += "WHERE dni = @dni";
                }

                todoOk = this.EjecutarComando(update);

            }
            catch(Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return todoOk;
        }

        /// <summary>
        ///Eliminar, verifica si es Persona o Turno y ejecuta los comandos necesarios para eliminar
        /// el elemento de la base de datos
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public bool Eliminar(T elemento)
        {
            Boolean todoOk;
            try
            {
                String delete = string.Empty;

                if (elemento is Turno)
                {
                    delete = "DELETE FROM turnosDB ";
                }
                else
                {
                    delete = "DELETE FROM clientesDB ";
                }

                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@dni", elemento.Dni);
                delete += "WHERE dni = @dni";

                todoOk = EjecutarComando(delete);
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return true;
        }
        /// <summary>
        /// Metodo que prueba la conexion, si esta es posible devuelve true y si no devuelve un false
        /// </summary>
        /// <returns></returns>
        public async static Task<bool> ProbarConexion()
        {
            bool todoOk = true;

            SqlConnection prueba = new SqlConnection(GestorBase<T>.cadena_conexion);

            try
            {
                todoOk = await Task.Run(() =>
                {
                    try
                    {
                        prueba.Open();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    finally
                    {
                        if (prueba.State == ConnectionState.Open)
                        {
                            prueba.Close();
                        }
                    }
                    return true;
                });
            }
            catch (Exception)
            {
                todoOk = false;
            }
            return todoOk;
        }

        /// <summary>
        /// Metodo generico, que dependiendo de que tipo sea el parametro recibido
        /// agregara determinados comandos al atributo Comando
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public SqlCommand ObtenerComando(T elemento)
        {
            this.comando = new SqlCommand();

            if (elemento is Turno)
            {
                this.comando.Parameters.AddWithValue("@dni", elemento.Dni);
                this.comando.Parameters.AddWithValue("@nombreDoctor", elemento.ApellidoDoctor);
                this.comando.Parameters.AddWithValue("@idDerivacion", ((int)elemento.Derivacion));
                this.comando.Parameters.AddWithValue("@fecha", elemento.Fecha);
                this.comando.Parameters.AddWithValue("@hora", elemento.Fecha.Hour);
            }
            else
            {
                this.comando.Parameters.AddWithValue("@dni", elemento.Dni);
                this.comando.Parameters.AddWithValue("@nombreCompleto", elemento.NombreCompleto);
            }

            return this.comando;
        }

        /// <summary>
        /// Metodo que ejecuta el comando con el mensaje que se recibe
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public bool EjecutarComando(String mensaje)
        {
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = mensaje;
            this.comando.Connection = this.conexion;

            this.conexion.Open();

            if (this.comando.ExecuteNonQuery() == 0)
            {
                return false;
            }
            return true;
        }

#endregion
    }
}
