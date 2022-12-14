using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Text.Json;
using System.Text.Json.Serialization;

namespace Data
{
    public class DataAccessRepository : IDataAccess
    {
        private readonly List<Ejercicio> _repo = new();

        public DataAccessRepository()
        {
            for (int i = 0; i < 100; i++)
            {
                _repo.Add(new Ejercicio()
                {
                    Id = (i + 1),
                    Nombre = $"Ejercicio {i + 1}",
                    Descripcion = $"Descripcion {i + 1}",
                    Dificultad = 1,
                    Basico = false,
                    MaterialNecesario = $"MaterialNecesario {i + 1}",
                    MusculosInvolucrados = new List<string>()
                    {
                        "Musculo1",
                        "Musculo2",
                        "Musculo3"
                    },
                    FechaModificacion = DateTime.Now
                });
            }
        }
        public string GetAllString()
        {
            string data = string.Empty;
            foreach (Ejercicio ejercicio in _repo)
            {
                data += ejercicio.toHTML();
            }
            return data;
        }
        public string GetByIdString(int id)
        {
            var ejercicio = _repo.FirstOrDefault(p => p.Id == id);
            if (ejercicio is not null)
            {
                return ejercicio.toHTML();
            }
            return null;
        }

        public bool CreateEjercicio(Ejercicio ejercicio)
        {
            int id = ejercicio.Id;
            if(_repo.FirstOrDefault(p => p.Id == id) is null)
            {
                _repo.Add(ejercicio);
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
        public bool UpdateFichero()
        {
            return false;
        }

        public bool ReloadFichero()
        {
            return false;
        }

        public Task<List<Ejercicio>> GetEjerciciosFechaAsync(DateTime date)
        {
            return Task.Run(() =>
            {
                if (_repo is not null)
                {
                    List<Ejercicio> lista = new();
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
