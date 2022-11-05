using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Dificultad { get; set; }
        public bool Basico { get; set; }
        public string MaterialNecesario { get; set; }
        public List<string> MusculosInvolucrados { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string DameString()
        {
            return
                    "Id = " + Id.ToString() + Environment.NewLine +
                    "Nombre = " + Nombre + Environment.NewLine +
                    "Descripcion = " + Descripcion + Environment.NewLine +
                    "Dificultad = " + Dificultad.ToString() + Environment.NewLine + 
                    "Basico = " + Basico.ToString() + Environment.NewLine + 
                    "MaterialNecesario = " + MaterialNecesario + Environment.NewLine +
                    "FechaCreacion = " + FechaCreacion.ToString() + Environment.NewLine +
                    "MusculosInvolucrados = " + Environment.NewLine + DameMusculos();
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

        public string toText()
        {
            return "";
        }
    }

}
