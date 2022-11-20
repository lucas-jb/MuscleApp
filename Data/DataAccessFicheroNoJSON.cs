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
        private string _ruta = "..\\..\\..\\..\\Data\\Files\\ejerciciosNoJSON.txt";

        public DataAccessFicheroNoJSON()
        {
            List<string> lista = new List<string>();
            lista = File.ReadLines(_ruta).ToList();

            foreach (var item in lista)
            {
                Ejercicio? ejercicio = TextToEjercicio(item);
                _repo.Add(ejercicio ?? new Ejercicio());
            }
        }

        public bool UpdateFichero()
        {
            File.WriteAllText(_ruta, "");
            List<string> lista = new List<string>();
            foreach (var item in _repo)
            {
                string line = EjercicioToText(item); 
                lista.Add(line);
            }
            File.WriteAllLines(_ruta, lista);
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
                    FechaModificacion = DateTime.Parse(subs[6]),
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
            lista = File.ReadAllLines(_ruta).ToList();
            File.WriteAllText(_ruta, "");
            File.WriteAllLines(_ruta, lista);
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

        public Task<List<Ejercicio>> GetAllEjerciciosAsync()
        {
            return Task.Run(() =>
            {
                if (_repo is not null)
                {
                    return _repo;
                }
                return new List<Ejercicio>();
            });
        }

        public Task<Ejercicio> GetEjercicioAsync(int id)
        {
            return Task.Run(() =>
            {
                var ejercicio = _repo.FirstOrDefault(p => p.Id == id);
                if (ejercicio is not null)
                {
                    return ejercicio;
                }
                 return new Ejercicio() { Id = -1, Nombre = "No existe." };
            });
        }

        public Task<List<Ejercicio>> GetEjerciciosFechaAsync(DateTime date)
        {
            return Task.Run(() =>
            {
                if (_repo is not null)
                {
                    List<Ejercicio> lista = new List<Ejercicio>();
                    foreach (var item in _repo)
                    {
                        if (item.FechaModificacion.Year == date.Year && item.FechaModificacion.Month == date.Month && item.FechaModificacion.Day == date.Day)
                        {
                            lista.Add(item);
                        }
                    }
                    return lista;
                }
                return new List<Ejercicio>();
            });
        }
    }
}
