using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public class DataAccessFicheroNoJSON : IDataAccess
    {
        private readonly List<Ejercicio> _repo = new List<Ejercicio>();

        public DataAccessFicheroNoJSON()
        {
            List<string> lista = new List<string>();
            lista = File.ReadLines("ejerciciosNoJSON.txt").ToList();

            foreach (var item in lista)
            {
                Ejercicio? ejercicio = TextToEjercicio(item);
                _repo.Add(ejercicio ?? new Ejercicio());
            }
        }

        public bool UpdateFichero()
        {
            File.WriteAllText("ejerciciosNoJSON.txt", "");
            List<string> lista = new List<string>();
            foreach (var item in _repo)
            {
                string line = EjercicioToText(item); 
                lista.Add(line);
            }
            File.WriteAllLines("ejerciciosNoJSON.txt", lista);
            return true;
        }

        private Ejercicio TextToEjercicio(string item)
        {
            if (item.StartsWith("%"))
            {
                char[] separators = new char[] { '%', ';' };
                string[] subs = item.Split(separators, StringSplitOptions.RemoveEmptyEntries);
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
            }
            return new Ejercicio();
        }

        private string EjercicioToText(Ejercicio ejercicio)
        {
            if(ejercicio is not null)
            {
                return ejercicio.toText();
            }
            return string.Empty;
        }
        public bool ReloadFichero()
        {
            List<string> lista = new List<string>();
            lista = File.ReadAllLines("ejerciciosNoJSON.txt.bak").ToList();
            File.WriteAllText("ejerciciosNoJSON.txt", "");
            File.WriteAllLines("ejerciciosNoJSON.txt", lista);
            return true;
        }
        public bool CreateEjercicio(Ejercicio ejercicio)
        {
            int id = ejercicio.Id;
            if (_repo.FirstOrDefault(p => p.Id == id) is null)
            {
                _repo.Add(ejercicio);
                UpdateFichero();
                return true;
            }
            return false;
        }

        public bool DeleteEjercicio(int id)
        {
            var deleteEjercito = _repo.FirstOrDefault(p => p.Id == id);
            if (deleteEjercito is not null)
            {
                _repo.Remove(deleteEjercito);
                UpdateFichero();
                return true;
            }
            return false;
        }

        public bool EditEjercicio(Ejercicio ejercicio)
        {
            if (DeleteEjercicio(ejercicio.Id))
            {
                return CreateEjercicio(ejercicio);
            }
            return false;
        }

        public async Task<List<Ejercicio>?> GetAllEjerciciosAsync()
        {
            if (_repo is not null)
            {
                return await Task.FromResult(_repo);
            }
            return await Task.Run(() => new List<Ejercicio>());
        }

        public async Task<Ejercicio?> GetEjercicioAsync(int id)
        {
            var ejercicio = _repo.FirstOrDefault(p => p.Id == id);
            if (ejercicio is not null)
            {
                return await Task.FromResult(ejercicio);
            }
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
