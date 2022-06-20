using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*MessageBox.Show("Bienvenido al Sistema de Administración de Turnos de la ObraSocial SiempreViva" +
                "\nSe trata de una Obra Social que permite el ingreso y egreso de Clientes/Socios.\n" +
                "Tambien permite el ingreso y egreso de Turnos Medicos para los Clientes.\n" +
                "Por ultimo, permite guardar el Historial de Turnos, en distintos formatos, asi como \n" +
                "tambien su carga para el uso!.\n" +
                "Que lo disfrute!.","Introduccion",MessageBoxButtons.OK,MessageBoxIcon.Information); ;
            */
            FormObraSocial form = new FormObraSocial();
            form.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(form);
        }
    }
}
