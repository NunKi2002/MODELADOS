using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODELADOS
{
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }
        private void AbrirFormulario<MyForm>() where MyForm : Form, new()
        {

            Form formulario;
            formulario = contenedor.Controls.OfType<MyForm>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new MyForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                contenedor.Controls.Add(formulario);
                contenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            //cuando el formulario ya existe
            else
            {
                formulario.BringToFront();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form1>();
        }
    }
}
