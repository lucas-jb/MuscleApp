﻿using System;
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public void Cambiar(bool option)
        {
            if(option)
            {
                button2.Text = "Añadir";
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
            textBoxBasico.Text = ejercicio.Basico.ToString();
            textBoxMaterial.Text = ejercicio.MaterialNecesario;
            labelinfo.Text = string.Empty;
        }

        public void LimpiarCampos()
        {
            textBoxId.Text = string.Empty;
            textBoxNombre.Text = string.Empty;
            textBoxDescripcion.Text = string.Empty;
            textBoxDificultad.Text = string.Empty;
            textBoxBasico.Text = string.Empty;
            textBoxMaterial.Text = string.Empty;
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
    }
}
