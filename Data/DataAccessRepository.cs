using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataAccessRepository : IDataAccess
    {
        private readonly List<Ejercicio> _repo = new List<Ejercicio>();

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
                    FechaCreacion = DateTime.Now
                });
            }
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

        public async Task<List<Ejercicio>?> GetAllEjerciciosAsync()
        {
            if(_repo is not null)
            {
                return await Task.FromResult(_repo);
            }
            return await Task.Run(()=>new List<Ejercicio>());
        }

        public async Task<Ejercicio?> GetEjercicioAsync(int id)
        {
            var ejercicio = _repo.FirstOrDefault(p => p.Id == id);
            if(ejercicio is not null)
            {
                return await Task.FromResult(ejercicio);
            }
            return await Task.FromResult(new Ejercicio() { Id = -1, Nombre="No existe."});
        }
    }
}
