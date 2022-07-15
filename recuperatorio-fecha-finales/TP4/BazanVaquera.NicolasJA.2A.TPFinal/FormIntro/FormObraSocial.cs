using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace Formulario
{
    public partial class FormObraSocial : Form
    {
        public ObraSocial<Persona> obraClientes;
        public ObraSocial<Turno> obraTurnos;
        public GestorBase<Persona> gestorPersonas;
        public GestorBase<Turno> gestorTurnos;
        public Boolean sqlCargado;

        /// <summary>
        /// Delegado Listar
        /// </summary>
        public delegate void DelegadoListar();
        /// <summary>
        /// Este atributo almacenara se le puede cargar con las operaciones que debe ejecutar
        /// </summary>
        public DelegadoListar listar;


        private EventoActualizadoAutomatico<Turno> accAutomaticoT;
        private EventoActualizadoAutomatico<Persona> accAutomaticoP;

        public FormObraSocial()
        {
            InitializeComponent();
            this.obraClientes = new ObraSocial<Persona>();
            this.obraTurnos = new ObraSocial<Turno>();
            this.gestorPersonas = new GestorBase<Persona>();
            this.gestorTurnos = new GestorBase<Turno>();
            this.accAutomaticoT = new EventoActualizadoAutomatico<Turno>();
            this.accAutomaticoP = new EventoActualizadoAutomatico<Persona>();
            this.accAutomaticoT.EventoEliminador += gestorTurnos.Eliminar;
            this.accAutomaticoT.EventoAgregador += gestorTurnos.Agregar;
            this.accAutomaticoT.EventoModificador += gestorTurnos.Modificar;

            this.accAutomaticoP.EventoEliminador += gestorPersonas.Eliminar;
            this.accAutomaticoP.EventoAgregador += gestorPersonas.Agregar;
            this.accAutomaticoP.EventoModificador += gestorPersonas.Modificar;
            
            listar = lstBClientes.Items.Clear;
            listar += lstBTurnos.Items.Clear;
            listar += ListarClientes;
            listar += ListarTurnos;

        }

        #region Metodos
        /// <summary>
        /// Lista la RTB Clientes
        /// </summary>
        public void ListarClientes()
        {
            foreach (Persona item in obraClientes.Lista)
            {
                this.lstBClientes.Items.Add(item);
            }
        }
        /// <summary>
        /// Lista la RTB turnos
        /// </summary>
        public void ListarTurnos()
        {
            foreach (Turno item in this.obraTurnos.Lista)
            {
                this.lstBTurnos.Items.Add(item);
            }
        }
        /// <summary>
        /// Dispara los eventos correspondientes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="crit"></param>
        public void EjecutarEvento<T>(T t, Int32 crit) where T : Persona
        {
            Task.Run(() =>
            {
                try
                {
                    Boolean problema = false;
                    if (t is Turno)
                    {
                        Turno t1 = new Turno(new Persona(t.NombreCompleto, t.Dni), t.Fecha, t.ApellidoDoctor, t.Derivacion);
                        switch (crit)
                        {
                            case 1:
                                problema = this.accAutomaticoT.EliminarEv(t1);
                                break;
                            case 2:
                                problema = this.accAutomaticoT.ModificarEv(t1);
                                break;
                            case 3:
                                problema = this.accAutomaticoT.AgregarEv(t1);
                                break;
                        }
                    }
                    else
                    {
                        switch (crit)
                        {
                            case 1:
                                problema = this.accAutomaticoP.EliminarEv(t);
                                break;
                            case 2:
                                problema = this.accAutomaticoP.ModificarEv(t);
                                break;
                            case 3:
                                problema = this.accAutomaticoP.AgregarEv(t);
                                break;
                        }
                    }
                }
                catch (ErrorConSQLException ex)
                {
                    MessageBox.Show("Excepcion Controlada. " + ex.Message, "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Se produjo un error al eliminar de la base de datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }
        #endregion

        #region Botones o Funciones Form
        /// <summary>
        /// Añade personas a la lista de clientes y tambien si está activo, lanza el evento "actualizacion automatica"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPers_Click(object sender, EventArgs e)
        {
            FormAgregarSocio form = new FormAgregarSocio();
            try
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Int32 aux;
                    Int32.TryParse((form.txtBDni.Text), out aux);

                    Persona usar = new Persona(form.txtBNombre.Text + " " + form.txtBApellido.Text, aux);

                    if(this.obraClientes.Agregar(usar))
                    {
                        if (this.chkAutomatico.Checked == true)
                        {
                            this.EjecutarEvento<Persona>(usar, 3);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cliente ya en la lista.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.listar();
                }
            }
            catch (ErrorConSQLException controlar)
            {
                MessageBox.Show(controlar.Message, "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un problema al agregar al Cliente los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Añade turnos a la lista de turnos y tambien si está activo, lanza el evento "actualizacion automatica"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTurno_Click(object sender, EventArgs e)
        {
            FormAgregarTurno form = new FormAgregarTurno();
            
            if(form.ShowDialog() == DialogResult.OK)
            {
                if (obraClientes.Lista.Count != 0)
                {
                    try
                    {
                        Int32 aux;
                        Int32.TryParse((form.txtBDniA.Text), out aux);
                        Int32 indice;
                        if (obraClientes.BuscarDni(aux, out indice))
                        {
                            Int32 horas;

                            DateTime fecha = new DateTime();
                            fecha = form.dateTimeFecha.Value;
                            Int32.TryParse(form.txtBHora.Text, out horas);
                            fecha.AddHours(horas);

                            Turno t = new Turno(obraClientes.Lista[indice],
                                new DateTime(fecha.Year, fecha.Month, fecha.Day, horas, 0, 0), form.cmbMedicos.SelectedItem.ToString(), (Derivacion)form.cmbDerivacion.SelectedItem);

                            if(obraTurnos.Agregar(t))
                            {
                                this.listar();
                                if (this.chkAutomatico.Checked == true)
                                {
                                    this.EjecutarEvento<Turno>(t, 3);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Turno rechazado.\n Motivos: Horario, o doctor ocupados","Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Dni no encontrado! Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Hubo un problema al añadir el Turno", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        /// <summary>
        /// Modifica clientes y tambien si está activo, lanza el evento "actualizacion automatica"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModCliente_Click(object sender, EventArgs e)
        {
            FormModificarSocio form = new FormModificarSocio();

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (obraClientes.Lista.Count > 0)
                    {
                        if (lstBClientes.SelectedIndex != -1)
                        {
                            Int32 indiceTurnos;
                            Boolean existeUnTurno = obraTurnos.BuscarDni(obraClientes.Lista[lstBClientes.SelectedIndex].Dni, out indiceTurnos);

                            if (form.txtBNombre.ReadOnly == false)
                            {
                                Int32 indice = lstBClientes.SelectedIndex;
                                obraClientes.Modificar(obraClientes.Lista[indice], form.txtBNombre.Text, 0);
                                if (existeUnTurno)
                                {
                                    obraTurnos.Modificar(obraTurnos.Lista[indiceTurnos], form.txtBNombre.Text, 0);
                                }
                                if (this.chkAutomatico.Checked == true)
                                {
                                    this.EjecutarEvento<Persona>(obraClientes.Lista[indice], 2);
                                }
                            }

                            listar();

                        }
                        else
                        {
                            throw new IndiceNoValidoException("No se ha elegido un elemento de la Lista.");
                        }
                    }
                    else
                    {
                        throw new ListaVaciaException("Lista sin Clientes.");
                    }
                }
                catch (ListaVaciaException ex)
                {
                    MessageBox.Show("Excepcion Controlada. " + ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IndiceNoValidoException ex)
                {
                    MessageBox.Show("Excepcion Controlada. "+ex.Message+" Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Excepcion Controlada. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Modifica turnos y tambien, si esta activo, lanza el evento actualizacion automatica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModTurno_Click(object sender, EventArgs e)
        {
            FormModificarTurno form = new FormModificarTurno();

            if(form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if(obraTurnos.Lista.Count > 0)
                    {
                        if (lstBTurnos.SelectedIndex != -1)
                        {
                            Int32 indice = lstBTurnos.SelectedIndex;
                            if (form.cmbDerivacion.Enabled == true)
                            {
                                obraTurnos.Modificar(obraTurnos.Lista[indice], (Derivacion)form.cmbDerivacion.SelectedItem,0);
                            }
                            if (form.cmbMedicos.Enabled == true)
                            {
                                obraTurnos.Modificar(obraTurnos.Lista[indice], form.cmbMedicos.Text, 1);
                            }
                            if (form.dateTimeFecha.Enabled == true)
                            {
                                Int32 horas;

                                DateTime fecha = new DateTime();
                                fecha = form.dateTimeFecha.Value;
                                Int32.TryParse(form.txtBHora.Text, out horas);
                                fecha.AddHours(horas);
                                obraTurnos.Modificar(obraTurnos.Lista[indice], new DateTime(fecha.Year, fecha.Month, fecha.Day, horas, 0, 0),0);
                            }
                            if (this.chkAutomatico.Checked == true)
                            {
                                this.EjecutarEvento<Turno>(this.obraTurnos.Lista[indice], 2);
                            }

                            this.listar();

                        }
                        else
                        {
                            throw new IndiceNoValidoException("No se ha elegido un elemento de la Lista.");
                        }
                    }
                    else
                    {
                        throw new ListaVaciaException("Lista sin Turnos.");
                    }

                }
                catch (ListaVaciaException ex)
                {
                    MessageBox.Show("Excepcion Controlada. " + ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IndiceNoValidoException ex)
                {
                    MessageBox.Show("Excepcion Controlada. " + ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Excepcion Controlada. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Elimina clientes y si esta activa la opcion, se actualizara automaticamente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            FormEliminarSocio form = new FormEliminarSocio();

            if(form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (obraClientes.Lista.Count > 0)
                    {
                        Int32 aux;
                        Int32.TryParse((form.txtBDni.Text), out aux);
                        Int32 indice;
                        if (obraClientes.BuscarDni(aux, out indice))
                        {
                            Persona eliminarP = obraClientes.Lista[indice];
                            obraClientes.Eliminar(obraClientes.Lista[indice]);

                            if (obraTurnos.Lista.Count > 0 && obraTurnos.BuscarDni(aux, out indice))
                            {
                                while(obraTurnos.BuscarDni(aux,out indice))
                                {
                                    Turno eliminarT = obraTurnos.Lista[indice];
                                    obraTurnos.Eliminar(obraTurnos.Lista[indice]);
                                    if (this.chkAutomatico.Checked == true)
                                    {
                                        this.EjecutarEvento<Turno>(eliminarT, 1);
                                    }
                                }
                            }

                            if(this.chkAutomatico.Checked == true)
                            {
                                this.EjecutarEvento<Persona>(eliminarP, 1);
                            }
                            
                            listar();
                        }
                        else
                        {
                            MessageBox.Show("Dni no encontrado!. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        throw new ListaVaciaException("Lista sin Clientes.");
                    }
                }
                catch (ListaVaciaException ex)
                {
                    MessageBox.Show("Excepcion Controlada. " + ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al eliminar el Cliente", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Se eliminara un turno, y si esta activa la opcion, se eliminara automaticamente de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            FormEliminarTurno form = new FormEliminarTurno();
            try
            {
                if (obraTurnos.Lista.Count > 0)
                {
                    if (lstBTurnos.SelectedIndex != -1)
                    {
                        Turno t = obraTurnos.Lista[lstBTurnos.SelectedIndex];
                        obraTurnos.Eliminar(obraTurnos.Lista[lstBTurnos.SelectedIndex]);

                        this.listar();

                        if (this.chkAutomatico.Checked == true)
                        {
                            this.EjecutarEvento<Turno>(t, 1);
                        }
                    }
                    else
                    {
                        throw new IndiceNoValidoException("No se ha elegido un elemento de la Lista.");
                    }
                }
                else
                {
                    throw new ListaVaciaException("Lista sin Turnos.");
                }
            }
            catch (ListaVaciaException ex)
            {
                MessageBox.Show("Excepcion Controlada. " + ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IndiceNoValidoException ex)
            {
                MessageBox.Show("Excepcion Controlada. " + ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Excepcion Controlada. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        /// <summary>
        /// Serializa la lista de turnos en formato Xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGXml_Click(object sender, EventArgs e)
        {
            if (obraTurnos.Lista.Count > 0)
            {
                try
                {
                    if (Serealizadores<Turno>.SerealizarXML("datosSerealizados.xml", obraTurnos.Lista))
                    {
                        MessageBox.Show("Archivo guardado con éxito!.", "Guardado finalizado!.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SerealizadoresException ex)
                {
                    MessageBox.Show(ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al cargar el archivo", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lista sin Turnos. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Deserializa los turnos contenidos en el archivo xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCXml_Click(object sender, EventArgs e)
        {
            try
            {
                ObraSocial<Turno> aux = new ObraSocial<Turno>();

                aux.Lista = Serealizadores<Turno>.DeserealizarXML("datosSerealizados.xml");

                foreach (Turno item in aux.Lista)
                {
                    obraTurnos.Agregar(item);
                    obraClientes.Agregar(new Persona(item.NombreCompleto, item.Dni));

                }

                this.listar();

            }
            catch (SerealizadoresException ex)
            {
                MessageBox.Show(ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un problema al cargar los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Serialziza los turnos contenidos en formato Json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGJson_Click(object sender, EventArgs e)
        {
            if(obraTurnos.Lista.Count > 0)
            {
                try
                {
                    if(Serealizadores<Turno>.SerealizarJson("datosSerealizadosJSON.json", obraTurnos.Lista))
                    {
                        MessageBox.Show("Archivo guardado con éxito!.", "Guardado finalizado!.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (ListaVaciaException ex)
                {
                    MessageBox.Show("Excepcion Controlada. " + ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SerealizadoresException ex)
                {
                    MessageBox.Show(ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al guardar los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lista sin Turnos. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Deserealiza los turnos del archivo Json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCJson_Click(object sender, EventArgs e)
        {
            try
            {
                ObraSocial<Turno> aux = new ObraSocial<Turno>();

                aux.Lista = Serealizadores<Turno>.DeserealizarJson("datosSerealizadosJSON.json");

                foreach (Turno item in aux.Lista)
                {
                    obraTurnos.Agregar(item);
                    obraClientes.Agregar(new Persona(item.NombreCompleto, item.Dni));

                }

                this.listar();

            }
            catch (SerealizadoresException ex)
            {
                MessageBox.Show(ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un problema al cargar los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Guarda los turnos en formato txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGTxt_Click(object sender, EventArgs e)
        {
            if(obraTurnos.Lista.Count > 0)
            {
                try
                {
                    if(Serealizadores<Turno>.GuardarTxt("datosGuardados.txt", obraTurnos.Mostrar()))
                    {
                        MessageBox.Show("Archivo guardado con éxito!.", "Guardado finalizado!.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SerealizadoresException ex)
                {
                    MessageBox.Show(ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al guardar los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lista sin Turnos. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Carga todos los datos desde la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCargarTSQL_Click(object sender, EventArgs e)
        {
            try
            {

                if (await GestorBase<Turno>.ProbarConexion())
                {
                    List<Persona> clientesAnteriores = new List<Persona>();
                    List<Turno> turnoAnteriores = new List<Turno>();

                    if (this.obraClientes.Lista.Count != 0)
                    {
                        clientesAnteriores = this.obraClientes.Lista;
                    }
                    if (this.obraTurnos.Lista.Count != 0)
                    {
                        turnoAnteriores = this.obraTurnos.Lista;
                    }

                    this.obraClientes.Lista = await gestorPersonas.LeerDatos(new Persona());
                    this.obraTurnos.Lista = await gestorTurnos.LeerDatos(new Turno());


                    foreach (Persona itemAnteriores in clientesAnteriores)
                    {
                        this.obraClientes.Agregar(itemAnteriores);
                    }
                    foreach (Turno itemsAnteriores in turnoAnteriores)
                    {
                        this.obraTurnos.Agregar(itemsAnteriores);
                    }
                    foreach (Turno item in this.obraTurnos.Lista)
                    {
                        this.obraClientes.Agregar(new Persona(item.NombreCompleto, item.Dni));
                    }

                    this.listar();
                    this.sqlCargado = true;
                }
                else
                {
                    throw new ErrorConSQLException("Hubo un error al conectarse a la base de datos.");
                }
            }
            catch (ErrorConSQLException controlar)
            {
                MessageBox.Show(controlar.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Se produjo un error!.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Guarda los datos contenidos en la base de datos a sus listas respectivamente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnGuardarTurnos_Click(object sender, EventArgs e)
        {
            try
            {
                if (await GestorBase<Turno>.ProbarConexion())
                {
                    await Task.Run(() =>
                    {
                        try
                        {
                            if (this.obraClientes.Lista.Count != 0)
                            {
                                GestorBaseExtension.EliminarTodoo(gestorTurnos);
                            }

                            foreach (Persona item in this.obraClientes.Lista)
                            {
                                gestorPersonas.Agregar(item);
                            }
                            foreach (Turno item in this.obraTurnos.Lista)
                            {
                                gestorTurnos.Agregar(item);
                            }
                            MessageBox.Show("Cambios realizados!.");
                        }
                        catch(Exception)
                        {
                            MessageBox.Show("Se produjo un error!.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                else
                {
                    throw new ErrorConSQLException("No se pudo conectar a la base de datos para guardar!.");
                }
            }
            catch (ErrorConSQLException controlar)
            {
                MessageBox.Show(controlar.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Se produjo un error!.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Verifica si la opcion "Actualizacion automatica" esta disponible, y si lo está, la activará
        /// caso contrario, notificara y cancelara
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void chkAutomatico_Click(object sender, EventArgs e)
        {
            if (this.chkAutomatico.Checked == true)
            {
                this.chkAutomatico.Checked = false;
                try
                {
                    if (await GestorBase<Turno>.ProbarConexion())
                    {
                        this.chkAutomatico.Checked = true;

                        this.btnCargarTSQL_Click(sender, e);
                    }
                }
                catch (ErrorConSQLException controlar)
                {
                    MessageBox.Show(controlar.Message + "\nLa basee datos no esta encendida, o no se encuentra.!" + "\nNo se puede activar la actualizacion automatica.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.chkAutomatico.Checked = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Se produjo un error con la base de datos\n.No esta encendida, o no se encuentra.!.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.chkAutomatico.Checked = false;
                }
            }
        }
        #endregion
    }
}