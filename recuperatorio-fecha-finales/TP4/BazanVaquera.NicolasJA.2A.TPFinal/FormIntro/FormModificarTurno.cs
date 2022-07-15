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
    public partial class FormModificarTurno : FormAgregarTurno
    {
        public FormModificarTurno()
        {
            InitializeComponent();
            this.chkBoxDeriv.Checked = false;
            this.cmbDerivacion.Enabled = false;

            this.chkBNuevaFecha.Checked = false;
            this.dateTimeFecha.Enabled = false;

            this.chkBNuevoMedico.Checked = false;
            this.cmbMedicos.Enabled = false;

            this.txtBHora.ReadOnly = true;
        }

        private void chkBoxDeriv_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkBoxDeriv.Checked is true)
            {
                this.cmbDerivacion.Enabled = true;
            }
            else
            {
                this.cmbDerivacion.Enabled = false;
            }
        }

        private void chkBNuevoMedico_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkBNuevoMedico.Checked is true)
            {
                this.cmbMedicos.Enabled = true;
            }
            else
            {
                this.cmbMedicos.Enabled = false;
            }
        }

        private void chkBNuevaFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkBNuevaFecha.Checked is true)
            {
                this.dateTimeFecha.Enabled = true;
                this.txtBHora.ReadOnly = false;
            }
            else
            {
                this.dateTimeFecha.Enabled = false;
                this.txtBHora.ReadOnly = true;
            }
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            if (((txtBHora.Text.Length < 0 || txtBHora.Text.Length > 3) && txtBHora.ReadOnly == true))
            {
                MessageBox.Show("Debe completar correctamente los campos.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
