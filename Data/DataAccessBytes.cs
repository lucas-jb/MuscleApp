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

        public DataAccessBytes()
        {
            var id = new byte[10];
            var name = new byte[10];
            var descripcion = new byte[10];
            var basico = new byte[10];
            var material = new byte[10];
            var fecha = new byte[10];
        }

        public bool UpdateFichero()
        {
            return true;
        }

        private Ejercicio TextToEjercicio(string item)
        {
            return new Ejercicio();
        }

        private string EjercicioToText(Ejercicio ejercicio)
        {
            return string.Empty;
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
            return await Task.FromResult(new Ejercicio() { Id = -1, Nombre = "No existe." });
        }

        public async Task<List<Ejercicio>?> GetEjerciciosFechaAsync(DateTime date)
        {
            if (_repo is not null)
            {
                List<Ejercicio> lista = new List<Ejercicio>();
                foreach (var item in _repo)
                {
                    if (item.FechaCreacion.Year == date.Year && item.FechaCreacion.Month == date.Month && item.FechaCreacion.Day == date.Day)
                    {
                        lista.Add(item);
                    }
                }
                return await Task.FromResult(lista);
            }
            return await Task.Run(() => new List<Ejercicio>());
        }
    }
}