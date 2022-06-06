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


        private void btnAddPers_Click(object sender, EventArgs e)
        {
            FormAgregarSocio form = new FormAgregarSocio();
            try
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Int32 aux;
                    Int32.TryParse((form.txtBDni.Text), out aux);//podria poner una excepcion

                    Persona usar = new Persona(form.txtBNombre.Text + " " + form.txtBApellido.Text, aux);

                    this.obraClientes.Agregar(usar);
                    //this.lstBClientes.Items.Add(usar);
                    lstBClientes.Items.Clear();
                    ListarClientes();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Hubo un problema al agregar al Cliente los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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



                            obraTurnos.Agregar(new Turno(obraClientes.Lista[indice],
                                new DateTime(fecha.Year, fecha.Month, fecha.Day, horas, 0, 0), form.cmbMedicos.SelectedItem.ToString(), (Derivacion)form.cmbDerivacion.SelectedItem));


                            this.lstBTurnos.Items.Clear();
                            ListarTurnos();
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

        private void btnModCliente_Click(object sender, EventArgs e)
        {
            FormModificarSocio form = new FormModificarSocio();
            
            if(form.ShowDialog() == DialogResult.OK)
            {
                if(obraClientes.Lista.Count > 0)
                {
                    try
                    {
                        if(lstBClientes.SelectedIndex != -1)
                        {
                            Int32 indiceTurnos;
                            Boolean existeUnTurno = obraTurnos.BuscarDni(obraClientes.Lista[lstBClientes.SelectedIndex].Dni, out indiceTurnos);
                            if (form.txtBNombre.ReadOnly == false)
                            {
                                obraClientes.Modificar(obraClientes.Lista[lstBClientes.SelectedIndex], form.txtBNombre.Text);
                                if (existeUnTurno)
                                {
                                    obraTurnos.Modificar(obraTurnos.Lista[indiceTurnos], form.txtBNombre.Text);
                                }
                            }
                            if (form.txtBNuevoDni.ReadOnly == false)
                            {
                                obraClientes.Modificar(obraClientes.Lista[lstBClientes.SelectedIndex], Int32.Parse(form.txtBNuevoDni.Text));
                                if (existeUnTurno)
                                {
                                    obraTurnos.Modificar(obraTurnos.Lista[indiceTurnos], Int32.Parse(form.txtBNuevoDni.Text));
                                }
                                else
                                {
                                    MessageBox.Show("No ha seleccionado ningun Cliente", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            this.lstBClientes.Items.Clear();
                            this.lstBTurnos.Items.Clear();
                            ListarClientes();
                            ListarTurnos();
                        }
                        else
                        {
                            MessageBox.Show("Dni no encontrado!. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Hubo un problema al modificar los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lista sin Clientes. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModTurno_Click(object sender, EventArgs e)
        {
            FormModificarTurno form = new FormModificarTurno();

            if(form.ShowDialog() == DialogResult.OK)
            {
                if(obraTurnos.Lista.Count > 0)
                {
                    try
                    {
                        if (lstBTurnos.SelectedIndex != -1)
                        {
                            if (form.cmbDerivacion.Enabled == true)
                            {
                                obraTurnos.Modificar(obraTurnos.Lista[lstBTurnos.SelectedIndex], (Derivacion)form.cmbDerivacion.SelectedItem);
                            }
                            if (form.cmbMedicos.Enabled == true)
                            {
                                obraTurnos.Modificar(form.cmbMedicos.Text, obraTurnos.Lista[lstBTurnos.SelectedIndex]);
                            }
                            if (form.dateTimeFecha.Enabled == true)
                            {
                                Int32 horas;

                                DateTime fecha = new DateTime();
                                fecha = form.dateTimeFecha.Value;
                                Int32.TryParse(form.txtBHora.Text, out horas);
                                fecha.AddHours(horas);
                                obraTurnos.Modificar(obraTurnos.Lista[lstBTurnos.SelectedIndex], new DateTime(fecha.Year, fecha.Month, fecha.Day, horas, 0, 0));
                            }
                            this.lstBTurnos.Items.Clear();
                            ListarTurnos();

                        }
                        else
                        {
                            MessageBox.Show("No ha seleccionado ningun Turno", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Hubo un problema al modificar el Turno", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Lista sin Turnos. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            FormEliminarSocio form = new FormEliminarSocio();

            if(form.ShowDialog() == DialogResult.OK)
            {
                if (obraClientes.Lista.Count > 0)
                {
                    if (obraClientes.Lista.Count > 0)
                    {
                        try
                        {
                            Int32 aux;
                            Int32.TryParse((form.txtBDni.Text), out aux);
                            Int32 indice;
                            if (obraClientes.BuscarDni(aux, out indice))
                            {
                                obraClientes.Eliminar(obraClientes.Lista[indice]);
                                if (obraTurnos.Lista.Count > 0 && obraTurnos.BuscarDni(aux, out indice))
                                {
                                    obraTurnos.Eliminar(obraTurnos.Lista[indice]);
                                }

                                lstBClientes.Items.Clear();
                                lstBTurnos.Items.Clear();
                                ListarClientes();
                                ListarTurnos();
                            }
                            else
                            {
                                MessageBox.Show("Dni no encontrado!. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch(Exception)
                        {
                            MessageBox.Show("Hubo un problema al eliminar el Cliente", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lista sin Clientes. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            FormEliminarTurno form = new FormEliminarTurno();

            //if(form.ShowDialog() == DialogResult.OK)
            //{
                if(obraTurnos.Lista.Count > 0)
                {
                    try
                    {
                        if(lstBTurnos.SelectedIndex != -1)
                        {
                            obraTurnos.Eliminar(obraTurnos.Lista[lstBTurnos.SelectedIndex]);
                            lstBTurnos.Items.Clear();
                            ListarTurnos();
                        }

                        /*
                        Int32 aux;
                        Int32.TryParse((form.txtBDni.Text), out aux);
                        Int32 indice;
                        if (obraTurnos.BuscarDni(aux, out indice))
                        {
                            obraTurnos.Eliminar(obraTurnos.Lista[indice]);

                            lstBTurnos.Items.Clear();
                            ListarTurnos();
                        }*/
                        else
                        {
                            MessageBox.Show("Dni no encontrado!. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Hubo un problema al eliminar el Turno", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lista sin Turnos. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

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
                catch(MiExcepcion)
                {
                    MessageBox.Show("Hubo un problema al cargar el archivo", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lista sin Turnos. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

                lstBClientes.Items.Clear();
                lstBTurnos.Items.Clear();
                ListarClientes();
                ListarTurnos();


                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al cargar los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

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
                catch(Exception)
                {
                    MessageBox.Show("Hubo un problema al guardar los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Lista sin Turnos. Operacion cancelada.", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

                lstBClientes.Items.Clear();
                lstBTurnos.Items.Clear();
                ListarClientes();
                ListarTurnos();


            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un problema al cargar los Datos", "Atencion!.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

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
                catch(Exception)
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
}