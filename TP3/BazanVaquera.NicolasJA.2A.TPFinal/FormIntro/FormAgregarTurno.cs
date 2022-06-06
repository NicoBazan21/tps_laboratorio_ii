using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class FormAgregarTurno : Form
    {
        public FormAgregarTurno()
        {
            InitializeComponent();
            cmbDerivacion.Items.Add(Derivacion.Cardiologia);
            cmbDerivacion.Items.Add(Derivacion.Dermatologia);
            cmbDerivacion.Items.Add(Derivacion.MedicoClinico);
            cmbDerivacion.Items.Add(Derivacion.Odontologia);
            cmbDerivacion.Items.Add(Derivacion.Pediatria);
            cmbDerivacion.Items.Add(Derivacion.Traumatologo);
            cmbDerivacion.SelectedIndex = 0;
            cmbMedicos.Items.Add("Lorenzo Prados");
            cmbMedicos.Items.Add("Eloy Hervas");
            cmbMedicos.Items.Add("Karina Riquelme");
            cmbMedicos.SelectedIndex = 0;
            dateTimeFecha.Value = DateTime.Now;
            dateTimeFecha.MinDate = DateTime.Now;
        }

        protected virtual void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBDniA.Text.Length != 8 || (txtBHora.Text.Length < 0 || txtBHora.Text.Length > 3))
                {
                    MessageBox.Show("Debe completar correctamente los campos.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch(Exception)
            {
                this.DialogResult = DialogResult.Cancel;
            }

        }

        private void cmbMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) &&
                (txtBHora.Text.Length > 2 || txtBHora.Text.Length < 1))
            {
                e.Handled = true;
            }
        }

        private void cmbDerivacion_DropDownClosed(object sender, EventArgs e)
        {
            cmbMedicos.Items.Clear();
            switch (cmbDerivacion.SelectedIndex)
            {
                case 0:
                    cmbMedicos.Items.Add("Lorenzo Prados");
                    cmbMedicos.Items.Add("Eloy Hervas");
                    cmbMedicos.Items.Add("Karina Riquelme");
                    break;
                case 1:
                    cmbMedicos.Items.Add("Angel Cantos");
                    cmbMedicos.Items.Add("Imane Aranda");
                    cmbMedicos.Items.Add("Jacinta Puerta");
                    break;
                case 2:
                    cmbMedicos.Items.Add("Flora Delgado");
                    cmbMedicos.Items.Add("Aday Moro");
                    cmbMedicos.Items.Add("Mar Caro");
                    break;
                case 3:
                    cmbMedicos.Items.Add("Francisca Macias");
                    cmbMedicos.Items.Add("Gala Montenegro");
                    cmbMedicos.Items.Add("Nina Lucas");
                    break;
                case 4:
                    cmbMedicos.Items.Add("Teodoro Campoy");
                    cmbMedicos.Items.Add("Moussa Ali");
                    cmbMedicos.Items.Add("Oier Polo");
                    break;
                case 5:
                    cmbMedicos.Items.Add("Eider Garrido");
                    cmbMedicos.Items.Add("Fidel Bonet");
                    cmbMedicos.Items.Add("Sofia Guillen");
                    break;
                case 6:
                    cmbMedicos.Items.Add("Valeriano Del-Rio");
                    cmbMedicos.Items.Add("Martina Serra");
                    cmbMedicos.Items.Add("Rosalia Valero");
                    break;
            }
            cmbMedicos.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
