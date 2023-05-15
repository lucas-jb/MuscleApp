using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    public class Utils : IDataAccess
    {

        public bool CreateEjercicio(Ejercicio ejercicio)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.Ejercicios.Add(ejercicio);
                dbContext.SaveChanges();
                return true;
            }
        }
        public bool EditEjercicio(Ejercicio ejercicio)
        {
            using (var dbContext = new MyDbContext())
            {
                var existingCustomer = dbContext.Ejercicios.FirstOrDefault(c => c.Id == ejercicio.Id);
                if (existingCustomer != null)
                {
                    existingCustomer = ejercicio;
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool DeleteEjercicio(int id)
        {
            using (var dbContext = new MyDbContext())
            {
                var ejercicioToDelete = dbContext.Ejercicios.FirstOrDefault(c => c.Id == id);
                if (ejercicioToDelete != null)
                {
                    dbContext.Ejercicios.Remove(ejercicioToDelete);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Task<Ejercicio> GetEjercicioAsync(int id)
        {
            return Task.Run(() =>
            {
                using (var dbContext = new MyDbContext())
                {
                    var ejercicio = dbContext.Ejercicios.FirstOrDefault(c => c.Id == id);
                    if (ejercicio != null)
                    {
                        return ejercicio;
                    }
                    return new Ejercicio() { Id = -1, Nombre = "No existe." };
                }
            });
        }

        public Task<List<Ejercicio>> GetEjerciciosFechaAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ejercicio>> GetAllEjerciciosAsync()
        {
            return Task.Run(() =>
            {
                using (var dbContext = new MyDbContext())
                {
                    return dbContext.Ejercicios.ToList();
                }
            });
        }

        public bool UpdateFichero()
        {
            throw new NotImplementedException();
        }

        public bool ReloadFichero()
        {
            throw new NotImplementedException();
        }
    }
}
