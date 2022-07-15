using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace Formulario
{
    public partial class FormObraSocial : Form
    {
        public ObraSocial<Persona> obraClientes;
        public ObraSocial<Turno> obraTurnos;

        public FormObraSocial()
        {
            InitializeComponent();
            this.obraClientes = new ObraSocial<Persona>();
            this.obraTurnos = new ObraSocial<Turno>();
        }
        #region Metodo
        /// <summary>
        /// Metodo que refresca ambas listBox
        /// </summary>
        public void ActualizarLista()
        {
            this.lstBClientes.Items.Clear();
            this.lstBTurnos.Items.Clear();
            ListarClientes();
            ListarTurnos();
        }

        public void ListarClientes()
        {
            foreach (Persona item in obraClientes.Lista)
            {
                this.lstBClientes.Items.Add(item);
            }
        }
        public void ListarTurnos()
        {
            foreach (Turno item in this.obraTurnos.Lista)
            {
                this.lstBTurnos.Items.Add(item);
            }
        }
        #endregion

        #region Botones
        /// <summary>
        /// Añade una persona a la lista de Personas
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

                    if(!(this.obraClientes.Agregar(usar)))
                    {
                        MessageBox.Show("Cliente ya en la lista.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.ActualizarLista();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Hubo un problema al agregar al Cliente los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Añade un turno a la lista de turnos
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

                            Boolean todoOk = false;

                            todoOk = obraTurnos.Agregar(new Turno(obraClientes.Lista[indice],
                                new DateTime(fecha.Year, fecha.Month, fecha.Day, horas, 0, 0), form.cmbMedicos.SelectedItem.ToString(), (Derivacion)form.cmbDerivacion.SelectedItem));

                            if(!todoOk)
                            {
                                MessageBox.Show("Turno rechazado.\n Motivos: Horario, o doctor ocupados", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }


                            this.ActualizarLista();
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
        /// Modifica datos de un cliente seleccionado de la List Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModCliente_Click(object sender, EventArgs e)
        {
            FormModificarSocio form = new FormModificarSocio();
            
            if(form.ShowDialog() == DialogResult.OK)
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
                            }
                            this.ActualizarLista();
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
                    MessageBox.Show("Excepcion Controlada. " + ex.Message + " Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al modificar los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Modifica datos de un turno seleccionado de la List Box
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
                    if (obraTurnos.Lista.Count > 0)
                    {
                        if (lstBTurnos.SelectedIndex != -1)
                        {
                            Int32 indice = lstBTurnos.SelectedIndex;
                            if (form.cmbDerivacion.Enabled == true)
                            {
                                obraTurnos.Modificar(obraTurnos.Lista[indice], (Derivacion)form.cmbDerivacion.SelectedItem, 0);
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
                                obraTurnos.Modificar(obraTurnos.Lista[indice], new DateTime(fecha.Year, fecha.Month, fecha.Day, horas, 0, 0), 0);
                            }
                            this.lstBTurnos.Items.Clear();
                            ListarTurnos();
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
                    MessageBox.Show("Hubo un problema al modificar el Turno", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Elimina un cliente y todos sus turnos correspondientes si es que tiene
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
                                while (obraTurnos.BuscarDni(aux, out indice))
                                {
                                    Turno eliminarT = obraTurnos.Lista[indice];
                                    obraTurnos.Eliminar(obraTurnos.Lista[indice]);
                                }
                            }

                            this.ActualizarLista();
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
        /// Elimina un turno seleccionado de la List Box
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
                        obraTurnos.Eliminar(obraTurnos.Lista[lstBTurnos.SelectedIndex]);
                        this.ActualizarLista();
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
                MessageBox.Show("Hubo un problema al eliminar el Turno", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Guarda la lista de turnos en formato Xml
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
                this.ActualizarLista();
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
                    MessageBox.Show("Hubo un problema al cargar los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                this.ActualizarLista();

            }
            catch(SerealizadoresException ex)
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
                catch(SerealizadoresException ex)
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
    }
    #endregion
}