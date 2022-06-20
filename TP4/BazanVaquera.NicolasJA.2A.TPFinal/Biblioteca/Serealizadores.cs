using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

namespace Biblioteca
{
    public class Serealizadores<T>
    {
        #region Atributo
        private static String rutaBase;
        #endregion

        #region Constructor
        /// <summary>
        /// Crea el directorio en donde se depositaran los Archivos
        /// </summary>
        static Serealizadores()
        {
            //DirectoryInfo lugar = Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Arhivos_Serializados\\");
            //Serealizadores.rutaBase = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Arhivos_Serializados\\";
            rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo lugar = Directory.CreateDirectory(rutaBase);
            Serealizadores<T>.rutaBase = lugar.FullName;
            Console.WriteLine(rutaBase);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Serealiza una Lista generica de tipos T en formato XML
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static bool SerealizarXML(String archivo, List<T> lista)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter($"{Serealizadores<T>.rutaBase}{archivo}"))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<T>));

                    xml.Serialize(escritor, lista);
                }
                return true;
            }
            catch (Exception controlar)
            {
                throw new Exception("Excepcion controlada. Ha ocurrido un error: ", controlar);
            }
        }
        /// <summary>
        /// Deserealiza una lista de tipos T genericos y los retorna
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static List<T> DeserealizarXML(String archivo)
        {
            try
            {
                using (StreamReader lector = new StreamReader($"{Serealizadores<T>.rutaBase}{archivo}"))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<T>));

                    List<T> lista = xml.Deserialize(lector) as List<T>;

                    return lista;
                }
            }
            catch(Exception controlar)
            {
                throw new Exception("Excepcion controlada. Ha ocurrido un error: ", controlar);
            }
        }
        /// <summary>
        /// Serealiza una lista de tipos T en formato Json
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static bool SerealizarJson(String archivo, List<T> lista)
        {
            try
            {
                using (StreamWriter escritorJson = new StreamWriter($"{Serealizadores<T>.rutaBase}{archivo}"))
                {
                    JsonSerializerOptions identar = new JsonSerializerOptions();
                    identar.WriteIndented = true;
                    escritorJson.WriteLine(JsonSerializer.Serialize(lista, identar));
                    return true;
                }
            }
            catch(Exception controlar)
            {
                throw new Exception("Excepcion controlada. Ha ocurrido un error: ", controlar);
            }
        }
        /// <summary>
        /// Deserealiza un objeto lista de tipo T y lo retorna
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static List<T> DeserealizarJson(String archivo)
        {
            try
            {
                using (StreamReader lectorJson = new StreamReader($"{Serealizadores<T>.rutaBase}{archivo}"))
                {
                    return JsonSerializer.Deserialize<List<T>>(lectorJson.ReadToEnd());
                }
            }
            catch(Exception controlar)
            {
                throw new Exception("Excepcion controlada. Ha ocurrido un error: ", controlar);
            }

        }
        /// <summary>
        /// Guarda un String en un archivo de extension .txt
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="queGuardar"></param>
        /// <returns></returns>
        public static bool GuardarTxt(String archivo, String queGuardar)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(archivo, true))
                {
                    escritor.WriteLine(queGuardar);
                    return true;
                }
            }
            catch(Exception controlar)
            {
                throw new Exception("Excepcion controlada. Ha ocurrido un error: ", controlar);
            }
        }
        #endregion

    }
}
