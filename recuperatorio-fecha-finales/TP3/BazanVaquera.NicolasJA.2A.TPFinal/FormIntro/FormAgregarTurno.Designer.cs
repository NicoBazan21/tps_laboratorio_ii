
namespace Formulario
{
    partial class FormAgregarTurno
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
            this.txtBDniA = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.cmbDerivacion = new System.Windows.Forms.ComboBox();
            this.lblListaDer = new System.Windows.Forms.Label();
            this.lblMedico = new System.Windows.Forms.Label();
            this.cmbMedicos = new System.Windows.Forms.ComboBox();
            this.dateTimeFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaD = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.txtBHora = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(51, 382);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(94, 42);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(247, 382);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 42);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtBDniA
            // 
            this.txtBDniA.Location = new System.Drawing.Point(51, 45);
            this.txtBDniA.Name = "txtBDniA";
            this.txtBDniA.ShortcutsEnabled = false;
            this.txtBDniA.Size = new System.Drawing.Size(121, 23);
            this.txtBDniA.TabIndex = 2;
            this.txtBDniA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBDni_KeyPress);
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(51, 27);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(25, 15);
            this.lblDni.TabIndex = 3;
            this.lblDni.Text = "Dni";
            // 
            // cmbDerivacion
            // 
            this.cmbDerivacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDerivacion.FormattingEnabled = true;
            this.cmbDerivacion.Location = new System.Drawing.Point(51, 100);
            this.cmbDerivacion.Name = "cmbDerivacion";
            this.cmbDerivacion.Size = new System.Drawing.Size(121, 23);
            this.cmbDerivacion.TabIndex = 4;
            this.cmbDerivacion.DropDownClosed += new System.EventHandler(this.cmbDerivacion_DropDownClosed);
            // 
            // lblListaDer
            // 
            this.lblListaDer.AutoSize = true;
            this.lblListaDer.Location = new System.Drawing.Point(51, 82);
            this.lblListaDer.Name = "lblListaDer";
            this.lblListaDer.Size = new System.Drawing.Size(63, 15);
            this.lblListaDer.TabIndex = 5;
            this.lblListaDer.Text = "Derivacion";
            // 
            // lblMedico
            // 
            this.lblMedico.AutoSize = true;
            this.lblMedico.Location = new System.Drawing.Point(51, 138);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(47, 15);
            this.lblMedico.TabIndex = 6;
            this.lblMedico.Text = "Medico";
            // 
            // cmbMedicos
            // 
            this.cmbMedicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedicos.FormattingEnabled = true;
            this.cmbMedicos.Location = new System.Drawing.Point(51, 156);
            this.cmbMedicos.Name = "cmbMedicos";
            this.cmbMedicos.Size = new System.Drawing.Size(121, 23);
            this.cmbMedicos.TabIndex = 7;
            this.cmbMedicos.SelectedIndexChanged += new System.EventHandler(this.cmbMedicos_SelectedIndexChanged);
            // 
            // dateTimeFecha
            // 
            this.dateTimeFecha.Location = new System.Drawing.Point(51, 204);
            this.dateTimeFecha.Name = "dateTimeFecha";
            this.dateTimeFecha.Size = new System.Drawing.Size(287, 23);
            this.dateTimeFecha.TabIndex = 8;
            // 
            // lblFechaD
            // 
            this.lblFechaD.AutoSize = true;
            this.lblFechaD.Location = new System.Drawing.Point(51, 186);
            this.lblFechaD.Name = "lblFechaD";
            this.lblFechaD.Size = new System.Drawing.Size(41, 15);
            this.lblFechaD.TabIndex = 9;
            this.lblFechaD.Text = "Fecha:";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(51, 239);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(36, 15);
            this.lblHora.TabIndex = 10;
            this.lblHora.Text = "Hora:";
            // 
            // txtBHora
            // 
            this.txtBHora.Location = new System.Drawing.Point(51, 258);
            this.txtBHora.Name = "txtBHora";
            this.txtBHora.ShortcutsEnabled = false;
            this.txtBHora.Size = new System.Drawing.Size(121, 23);
            this.txtBHora.TabIndex = 11;
            this.txtBHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // FormAgregarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 450);
            this.Controls.Add(this.txtBHora);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblFechaD);
            this.Controls.Add(this.dateTimeFecha);
            this.Controls.Add(this.cmbMedicos);
            this.Controls.Add(this.lblMedico);
            this.Controls.Add(this.lblListaDer);
            this.Controls.Add(this.cmbDerivacion);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtBDniA);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAgregarTurno";
            this.Text = "Agregar Turno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtBDniA;
        public System.Windows.Forms.ComboBox cmbMedicos;
        public System.Windows.Forms.DateTimePicker dateTimeFecha;
        public System.Windows.Forms.TextBox txtBHora;
        public System.Windows.Forms.ComboBox cmbDerivacion;
        protected System.Windows.Forms.Label lblDni;
        protected System.Windows.Forms.Label lblListaDer;
        protected System.Windows.Forms.Label lblMedico;
        protected System.Windows.Forms.Label lblFechaD;
        protected System.Windows.Forms.Label lblHora;
        protected System.Windows.Forms.Button btnAceptar;
        protected System.Windows.Forms.Button btnCancelar;
    }
}