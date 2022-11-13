using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DataAccessBytes : IDataAccess
    {
        private string _ruta = "..\\..\\..\\..\\Data\\Files\\ejerciciosBytes.txt";
        private int _sumaTotal = 343;
        public DataAccessBytes()
        {
            var id = new byte[5];
            var delete = new byte[1];
            var name = new byte[15];
            var descripcion = new byte[100];
            var basico = new byte[1];
            var material = new byte[100];
            var musculos = new byte[100];
            var fecha = new byte[19];
            var dificultad = new byte[2];
        }

        public bool UpdateFichero()
        {
            return true;
        }
        public bool ReloadFichero()
        {
            return true;
        }
        public bool CreateEjercicio(Ejercicio ejercicio)
        {
            string line = string.Empty;
            line = line + "1";
            line = line + ejercicio.Id.ToString().PadRight(5, ' ');
            line = line + ejercicio.Nombre.ToString().PadRight(15, ' ');
            line = line + ejercicio.Descripcion.ToString().PadRight(100, ' ');
            line = line + ejercicio.Basico.ToString().PadRight(1, ' ');
            line = line + ejercicio.MaterialNecesario.ToString().PadRight(100, ' ');
            line = line + ejercicio.FechaCreacion.ToString().PadRight(19, ' ');
            line = line + ejercicio.Dificultad.ToString().PadRight(2, ' ');
            line = line + ejercicio.DameMusculos().PadRight(100, ' ');
            using (FileStream fs = new FileStream(_ruta, FileMode.Open, FileAccess.Write))
            {
                var ejer = Encoding.ASCII.GetBytes(line);
                fs.Write(ejer, 0 , _sumaTotal);
            }

            return true;
        }
        public bool DeleteEjercicio(int id)
        {
            return false;
        }
        public bool EditEjercicio(Ejercicio ejercicio)
        {
            return false;
        }
        public async Task<List<Ejercicio>?> GetAllEjerciciosAsync()
        {
            using (FileStream fs = new FileStream(_ruta, FileMode.Open, FileAccess.Read))
            {
                List<Ejercicio> listaEjercicios = new List<Ejercicio>();
                var cont = fs.Length / _sumaTotal;
                for (long i = 0; i < cont; i++ )
                {
                    var a = new byte[_sumaTotal];
                    fs.Read(a, 0, _sumaTotal);
                    listaEjercicios.Add(await Task.Run(() => TextToEjercicio(Encoding.ASCII.GetString(a))));
                }
                return await Task.Run(() => listaEjercicios);
            }
        }
        public async Task<Ejercicio?> GetEjercicioAsync(int id)
        {
            using (FileStream fs = new FileStream(_ruta, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(_sumaTotal*id, SeekOrigin.Begin);
                var a = new byte[_sumaTotal];
                fs.Read(a, 0, _sumaTotal);
                string ejercicio = Encoding.ASCII.GetString(a);
                if (ejercicio.Substring(0,1) == "1")
                {
                    return await Task.FromResult(TextToEjercicio(ejercicio));
                }
                else
                {
                    return await Task.FromResult(new Ejercicio() { Id = -1, Nombre = "No existe." });
                }
            }
        }
        private Ejercicio TextToEjercicio(string item)
        {
            string id = item.Substring(1,6);
            string nombre = item.Substring(6,21);
            string descripcion = item.Substring(21,121);
            string basico = item.Substring(121,122);
            string material = item.Substring(122,222);
            string fecha = item.Substring(222,241);
            string dificultad = item.Substring(241, 243);
            string musculos = item.Substring(243, 343);
            return new Ejercicio()
            {
                Id = Int32.Parse(id),
                Nombre = nombre,
                Descripcion = descripcion,
                Dificultad = Int32.Parse(dificultad),
                Basico = basico.Equals("1"),
                MaterialNecesario = material,
                FechaCreacion = DateTime.Parse(fecha),
                MusculosInvolucrados = musculos.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
            } ?? new Ejercicio() { Id = -1, Nombre = "No existe." };
        }
        public async Task<List<Ejercicio>?> GetEjerciciosFechaAsync(DateTime date)
        {

            return await Task.Run(() => new List<Ejercicio>());
        }
    }
}