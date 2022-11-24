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
        public static IDataAccess _context { get; set; } =  new Data.DataAccessBytes();
        public static void ChangeDataAccess(int num)
        {
            if(num == 0)
            {
                _context = new Data.DataAccessRepository();
            }
            else
            if (num == 1)
            {
                _context = new Data.DataAccessFichero();
            }
            else
            if (num == 2)
            {
                _context = new Data.DataAccessFicheroNoJSON();
            }
            else
            if (num == 3)
            {
                _context = new Data.DataAccessBytes();
            }else
            if (num == 4)
            {
                _context = new Data.DataAccessBytes();
            }
        }
        public static Task<Ejercicio> DameEjercicio(int id)
        {
            return _context.GetEjercicioAsync(id);
        }
        public static Task<List<Ejercicio>> DameEjerciciosFecha(DateTime date)
        {
            return  _context.GetEjerciciosFechaAsync(date);
        }
        public static Task<List<Ejercicio>> DameAllEjercicio()
        {
            return _context.GetAllEjerciciosAsync();
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
                    return new Ejercicio
                    {
                        Id = Int32.Parse(datos[0]),
                        Nombre = datos[1],
                        Descripcion = datos[2],
                        Dificultad = Int32.Parse(datos[3]),
                        Basico = datos[4].Equals("Si"),
                        MaterialNecesario = datos[5],
                        FechaModificacion = DateTime.Now
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
