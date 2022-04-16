using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        #region Metodos
        /// <summary>
        /// limpia de texto los txtBox, label y a lstOperaciones
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            labelResultado.ResetText();
            lstOperaciones.Items.Clear();
        }
        /// <summary>
        /// realiza la operacion aritmetica correspondiente
        /// </summary>
        /// <param name="numero1"></param>recibe el primer paramtro en formato string
        /// <param name="numero2"></param>recibe el sgeundo parametro en formato string
        /// <param name="operador"></param>recibe el operador correspondiente
        /// a la operacion aritmetica a realizar
        /// <returns></returns>retorna el resultado de la operacion en formato double
        private static double Operar(String numero1, String numero2, String operador)
        {
            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), operador[0]);
        }

        #endregion

        #region Eventos del Formulario
        /// <summary>
        /// al ejecutarse el evento Load de la calculadora se limpiaran los objetos
        /// que contengan texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            btnLimpiar_Click(sender, e);
        }
        /// <summary>
        /// evento que intercepta el momento previo a comenzar a limpiarse el form de la memoria
        /// preguntara al usuario si esta seguro de Cerrar el Formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Esta seguro de salir?", "Cierre", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region Eventos Click
        //eventos click
        /// <summary>
        /// boton limpiar limpiara a las listas de operaciones y operandos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// realiza a operacion correspondiente entre los operandos ingresados
        /// y los mostrara en la lista de operaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (cmbOperador.Text != "")
            {
                if (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text) == double.MinValue)
                {
                    labelResultado.Text = "Valor inválido!";
                }
                else
                {
                    labelResultado.Text = "" + Math.Round(Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text), 2);
                    if ((Operar(txtNumero1.Text, "0", "+") == 0) && (Operar(txtNumero2.Text, "0", "+") == 0))
                    {
                        lstOperaciones.Items.Add("0" + cmbOperador.Text + "0" + " = " + labelResultado.Text);
                    }
                    else
                    {
                        if (Operar(txtNumero1.Text, "0", "+") == 0)
                        {
                            lstOperaciones.Items.Add("0" + cmbOperador.Text + txtNumero2.Text + " = " + labelResultado.Text);
                        }
                        else if (Operar(txtNumero2.Text, "0", "+") == 0)
                        {
                            lstOperaciones.Items.Add(txtNumero1.Text + cmbOperador.Text + "0" + " = " + labelResultado.Text);
                        }
                        else
                        {
                            lstOperaciones.Items.Add(txtNumero1.Text + cmbOperador.Text + txtNumero2.Text + " = " + labelResultado.Text);
                        }
                    }
                }
            }
            /*labelResultado.Text = "" + Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lstOperaciones.Items.Add(txtNumero1.Text + cmbOperador.Text + txtNumero2.Text + " = " + labelResultado.Text);
            */
        }

        /// <summary>
        /// intentara cerrara el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// convierte el resultado en un numero binario de ser posible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (labelResultado.Text != "")
            {
                double negativo;
                double.TryParse(labelResultado.Text, out negativo);
                negativo = Math.Floor(negativo);
                labelResultado.Text = (new Operando(labelResultado.Text)).DecimalBinario(labelResultado.Text);
                if (labelResultado.Text != "Valor inválido")
                {
                    if (negativo < 0)
                    {
                        negativo *= (-1);
                    }
                    lstOperaciones.Items.Add(negativo + " a binario es: " + labelResultado.Text);
                }
            }
        }
        /// <summary>
        /// convierte el resultado de ser posible a un numero decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (labelResultado.Text != "")
            {
                string aux = labelResultado.Text;
                labelResultado.Text = (new Operando(labelResultado.Text)).BinarioDecimal(labelResultado.Text);
                if (labelResultado.Text != "Valor inválido")
                {
                    lstOperaciones.Items.Add(aux + " a decimal es: " + labelResultado.Text);
                }
            }
        }
        #endregion
    }
}
