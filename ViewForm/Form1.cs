using Business;
using Model;
namespace ViewForm
{
    public partial class Form1 : Form
    {
        public Add FormAdd;
        public Form1()
        {
            FormAdd = new Add(this);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid(textBox1))
            {
                dataGridView1.Rows.Clear();
                int id = Int32.Parse(textBox1.Text);
                List<Ejercicio> list = new List<Ejercicio>();
                list.Add(Business.BusinessCalls.DameEjercicio(id));
                MostrarTabla(list);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAdd.editar = false;
            FormAdd.id = Business.BusinessCalls.DameAllEjercicio().Count();
            FormAdd.Show();
            FormAdd.Cambiar(true);
            FormAdd.LimpiarCampos();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsValid(textBox1))
            {
                int id = Int32.Parse(textBox1.Text);
                FormAdd.editar = true;
                FormAdd.id = id;
                FormAdd.RellenarCampos(Business.BusinessCalls.DameEjercicio(id));
                FormAdd.Show();
                FormAdd.Cambiar(false);
                this.Hide();
            }
        }
        private bool IsValid(TextBox texbox)
        {
            if(textBox1.Text != string.Empty){
                int id = Int32.Parse(textBox1.Text);
                if (Business.BusinessCalls.DameEjercicio(id).DameString() is not null)
                {
                    return true;
                }
            }
            return false;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var listejercitos = Business.BusinessCalls.DameAllEjercicio();
            MostrarTabla(listejercitos);
        }

        private void MostrarTabla(IEnumerable<Object> lista)
        {
            int cont = 0;
            foreach (Ejercicio ej in lista)
            {
                this.dataGridView1.Rows.Insert(cont, ej.Id.ToString(), ej.Nombre, ej.Descripcion, ej.Dificultad.ToString(), ej.Basico.ToString(), ej.MaterialNecesario, "Musculos", ej.FechaCreacion.ToString());
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (IsValid(textBox1))
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

        private void button6_Click(object sender, EventArgs e)
        {
            Business.BusinessCalls.UpdateFichero();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Business.BusinessCalls.ReloadFichero();
        }
    }
}