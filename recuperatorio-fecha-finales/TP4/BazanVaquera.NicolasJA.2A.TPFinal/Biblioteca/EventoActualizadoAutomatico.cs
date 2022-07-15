using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class EventoActualizadoAutomatico<T> where T : Persona
    {

        public delegate bool ManejadorHandler(T sender);
        public event ManejadorHandler EventoEliminador;
        public event ManejadorHandler EventoModificador;
        public event ManejadorHandler EventoAgregador;

        /// <summary>
        /// Constructor de instancia por defecto
        /// </summary>
        public EventoActualizadoAutomatico()
        {

        }
        /// <summary>
        /// Metodo que ejecuta el evento eliminador
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public bool EliminarEv(T sender)
        {
            if (EventoEliminador is not null)
            {
                if (EventoEliminador(sender))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// metodo que ejecuta los metodos dentro del delegado
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public bool ModificarEv(T sender)
        {
            if (EventoModificador is not null)
            {
                if (EventoModificador(sender))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// metodo agregar que ejecuta el evento agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public bool AgregarEv(T sender)
        {
            if (EventoAgregador is not null)
            {
                if (EventoAgregador(sender))
                {
                    return true;
                }
            }
            return false;
        }
    }

}
