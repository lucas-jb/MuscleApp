using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public interface IDataAccess
    {
        Task<Ejercicio?> GetEjercicioAsync(int id);
        Task<List<Ejercicio>?> GetAllEjerciciosAsync();
        public bool CreateEjercicio(Ejercicio ejercicio);
        public bool DeleteEjercicio(int id);
        public bool EditEjercicio(Ejercicio ejercicio);
        public bool UpdateFichero();
        public bool ReloadFichero();
    }
}
