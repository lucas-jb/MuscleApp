using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Data
{
    public class DataAccessXML : IDataAccess
    {
        XmlDocument xmlDocument = new XmlDocument();
        string xmlText = string.Empty;

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

        public Task<List<Ejercicio>> GetAllEjerciciosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ejercicio> GetEjercicioAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ejercicio>> GetEjerciciosFechaAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool ReloadFichero()
        {
            xmlText = File.ReadAllText("XMLfrutas.xml");
            xmlDocument.LoadXml(xmlText);
            return true;
        }

        public bool UpdateFichero()
        {
            throw new NotImplementedException();
        }
    }
}
