using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;
using System;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifica que se rechace un turno el mismo dia y la misma hora, ya que eso no
        ///seria posible en la realidad para el Cliente o para el Doctor
        /// </summary>
        [TestMethod]
        public void AgregarTurnoMismaHoraMismoDia()
        {
            DateTime fechaUno = new DateTime(2000, 6, 5, 11, 0, 0);
            Persona nico = new Persona("Nico Bazan", 43010849);
            Turno nicoT = new Turno(nico, fechaUno, "Vaquera Beatriz", Derivacion.MedicoClinico);

            ObraSocial<Turno> obraTurnos = new ObraSocial<Turno>();

            obraTurnos.Agregar(nicoT);
            obraTurnos.Agregar(new Turno(nico, fechaUno, "Vaquera Beatriz", Derivacion.Pediatria));//no puede el mismo dia

            Int32 cantidadDeElementosEsperados = 1;

            Assert.AreEqual(obraTurnos.Lista.Count, cantidadDeElementosEsperados);

        }
        /// <summary>
        /// Verifica que se pueda agregar un turno a la misma hora, pero distinto dia
        /// </summary>
        [TestMethod]
        public void AgregarTurnoMismaHoraDistintoDia()
        {
            DateTime fechaUno = new DateTime(2000, 6, 5, 11, 0, 0);
            DateTime fechaDos = new DateTime(2000, 6, 6, 11, 0, 0);
            Persona nico = new Persona("Nico Bazan", 43010849);
            Turno nicoT = new Turno(nico, fechaUno, "Vaquera Beatriz", Derivacion.MedicoClinico);

            ObraSocial<Turno> obraTurnos = new ObraSocial<Turno>();

            obraTurnos.Agregar(nicoT);
            obraTurnos.Agregar(new Turno(nico, fechaDos, "Vaquera Beatriz", Derivacion.Pediatria));//no puede el mismo dia

            Int32 cantidadDeElementosEsperados = 2;

            Assert.AreEqual(obraTurnos.Lista.Count, cantidadDeElementosEsperados);
        }

        /// <summary>
        /// Verifica el correcto funcionamiento de Eliminar un turno mediante un índice
        /// </summary>
        [TestMethod]
        public void EliminarTurnoPorDni()
        {
            DateTime fechaUno = new DateTime(2000, 6, 5, 11, 0, 0);
            Persona nico = new Persona("Nico Bazan", 43010849);
            Turno nicoT = new Turno(nico, fechaUno, "Vaquera Beatriz", Derivacion.MedicoClinico);

            ObraSocial<Turno> obraTurnos = new ObraSocial<Turno>();

            obraTurnos.Agregar(nicoT);
            if(obraTurnos.Lista.Count == 1)
            {
                Int32 indice;
                    
                obraTurnos.BuscarDni(43010849, out indice);

                obraTurnos.Eliminar(obraTurnos.Lista[indice]);
            }

            Int32 cantidadDeElementosEsperados = 0;

            Assert.AreEqual(obraTurnos.Lista.Count, cantidadDeElementosEsperados);
        }

        /// <summary>
        /// Verifica que no se puedan agregar turnos iguales
        /// </summary>
        [TestMethod]
        public void AcasoSonIgualesEstosTurnos()
        {
            DateTime fechaUno = new DateTime(2000, 6, 5, 11, 0, 0);
            DateTime fechaDos = new DateTime(2000, 6, 6, 11, 0, 0);
            Persona nico = new Persona("Nico Bazan", 43010849);
            Turno nicoT = new Turno(nico, fechaUno, "Vaquera Beatriz", Derivacion.MedicoClinico);
            Turno nicoT2 = new Turno(nico, fechaDos, "Vaquera Beatriz", Derivacion.MedicoClinico);

            Boolean deberianSerDistintos = true;

            Assert.AreEqual(nicoT != nicoT2, deberianSerDistintos);

        }
    }
}
