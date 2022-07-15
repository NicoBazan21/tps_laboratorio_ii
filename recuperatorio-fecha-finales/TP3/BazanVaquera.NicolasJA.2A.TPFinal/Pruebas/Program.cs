using System;
using Biblioteca;

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

            obraTurnos.Modificar(reneT, "BazanMod");
            obraTurnos.Modificar("Nuevo doctor", reneT);
            obraTurnos.Modificar(reneT, Derivacion.Cardiologia);
            obraTurnos.Modificar(reneT, 87654321);
            obraTurnos.Modificar(reneT, new DateTime(1975,3,24));
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

            Console.WriteLine(obraNuevaNueva.Mostrar());*/

            

        }
    }
}
