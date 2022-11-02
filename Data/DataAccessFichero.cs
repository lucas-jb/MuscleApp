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
    public class DataAccessFichero : IDataAccess
    {
        private readonly List<Ejercicio> _repo = new List<Ejercicio>();

        public DataAccessFichero()
        {
            List<string> lista = new List<string>();
            lista = File.ReadLines("ejercicios.txt").ToList();

            foreach (var item in lista)
            {
                Ejercicio ejercicio = JsonSerializer.Deserialize<Model.Ejercicio>(item);
                _repo.Add(ejercicio);
            }
        }

        public bool CreateEjercicio(Ejercicio ejercicio)
        {
            int id = ejercicio.Id;
            if (_repo.FirstOrDefault(p => p.Id == id) is null)
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
    }
}
