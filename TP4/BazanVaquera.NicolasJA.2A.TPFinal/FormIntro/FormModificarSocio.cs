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
    public partial class FormModificarSocio : Form
    {
        public FormModificarSocio()
        {
            InitializeComponent();
            this.chkBNombre.Checked = false;
            this.txtBNombre.ReadOnly = true;

        }

        private void chkBNombre_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkBNombre.Checked is true)
            {
                this.txtBNombre.ReadOnly = false;
            }
            else
            {
                this.txtBNombre.ReadOnly = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtBNombre.Text.Length < 3 && txtBNombre.ReadOnly == false)
            {
                MessageBox.Show("Debe completar correctamente los campos.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtBNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txtBDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
