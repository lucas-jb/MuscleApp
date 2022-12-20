using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.VistasHTML
{
    public static class ViewParser
    {
        public static Dictionary<int, string> Vistas = new();
        private static string _path = "..\\..\\..\\..\\Data\\VistasHTML\\HTML\\";

        public static void GenerateViews()
        {
            Vistas.Clear();
            Vistas.Add(0, File.ReadAllText(_path+"404.html"));
            Vistas.Add(1, File.ReadAllText(_path+"index.html"));
            Vistas.Add(2, File.ReadAllText(_path+"GetAll.html"));
            Vistas.Add(3, File.ReadAllText(_path+"GetById.html"));
            Vistas.Add(4, File.ReadAllText(_path+"IdNotFound.html"));
            Vistas.Add(5, File.ReadAllText(_path+"deleteById.html"));
            Vistas.Add(6, File.ReadAllText(_path+"editById.html"));
            Vistas.Add(7, File.ReadAllText(_path+"createNew.html"));
        }
        public static string ReturnView(int id)
        {
            if(Vistas[id] != null)
            {
                return Vistas[id];
            }
            return Vistas[0];
        }
    }
}
