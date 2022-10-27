using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Model;
namespace Business
{
    public static class BusinessCalls
    {
        public static IDataAccess _context = new Data.DataAccessRepository();
        public static Ejercicio DameEjercicio(int id)
        {
            return _context.GetEjercicioAsync(id).Result ?? new Ejercicio() { Id=-1, Nombre="No existe."};
        }
        public static List<Ejercicio> DameAllEjercicio()
        {
            return _context.GetAllEjerciciosAsync().Result ?? new List<Ejercicio>();
        }
    }
}
