
namespace Formulario
{
    partial class FormAgregarSocio
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
            this.txtBNombre = new System.Windows.Forms.TextBox();
            this.txtBApellido = new System.Windows.Forms.TextBox();
            this.txtBDni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(43, 269);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 43);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(201, 269);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 43);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtBNombre
            // 
            this.txtBNombre.Location = new System.Drawing.Point(43, 50);
            this.txtBNombre.Name = "txtBNombre";
            this.txtBNombre.ShortcutsEnabled = false;
            this.txtBNombre.Size = new System.Drawing.Size(100, 23);
            this.txtBNombre.TabIndex = 2;
            this.txtBNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBNombre_KeyPress);
            // 
            // txtBApellido
            // 
            this.txtBApellido.Location = new System.Drawing.Point(43, 114);
            this.txtBApellido.Name = "txtBApellido";
            this.txtBApellido.ShortcutsEnabled = false;
            this.txtBApellido.Size = new System.Drawing.Size(100, 23);
            this.txtBApellido.TabIndex = 3;
            this.txtBApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBNombre_KeyPress);
            // 
            // txtBDni
            // 
            this.txtBDni.Location = new System.Drawing.Point(43, 180);
            this.txtBDni.Name = "txtBDni";
            this.txtBDni.ShortcutsEnabled = false;
            this.txtBDni.Size = new System.Drawing.Size(100, 23);
            this.txtBDni.TabIndex = 4;
            this.txtBDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBDni_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Apellido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dni:";
            // 
            // FormAgregarSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 332);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBDni);
            this.Controls.Add(this.txtBApellido);
            this.Controls.Add(this.txtBNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAgregarSocio";
            this.Text = "Agregar Clientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAgregarCliente_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtBNombre;
        public System.Windows.Forms.TextBox txtBApellido;
        public System.Windows.Forms.TextBox txtBDni;
    }
}