using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Model;

namespace ViewForm
{
    public partial class Add : Form
    {
        public bool editar { get; set; } = false;
        public Form1 form1;
        public int id { get; set; } = -1;
        public Add(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
            comboBox1.Items.Add("Si");
            comboBox1.Items.Add("No");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> datos = new List<string>(); 
            datos.Add(textBoxId.Text);
            datos.Add(textBoxNombre.Text);
            datos.Add(textBoxDescripcion.Text);
            datos.Add(textBoxDificultad.Text);
            datos.Add(comboBox1.SelectedItem.ToString());
            datos.Add(textBoxMaterial.Text);
            if (editar)
            {
                Business.BusinessCalls.EditEjercicio(Business.BusinessCalls.ValidateEjercicio(datos));
            }
            else
            {
                Business.BusinessCalls.CreateEjercicio(Business.BusinessCalls.ValidateEjercicio(datos));
            }
        }
        public void Cambiar(bool option)
        {
            if(option)
            {
                button2.Text = "Añadir";
                textBoxId.Text = (BusinessCalls.DameAllEjercicio().Count() + 1).ToString();
            }
            else
            {
                button2.Text = "Editar";
            }
        }
        public void RellenarCampos(Ejercicio ejercicio)
        {
            textBoxId.Text = ejercicio.Id.ToString();
            textBoxNombre.Text = ejercicio.Nombre;
            textBoxDescripcion.Text = ejercicio.Descripcion;
            textBoxDificultad.Text = ejercicio.Dificultad.ToString();
            if (ejercicio.Basico)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
            textBoxMaterial.Text = ejercicio.MaterialNecesario;
            labelinfo.Text = string.Empty;
        }

        public void LimpiarCampos()
        {
            textBoxNombre.Text = string.Empty;
            textBoxDescripcion.Text = string.Empty;
            textBoxDificultad.Text = string.Empty;
            textBoxMaterial.Text = string.Empty;
            comboBox1.SelectedItem = null;
            labelinfo.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IsValid(textBoxId))
            {
                int id = Int32.Parse(textBoxId.Text);
                if (Business.BusinessCalls.DeleteEjercicio(id))
                {
                    labelinfo.Text = "Ejercicio con id " + id.ToString() + " eliminado.";
                }
                else
                {
                    labelinfo.Text = "Ejercicio con id " + id.ToString() + " no se ha podido eliminar.";
                }
            }
        }

        private bool IsValid(TextBox texbox)
        {
            int id = Int32.Parse(textBoxId.Text);
            if (Business.BusinessCalls.DameEjercicio(id).DameString() is not null)
            {
                return true;
            }
            return false;
        }

        private void textBoxDificultad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
