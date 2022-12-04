using Business;
using Model;
namespace ViewForm
{
    public partial class PanelPrincipal : Form
    {
        public Add FormAdd;
        public PanelPrincipal()
        {
            FormAdd = new Add(this);
            InitializeComponent();
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            FormAdd.editar = false;
            var ejercicio = await Business.BusinessCalls.DameAllEjercicio();
            FormAdd.id = ejercicio.Count();
            FormAdd.Show();
            FormAdd.Cambiar(true);
            FormAdd.LimpiarCampos();
            this.Hide();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (await IsValid(textBox1))
            {
                int id = Int32.Parse(textBox1.Text);
                FormAdd.editar = true;
                FormAdd.id = id;
                var ejericio = await Business.BusinessCalls.DameEjercicio(id);
                FormAdd.RellenarCampos(ejericio);
                FormAdd.Show();
                FormAdd.Cambiar(false);
                this.Hide();
            }
        }
        private async Task<bool> IsValid(TextBox texbox)
        {
            if(textBox1.Text != string.Empty){
                int id = Int32.Parse(textBox1.Text);
                var ejercicio = await Business.BusinessCalls.DameEjercicio(id);
                if (ejercicio.DameString() is not null)
                {
                    return true;
                }
            }
            return false;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var listejercitos = await Business.BusinessCalls.DameAllEjercicio();
            MostrarTabla(listejercitos);
        }

        private void MostrarTabla(IEnumerable<Object> lista)
        {
            int cont = 0;
            foreach (Ejercicio ej in lista)
            {
                this.dataGridView1.Rows.Insert(cont, ej.Id.ToString(), ej.Nombre, ej.Descripcion, ej.Dificultad.ToString(), ej.Basico.ToString(), ej.MaterialNecesario, "Musculos", ej.FechaModificacion.ToString());
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (await IsValid(textBox1))
            {
                int id = Int32.Parse(textBox1.Text);
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

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            Business.BusinessCalls.ReloadFichero();
        }

        private async void btnMostrarPorFecha_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            dataGridView1.Rows.Clear();
            var ejercicio = await Business.BusinessCalls.DameEjerciciosFecha(date);
            List<Ejercicio> list = ejercicio;
            MostrarTabla(list);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Checkeo();
        }

        public async void Checkeo()
        {
            if (await IsValid(textBox1))
            {
                dataGridView1.Rows.Clear();
                int id = Int32.Parse(textBox1.Text);
                List<Ejercicio> list = new List<Ejercicio>();
                var ejercicio = await Business.BusinessCalls.DameEjercicio(id);
                list.Add(ejercicio);
                MostrarTabla(list);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBoxModos.SelectedIndex == -1)
            {
                labelModo.Text = "Selecciona un modo.";
            }else
            if (comboBoxModos.SelectedIndex == 0)
            {
                labelModo.Text = "Modo memoria.";
                BusinessCalls.ChangeDataAccess(0);
            }
            else
            if (comboBoxModos.SelectedIndex == 1)
            {
                labelModo.Text = "Modo JSON.";
                BusinessCalls.ChangeDataAccess(1);
            }
            else
            if (comboBoxModos.SelectedIndex == 2)
            {
                labelModo.Text = "Modo a pelo.";
                BusinessCalls.ChangeDataAccess(2);
            }
            else
            if (comboBoxModos.SelectedIndex == 3)
            {
                labelModo.Text = "Modo bytes.";
                BusinessCalls.ChangeDataAccess(3);
            }
            else
            if (comboBoxModos.SelectedIndex == 4)
            {
                labelModo.Text = "Modo XML.";
                BusinessCalls.ChangeDataAccess(4);
            }
            Checkeo();
        }
    }
}