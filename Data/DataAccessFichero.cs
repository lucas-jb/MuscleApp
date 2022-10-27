using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataAccessFichero : IDataAccess
    {
        public bool CreateEjercicio(Ejercicio ejercicio)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEjercicio(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditEjercicio(Ejercicio ejercicio)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ejercicio>?> GetAllEjerciciosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ejercicio?> GetEjercicioAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
