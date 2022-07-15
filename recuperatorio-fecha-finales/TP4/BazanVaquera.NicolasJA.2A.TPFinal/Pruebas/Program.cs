using System;
using Biblioteca;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Persona nico = new Persona("Nico Bazan", 43010849);
            Persona delia = new Persona("Delia Vaquera", 17350105);
            Persona rene = new Persona("Rene Bazan", 12345678);

            //Console.WriteLine(nico);

            ObraSocial<Persona> obraPacientes = new ObraSocial<Persona>();
            obraPacientes.Agregar(nico);
            obraPacientes.Agregar(delia);
            obraPacientes.Agregar(rene);

            //Console.WriteLine(obraPacientes.Mostrar());

            DateTime fechaUno = new DateTime(2000, 6, 5, 11, 0, 0);
            DateTime fechaDos = new DateTime(2000, 6, 5, 15, 0, 0);
            DateTime fechaTres = new DateTime(2000, 6, 10, 11, 0, 0);
            
            ObraSocial<Turno> obraTurnos = new ObraSocial<Turno>();
            Turno nicoT = new Turno(nico, fechaUno, "Vaquera Beatriz",Derivacion.MedicoClinico);
            Turno deliaT = new Turno(delia, fechaDos, "Vaquera Beatriz",Derivacion.Dermatologia);
            Turno reneT = new Turno(rene, fechaTres, "Doctor Rivera",Derivacion.Pediatria);

            obraTurnos.Agregar(nicoT);
            obraTurnos.Agregar(new Turno(nico, fechaUno, "Vaquera Beatriz",Derivacion.Pediatria));//no puede el mismo dia
            obraTurnos.Agregar(new Turno(delia, fechaUno, "Vaquera Beatriz",Derivacion.Pediatria));//no puede mismo doctor misma hora
            obraTurnos.Agregar(deliaT);//si puede mismo doctor distinta hora
            obraTurnos.Agregar(reneT);

            Console.WriteLine(obraTurnos.Mostrar());

            obraTurnos.Eliminar(nicoT);
            obraTurnos.Eliminar(nicoT);
            obraTurnos.Eliminar(deliaT);
            
            Console.WriteLine(obraTurnos.Mostrar());

            obraTurnos.Modificar(reneT, "BazanMod",0);
            obraTurnos.Modificar(reneT,"Nuevo doctor", 1);
            obraTurnos.Modificar(reneT, Derivacion.Cardiologia,0);
            obraTurnos.Modificar(reneT, 87654321,0);
            obraTurnos.Modificar(reneT, new DateTime(1975,3,24),0);
            obraTurnos.Agregar(nicoT);

            Console.WriteLine(obraTurnos.Mostrar());

            Serealizadores<Turno>.SerealizarXML("datosSerealizados.xml",obraTurnos.Lista);
            //Serealizadores<Persona>.Serealizar("datosSerealizadosPersona.xml",obraPacientes.Lista);

            ObraSocial<Turno> obraNueva = new ObraSocial<Turno>();

            obraNueva.Lista = Serealizadores<Turno>.DeserealizarXML("datosSerealizados.xml");

            Console.WriteLine("Ya serealize");

            Console.WriteLine(obraNueva.Mostrar());

            Serealizadores<Turno>.SerealizarJson("datosSerealizadosJSON.json", obraTurnos.Lista);

            ObraSocial<Turno> obraNuevaNueva = new ObraSocial<Turno>();

            obraNuevaNueva.Lista = Serealizadores<Turno>.DeserealizarJson("datosSerealizadosJSON.json");

            Console.WriteLine(obraNuevaNueva.Mostrar());
            */
            
            GestorBase<Persona> hola = new GestorBase<Persona>();
            /*
            if(GestorBase<Persona>.ProbarConexion())
            {
                Console.WriteLine("Me conecte");
            }
            else
            {
                Console.WriteLine("no me conecte");
            }*/
            
            List<Persona> lista = new List<Persona>();
            Persona prueba = new Persona("Romero Sergio",17);
            
            /*if(hola.Agregar(prueba))
            {
                Console.WriteLine("Agregue");
            }*/
            
            //if(hola.Modificar(prueba))
            //{
            //    Console.WriteLine("Modifique");
            //}
            
            //if(hola.Eliminar(prueba))
            //{
            //    Console.WriteLine("Elimine");
            //}
            /*
            try
            {
                //lista = hola.LeerDatos(prueba);
            }
            catch (Exception)
            {
                Console.WriteLine("Hubo un problema al leer los Datos");
            }

            foreach (Persona item in lista)
            {
                //Console.WriteLine(item.ToString());
            }
            */
            /*
            
            GestorBase<Persona> hola = new GestorBase<Persona>();

            GestorBase <Turno> gestionT = new GestorBase<Turno>();
            
            //List<Turno> listaT = new List<Turno>();
            Persona prueba = new Persona("Romero Sergio", 17);
            DateTime fecha = new DateTime(2021, 03, 23, 17, 00, 00);
            Turno turno = new Turno(prueba, fecha, "Nuevo",Derivacion.MedicoClinico);
            

            /*if (hola.Agregar(prueba))
            {
                Console.WriteLine("Agregue");
            }
            
            if (gestionT.Agregar(turno))
            {
                Console.WriteLine("Agregue turno");
            }*/
            /*
            if (gestionT.Modificar(turno))
            {
                Console.WriteLine("Modifique");
            }
           */
            /*if(gestionT.Eliminar(turno))
            {
                Console.WriteLine("Elimine");
            }*/

            /*if(hola.Eliminar(prueba))
            {
                Console.WriteLine("Elimine");
            }*/
            /*
            try
            {
                //listaT = gestionT.LeerDatos(turno);
            }
            catch (Exception)
            {
                //Console.WriteLine("Hubo un problema al leer los Datos");
            }

            Console.WriteLine(listaT.Count);

            foreach (Turno item in listaT)
            {
                //Console.WriteLine(item.ToString());
            }
            
            
            /*
            SqlCommand comando;

            comando = new SqlCommand();

            comando.Parameters.AddWithValue("@dni", 43010849);
            comando.Parameters.AddWithValue("@nombre", "Bazan Nicolas");

            String insert = "insert into clientePrueba(dni,nombreCompleto) values(";
            insert += "@dni, @nombre)";

            Console.WriteLine(insert);
            */

        }
    }
}
