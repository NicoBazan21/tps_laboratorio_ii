
namespace Formulario
{
    partial class FormModificarTurno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkBoxDeriv = new System.Windows.Forms.CheckBox();
            this.chkBNuevoMedico = new System.Windows.Forms.CheckBox();
            this.chkBNuevaFecha = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtBDniA
            // 
            this.txtBDniA.Location = new System.Drawing.Point(51, 48);
            this.txtBDniA.Visible = false;
            // 
            // lblDni
            // 
            this.lblDni.Location = new System.Drawing.Point(51, 30);
            this.lblDni.Size = new System.Drawing.Size(63, 15);
            this.lblDni.Text = "Dni actual:";
            this.lblDni.Visible = false;
            // 
            // lblListaDer
            // 
            this.lblListaDer.Size = new System.Drawing.Size(102, 15);
            this.lblListaDer.Text = "Nueva derivacion:";
            // 
            // lblMedico
            // 
            this.lblMedico.Size = new System.Drawing.Size(88, 15);
            this.lblMedico.Text = "Nuevo medico:";
            // 
            // lblFechaD
            // 
            this.lblFechaD.Size = new System.Drawing.Size(76, 15);
            this.lblFechaD.Text = "Nueva fecha:";
            // 
            // lblHora
            // 
            this.lblHora.Size = new System.Drawing.Size(71, 15);
            this.lblHora.Text = "Nueva hora:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // chkBoxDeriv
            // 
            this.chkBoxDeriv.AutoSize = true;
            this.chkBoxDeriv.Location = new System.Drawing.Point(30, 104);
            this.chkBoxDeriv.Name = "chkBoxDeriv";
            this.chkBoxDeriv.Size = new System.Drawing.Size(15, 14);
            this.chkBoxDeriv.TabIndex = 12;
            this.chkBoxDeriv.UseVisualStyleBackColor = true;
            this.chkBoxDeriv.CheckedChanged += new System.EventHandler(this.chkBoxDeriv_CheckedChanged);
            // 
            // chkBNuevoMedico
            // 
            this.chkBNuevoMedico.AutoSize = true;
            this.chkBNuevoMedico.Location = new System.Drawing.Point(30, 160);
            this.chkBNuevoMedico.Name = "chkBNuevoMedico";
            this.chkBNuevoMedico.Size = new System.Drawing.Size(15, 14);
            this.chkBNuevoMedico.TabIndex = 13;
            this.chkBNuevoMedico.UseVisualStyleBackColor = true;
            this.chkBNuevoMedico.CheckedChanged += new System.EventHandler(this.chkBNuevoMedico_CheckedChanged);
            // 
            // chkBNuevaFecha
            // 
            this.chkBNuevaFecha.AutoSize = true;
            this.chkBNuevaFecha.Location = new System.Drawing.Point(30, 211);
            this.chkBNuevaFecha.Name = "chkBNuevaFecha";
            this.chkBNuevaFecha.Size = new System.Drawing.Size(15, 14);
            this.chkBNuevaFecha.TabIndex = 14;
            this.chkBNuevaFecha.UseVisualStyleBackColor = true;
            this.chkBNuevaFecha.CheckedChanged += new System.EventHandler(this.chkBNuevaFecha_CheckedChanged);
            // 
            // FormModificarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 439);
            this.Controls.Add(this.chkBNuevaFecha);
            this.Controls.Add(this.chkBNuevoMedico);
            this.Controls.Add(this.chkBoxDeriv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormModificarTurno";
            this.Text = "Modificar Turno";
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.txtBDniA, 0);
            this.Controls.SetChildIndex(this.lblDni, 0);
            this.Controls.SetChildIndex(this.cmbDerivacion, 0);
            this.Controls.SetChildIndex(this.lblListaDer, 0);
            this.Controls.SetChildIndex(this.lblMedico, 0);
            this.Controls.SetChildIndex(this.cmbMedicos, 0);
            this.Controls.SetChildIndex(this.dateTimeFecha, 0);
            this.Controls.SetChildIndex(this.lblFechaD, 0);
            this.Controls.SetChildIndex(this.lblHora, 0);
            this.Controls.SetChildIndex(this.txtBHora, 0);
            this.Controls.SetChildIndex(this.chkBoxDeriv, 0);
            this.Controls.SetChildIndex(this.chkBNuevoMedico, 0);
            this.Controls.SetChildIndex(this.chkBNuevaFecha, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBoxDeriv;
        private System.Windows.Forms.CheckBox chkBNuevoMedico;
        private System.Windows.Forms.CheckBox chkBNuevaFecha;
    }
}