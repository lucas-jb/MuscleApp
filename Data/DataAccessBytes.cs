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
        private readonly List<Ejercicio> _repo = new List<Ejercicio>();
        private string _ruta = "ejerciciosBytes.txt";
        private int _sumaTotal = 236;
        public DataAccessBytes()
        {
            var id = new byte[5];
            var delete = new byte[1];
            var name = new byte[10];
            var descripcion = new byte[100];
            var basico = new byte[1];
            var material = new byte[100];
            var fecha = new byte[19];
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
            return false;
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
            return await Task.Run(() => new List<Ejercicio>());
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
            string nombre = item.Substring(7,17);
            string descripcion = item.Substring(18,118);
            string basico = item.Substring(119,6);
            string material = item.Substring(1,6);
            string fecha = item.Substring(1,6);
            return new Ejercicio()
            {
                Id = Int32.Parse(subs[0]),
                Nombre = subs[1],
                Descripcion = subs[2],
                Dificultad = Int32.Parse(subs[3]),
                Basico = subs[4].Equals("true"),
                MaterialNecesario = subs[5],
                FechaCreacion = DateTime.Parse(subs[6]),
                MusculosInvolucrados = subs[7].Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
            };
            return new Ejercicio();
        }
        public async Task<List<Ejercicio>?> GetEjerciciosFechaAsync(DateTime date)
        {
            return await Task.Run(() => new List<Ejercicio>());
        }
    }
}