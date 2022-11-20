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
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int Dificultad { get; set; }
        public bool Basico { get; set; }
        public string MaterialNecesario { get; set; } = string.Empty;
        public List<string> MusculosInvolucrados { get; set; } = new List<string>();
        public DateTime FechaModificacion { get; set; }

        public string DameString()
        {
            return
                    "Id = " + Id.ToString() + Environment.NewLine +
                    "Nombre = " + Nombre + Environment.NewLine +
                    "Descripcion = " + Descripcion + Environment.NewLine +
                    "Dificultad = " + Dificultad.ToString() + Environment.NewLine + 
                    "Basico = " + Basico.ToString() + Environment.NewLine + 
                    "MaterialNecesario = " + MaterialNecesario + Environment.NewLine +
                    "FechaCreacion = " + FechaModificacion.ToString() + Environment.NewLine +
                    "MusculosInvolucrados = " + Environment.NewLine + DameMusculos();
    }

        public string DameMusculos()
        {
            if(MusculosInvolucrados is not null)
            {
                string muscles = string.Empty;
                foreach (string muscle in MusculosInvolucrados)
                {
                    muscles = muscles + muscle + ",";
                }
                return muscles;
            }
            return string.Empty;
        }

        public string toText()
        {
            return "%" + Id.ToString() + ";" + Nombre + ";" + Descripcion + ";" + Dificultad.ToString() + ";" + Basico.ToString() + ";" + MaterialNecesario + ";" + FechaModificacion.ToString() + ";" + DameMusculos();
        }
    }

}
