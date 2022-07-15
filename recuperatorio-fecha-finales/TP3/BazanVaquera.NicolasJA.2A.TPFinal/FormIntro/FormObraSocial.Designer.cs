
namespace Formulario
{
    partial class FormObraSocial
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
            this.grpBoxAgregar = new System.Windows.Forms.GroupBox();
            this.btnAddTurno = new System.Windows.Forms.Button();
            this.btnAddPers = new System.Windows.Forms.Button();
            this.grpBoxModificar = new System.Windows.Forms.GroupBox();
            this.btnModTurno = new System.Windows.Forms.Button();
            this.btnModCliente = new System.Windows.Forms.Button();
            this.grpBoxEliminar = new System.Windows.Forms.GroupBox();
            this.btnEliminarTurno = new System.Windows.Forms.Button();
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.grpListClientes = new System.Windows.Forms.GroupBox();
            this.lstBClientes = new System.Windows.Forms.ListBox();
            this.grpBoxListTurnos = new System.Windows.Forms.GroupBox();
            this.lstBTurnos = new System.Windows.Forms.ListBox();
            this.btnGXml = new System.Windows.Forms.Button();
            this.grpXml = new System.Windows.Forms.GroupBox();
            this.btnCXml = new System.Windows.Forms.Button();
            this.grpJson = new System.Windows.Forms.GroupBox();
            this.btnCJson = new System.Windows.Forms.Button();
            this.btnGJson = new System.Windows.Forms.Button();
            this.grpTxt = new System.Windows.Forms.GroupBox();
            this.btnGTxt = new System.Windows.Forms.Button();
            this.grpBoxAgregar.SuspendLayout();
            this.grpBoxModificar.SuspendLayout();
            this.grpBoxEliminar.SuspendLayout();
            this.grpListClientes.SuspendLayout();
            this.grpBoxListTurnos.SuspendLayout();
            this.grpXml.SuspendLayout();
            this.grpJson.SuspendLayout();
            this.grpTxt.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxAgregar
            // 
            this.grpBoxAgregar.Controls.Add(this.btnAddTurno);
            this.grpBoxAgregar.Controls.Add(this.btnAddPers);
            this.grpBoxAgregar.Location = new System.Drawing.Point(21, 12);
            this.grpBoxAgregar.Name = "grpBoxAgregar";
            this.grpBoxAgregar.Size = new System.Drawing.Size(158, 150);
            this.grpBoxAgregar.TabIndex = 0;
            this.grpBoxAgregar.TabStop = false;
            this.grpBoxAgregar.Text = "Agregar";
            // 
            // btnAddTurno
            // 
            this.btnAddTurno.Location = new System.Drawing.Point(6, 94);
            this.btnAddTurno.Name = "btnAddTurno";
            this.btnAddTurno.Size = new System.Drawing.Size(146, 31);
            this.btnAddTurno.TabIndex = 1;
            this.btnAddTurno.Text = "Agregar Turno";
            this.btnAddTurno.UseVisualStyleBackColor = true;
            this.btnAddTurno.Click += new System.EventHandler(this.btnAddTurno_Click);
            // 
            // btnAddPers
            // 
            this.btnAddPers.Location = new System.Drawing.Point(6, 34);
            this.btnAddPers.Name = "btnAddPers";
            this.btnAddPers.Size = new System.Drawing.Size(146, 31);
            this.btnAddPers.TabIndex = 0;
            this.btnAddPers.Text = "Agregar Cliente";
            this.btnAddPers.UseVisualStyleBackColor = true;
            this.btnAddPers.Click += new System.EventHandler(this.btnAddPers_Click);
            // 
            // grpBoxModificar
            // 
            this.grpBoxModificar.Controls.Add(this.btnModTurno);
            this.grpBoxModificar.Controls.Add(this.btnModCliente);
            this.grpBoxModificar.Location = new System.Drawing.Point(21, 168);
            this.grpBoxModificar.Name = "grpBoxModificar";
            this.grpBoxModificar.Size = new System.Drawing.Size(158, 150);
            this.grpBoxModificar.TabIndex = 1;
            this.grpBoxModificar.TabStop = false;
            this.grpBoxModificar.Text = "Modificar";
            // 
            // btnModTurno
            // 
            this.btnModTurno.Location = new System.Drawing.Point(6, 94);
            this.btnModTurno.Name = "btnModTurno";
            this.btnModTurno.Size = new System.Drawing.Size(146, 40);
            this.btnModTurno.TabIndex = 1;
            this.btnModTurno.Text = "Modificar Turno (seleccionar)";
            this.btnModTurno.UseVisualStyleBackColor = true;
            this.btnModTurno.Click += new System.EventHandler(this.btnModTurno_Click);
            // 
            // btnModCliente
            // 
            this.btnModCliente.Location = new System.Drawing.Point(6, 34);
            this.btnModCliente.Name = "btnModCliente";
            this.btnModCliente.Size = new System.Drawing.Size(146, 41);
            this.btnModCliente.TabIndex = 0;
            this.btnModCliente.Text = "Modificar Cliente (seleccionar)";
            this.btnModCliente.UseVisualStyleBackColor = true;
            this.btnModCliente.Click += new System.EventHandler(this.btnModCliente_Click);
            // 
            // grpBoxEliminar
            // 
            this.grpBoxEliminar.Controls.Add(this.btnEliminarTurno);
            this.grpBoxEliminar.Controls.Add(this.btnEliminarCliente);
            this.grpBoxEliminar.Location = new System.Drawing.Point(21, 328);
            this.grpBoxEliminar.Name = "grpBoxEliminar";
            this.grpBoxEliminar.Size = new System.Drawing.Size(158, 150);
            this.grpBoxEliminar.TabIndex = 2;
            this.grpBoxEliminar.TabStop = false;
            this.grpBoxEliminar.Text = "Eliminar";
            // 
            // btnEliminarTurno
            // 
            this.btnEliminarTurno.Location = new System.Drawing.Point(6, 94);
            this.btnEliminarTurno.Name = "btnEliminarTurno";
            this.btnEliminarTurno.Size = new System.Drawing.Size(146, 39);
            this.btnEliminarTurno.TabIndex = 1;
            this.btnEliminarTurno.Text = "Eliminar Turno (seleccionar)";
            this.btnEliminarTurno.UseVisualStyleBackColor = true;
            this.btnEliminarTurno.Click += new System.EventHandler(this.btnEliminarTurno_Click);
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.Location = new System.Drawing.Point(6, 34);
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.Size = new System.Drawing.Size(146, 39);
            this.btnEliminarCliente.TabIndex = 0;
            this.btnEliminarCliente.Text = "Eliminar Cliente";
            this.btnEliminarCliente.UseVisualStyleBackColor = true;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
            // 
            // grpListClientes
            // 
            this.grpListClientes.Controls.Add(this.lstBClientes);
            this.grpListClientes.Location = new System.Drawing.Point(203, 12);
            this.grpListClientes.Name = "grpListClientes";
            this.grpListClientes.Size = new System.Drawing.Size(642, 231);
            this.grpListClientes.TabIndex = 4;
            this.grpListClientes.TabStop = false;
            this.grpListClientes.Text = "Lista Clientes";
            // 
            // lstBClientes
            // 
            this.lstBClientes.FormattingEnabled = true;
            this.lstBClientes.ItemHeight = 15;
            this.lstBClientes.Location = new System.Drawing.Point(7, 23);
            this.lstBClientes.Name = "lstBClientes";
            this.lstBClientes.Size = new System.Drawing.Size(629, 199);
            this.lstBClientes.TabIndex = 0;
            // 
            // grpBoxListTurnos
            // 
            this.grpBoxListTurnos.Controls.Add(this.lstBTurnos);
            this.grpBoxListTurnos.Location = new System.Drawing.Point(203, 262);
            this.grpBoxListTurnos.Name = "grpBoxListTurnos";
            this.grpBoxListTurnos.Size = new System.Drawing.Size(642, 216);
            this.grpBoxListTurnos.TabIndex = 5;
            this.grpBoxListTurnos.TabStop = false;
            this.grpBoxListTurnos.Text = "Lista Turnos";
            // 
            // lstBTurnos
            // 
            this.lstBTurnos.FormattingEnabled = true;
            this.lstBTurnos.ItemHeight = 15;
            this.lstBTurnos.Location = new System.Drawing.Point(6, 26);
            this.lstBTurnos.Name = "lstBTurnos";
            this.lstBTurnos.Size = new System.Drawing.Size(630, 184);
            this.lstBTurnos.TabIndex = 0;
            // 
            // btnGXml
            // 
            this.btnGXml.Location = new System.Drawing.Point(18, 25);
            this.btnGXml.Name = "btnGXml";
            this.btnGXml.Size = new System.Drawing.Size(121, 31);
            this.btnGXml.TabIndex = 6;
            this.btnGXml.Text = "Guardar";
            this.btnGXml.UseVisualStyleBackColor = true;
            this.btnGXml.Click += new System.EventHandler(this.btnGXml_Click);
            // 
            // grpXml
            // 
            this.grpXml.Controls.Add(this.btnCXml);
            this.grpXml.Controls.Add(this.btnGXml);
            this.grpXml.Location = new System.Drawing.Point(864, 21);
            this.grpXml.Name = "grpXml";
            this.grpXml.Size = new System.Drawing.Size(157, 141);
            this.grpXml.TabIndex = 7;
            this.grpXml.TabStop = false;
            this.grpXml.Text = "Funciones Xml Turnos";
            // 
            // btnCXml
            // 
            this.btnCXml.Location = new System.Drawing.Point(18, 85);
            this.btnCXml.Name = "btnCXml";
            this.btnCXml.Size = new System.Drawing.Size(121, 31);
            this.btnCXml.TabIndex = 7;
            this.btnCXml.Text = "Cargar";
            this.btnCXml.UseVisualStyleBackColor = true;
            this.btnCXml.Click += new System.EventHandler(this.btnCXml_Click);
            // 
            // grpJson
            // 
            this.grpJson.Controls.Add(this.btnCJson);
            this.grpJson.Controls.Add(this.btnGJson);
            this.grpJson.Location = new System.Drawing.Point(864, 177);
            this.grpJson.Name = "grpJson";
            this.grpJson.Size = new System.Drawing.Size(157, 141);
            this.grpJson.TabIndex = 8;
            this.grpJson.TabStop = false;
            this.grpJson.Text = "Fuciones Json Turnos";
            // 
            // btnCJson
            // 
            this.btnCJson.Location = new System.Drawing.Point(18, 85);
            this.btnCJson.Name = "btnCJson";
            this.btnCJson.Size = new System.Drawing.Size(121, 31);
            this.btnCJson.TabIndex = 9;
            this.btnCJson.Text = "Cargar";
            this.btnCJson.UseVisualStyleBackColor = true;
            this.btnCJson.Click += new System.EventHandler(this.btnCJson_Click);
            // 
            // btnGJson
            // 
            this.btnGJson.Location = new System.Drawing.Point(18, 25);
            this.btnGJson.Name = "btnGJson";
            this.btnGJson.Size = new System.Drawing.Size(121, 31);
            this.btnGJson.TabIndex = 8;
            this.btnGJson.Text = "Guardar";
            this.btnGJson.UseVisualStyleBackColor = true;
            this.btnGJson.Click += new System.EventHandler(this.btnGJson_Click);
            // 
            // grpTxt
            // 
            this.grpTxt.Controls.Add(this.btnGTxt);
            this.grpTxt.Location = new System.Drawing.Point(864, 337);
            this.grpTxt.Name = "grpTxt";
            this.grpTxt.Size = new System.Drawing.Size(157, 141);
            this.grpTxt.TabIndex = 9;
            this.grpTxt.TabStop = false;
            this.grpTxt.Text = "Funciones Txt Turnos";
            // 
            // btnGTxt
            // 
            this.btnGTxt.Location = new System.Drawing.Point(18, 65);
            this.btnGTxt.Name = "btnGTxt";
            this.btnGTxt.Size = new System.Drawing.Size(121, 31);
            this.btnGTxt.TabIndex = 8;
            this.btnGTxt.Text = "Guardar";
            this.btnGTxt.UseVisualStyleBackColor = true;
            this.btnGTxt.Click += new System.EventHandler(this.btnGTxt_Click);
            // 
            // FormObraSocial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 490);
            this.Controls.Add(this.grpTxt);
            this.Controls.Add(this.grpJson);
            this.Controls.Add(this.grpXml);
            this.Controls.Add(this.grpBoxListTurnos);
            this.Controls.Add(this.grpListClientes);
            this.Controls.Add(this.grpBoxEliminar);
            this.Controls.Add(this.grpBoxModificar);
            this.Controls.Add(this.grpBoxAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormObraSocial";
            this.Text = "Menu principal";
            this.grpBoxAgregar.ResumeLayout(false);
            this.grpBoxModificar.ResumeLayout(false);
            this.grpBoxEliminar.ResumeLayout(false);
            this.grpListClientes.ResumeLayout(false);
            this.grpBoxListTurnos.ResumeLayout(false);
            this.grpXml.ResumeLayout(false);
            this.grpJson.ResumeLayout(false);
            this.grpTxt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxAgregar;
        private System.Windows.Forms.Button btnAddTurno;
        private System.Windows.Forms.Button btnAddPers;
        private System.Windows.Forms.GroupBox grpBoxModificar;
        private System.Windows.Forms.Button btnModTurno;
        private System.Windows.Forms.Button btnModCliente;
        private System.Windows.Forms.GroupBox grpBoxEliminar;
        private System.Windows.Forms.Button btnEliminarTurno;
        private System.Windows.Forms.Button btnEliminarCliente;
        private System.Windows.Forms.GroupBox grpListClientes;
        private System.Windows.Forms.GroupBox grpBoxListTurnos;
        private System.Windows.Forms.Button btnGXml;
        private System.Windows.Forms.GroupBox grpXml;
        private System.Windows.Forms.Button btnCXml;
        private System.Windows.Forms.GroupBox grpJson;
        private System.Windows.Forms.Button btnCJson;
        private System.Windows.Forms.Button btnGJson;
        private System.Windows.Forms.GroupBox grpTxt;
        private System.Windows.Forms.Button btnGTxt;
        public System.Windows.Forms.ListBox lstBTurnos;
        private System.Windows.Forms.ListBox lstBClientes;
    }
}