
namespace Formulario
{
    partial class FormModificarSocio
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBNombre = new System.Windows.Forms.CheckBox();
            this.txtBNombre = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtBDniAnt = new System.Windows.Forms.TextBox();
            this.txtBNuevoDni = new System.Windows.Forms.TextBox();
            this.chkNuevoDni = new System.Windows.Forms.CheckBox();
            this.lblNuevoDni = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(44, 287);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 34);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(172, 287);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 34);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nuevo Nombre Completo:";
            // 
            // chkBNombre
            // 
            this.chkBNombre.AutoSize = true;
            this.chkBNombre.Location = new System.Drawing.Point(76, 122);
            this.chkBNombre.Name = "chkBNombre";
            this.chkBNombre.Size = new System.Drawing.Size(15, 14);
            this.chkBNombre.TabIndex = 3;
            this.chkBNombre.UseVisualStyleBackColor = true;
            this.chkBNombre.CheckedChanged += new System.EventHandler(this.chkBNombre_CheckedChanged);
            // 
            // txtBNombre
            // 
            this.txtBNombre.Location = new System.Drawing.Point(98, 118);
            this.txtBNombre.Name = "txtBNombre";
            this.txtBNombre.Size = new System.Drawing.Size(100, 23);
            this.txtBNombre.TabIndex = 4;
            this.txtBNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBNombre_KeyPress);
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(12, 24);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(150, 15);
            this.lblDni.TabIndex = 8;
            this.lblDni.Text = "Dni del Cliente a modificar:";
            this.lblDni.Visible = false;
            // 
            // txtBDniAnt
            // 
            this.txtBDniAnt.Location = new System.Drawing.Point(12, 42);
            this.txtBDniAnt.Name = "txtBDniAnt";
            this.txtBDniAnt.ShortcutsEnabled = false;
            this.txtBDniAnt.Size = new System.Drawing.Size(140, 23);
            this.txtBDniAnt.TabIndex = 10;
            this.txtBDniAnt.Visible = false;
            this.txtBDniAnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBDni_KeyPress);
            // 
            // txtBNuevoDni
            // 
            this.txtBNuevoDni.Location = new System.Drawing.Point(98, 185);
            this.txtBNuevoDni.Name = "txtBNuevoDni";
            this.txtBNuevoDni.Size = new System.Drawing.Size(100, 23);
            this.txtBNuevoDni.TabIndex = 13;
            this.txtBNuevoDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBDni_KeyPress);
            // 
            // chkNuevoDni
            // 
            this.chkNuevoDni.AutoSize = true;
            this.chkNuevoDni.Location = new System.Drawing.Point(76, 189);
            this.chkNuevoDni.Name = "chkNuevoDni";
            this.chkNuevoDni.Size = new System.Drawing.Size(15, 14);
            this.chkNuevoDni.TabIndex = 12;
            this.chkNuevoDni.UseVisualStyleBackColor = true;
            this.chkNuevoDni.CheckedChanged += new System.EventHandler(this.chkNuevoDni_CheckedChanged);
            // 
            // lblNuevoDni
            // 
            this.lblNuevoDni.AutoSize = true;
            this.lblNuevoDni.Location = new System.Drawing.Point(76, 167);
            this.lblNuevoDni.Name = "lblNuevoDni";
            this.lblNuevoDni.Size = new System.Drawing.Size(66, 15);
            this.lblNuevoDni.TabIndex = 11;
            this.lblNuevoDni.Text = "Nuevo Dni:";
            // 
            // FormModificarSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 348);
            this.Controls.Add(this.txtBNuevoDni);
            this.Controls.Add(this.chkNuevoDni);
            this.Controls.Add(this.lblNuevoDni);
            this.Controls.Add(this.txtBDniAnt);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtBNombre);
            this.Controls.Add(this.chkBNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormModificarSocio";
            this.Text = "Modificar Socio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBNombre;
        public System.Windows.Forms.TextBox txtBNombre;
        private System.Windows.Forms.Label lblDni;
        public System.Windows.Forms.TextBox txtBDniAnt;
        public System.Windows.Forms.TextBox txtBNuevoDni;
        private System.Windows.Forms.CheckBox chkNuevoDni;
        private System.Windows.Forms.Label lblNuevoDni;
    }
}