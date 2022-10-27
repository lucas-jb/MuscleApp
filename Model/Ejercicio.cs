using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ejercicio
    {
        public int Id;
        public string Nombre;
        public string Descripcion;
        public int Dificultad;
        public bool Basico;
        public string MaterialNecesario;
        public List<string> MusculosInvolucrados;
        public DateTime FechaCreacion;

        public string DameString()
        {
            string text =
                        "Id = " + Id.ToString() + Environment.NewLine +
                        "Nombre = " + Nombre + Environment.NewLine +
                        "Descripcion = " + Descripcion + Environment.NewLine +
                        "Dificultad = " + Dificultad.ToString() + Environment.NewLine + 
                        "Basico = " + Basico.ToString() + Environment.NewLine + 
                        "MaterialNecesario = " + MaterialNecesario + Environment.NewLine +
                        "FechaCreacion = " + FechaCreacion.ToString() + Environment.NewLine +
                        "MusculosInvolucrados = " + Environment.NewLine + DameMusculos();
            return text;
    }

        private string DameMusculos()
        {
            if(MusculosInvolucrados is not null)
            {
                string muscles = string.Empty;
                foreach (string muscle in MusculosInvolucrados)
                {
                    muscles = muscles + muscle + Environment.NewLine;
                }
                return muscles;
            }
            return string.Empty;
        }
    }

}
