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
        public static IDataAccess _context = new Data.DataAccessFichero();
        public static Ejercicio DameEjercicio(int id)
        {
            return _context.GetEjercicioAsync(id).Result ?? new Ejercicio() { Id=-1, Nombre="No existe."};
        }
        public static List<Ejercicio> DameAllEjercicio()
        {
            return _context.GetAllEjerciciosAsync().Result ?? new List<Ejercicio>();
        }
        public static bool DeleteEjercicio(int id)
        {
            return _context.DeleteEjercicio(id);
        }
        public static bool CreateEjercicio(Ejercicio ejercicio)
        {
            return _context.CreateEjercicio(ejercicio);
        }
        public static bool EditEjercicio(Ejercicio ejercicio)
        {
            return _context.EditEjercicio(ejercicio);
        }
        public static Ejercicio ValidateEjercicio(List<string> datos)
        {
            if(datos is not null)
            {
                try
                {
                    bool res;
                    if(datos[4] == "Si")
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
                    }
                    return new Ejercicio
                    {
                        Id = Int32.Parse(datos[0]),
                        Nombre = datos[1],
                        Descripcion = datos[2],
                        Dificultad = Int32.Parse(datos[3]),
                        Basico = res,
                        MaterialNecesario = datos[5]
                    };
                }
                catch
                {
                    return new Ejercicio();
                }
            }
            return new Ejercicio();
        }
        public static bool UpdateFichero()
        {
            return _context.UpdateFichero();
        }

        public static bool ReloadFichero()
        {
            return _context.ReloadFichero();
        }
    }
}
