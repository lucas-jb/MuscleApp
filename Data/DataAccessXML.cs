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
        private string _ruta = "..\\..\\..\\..\\Data\\Files\\ejerciciosXML.xml";

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
            return Task.Run(() =>
            {
                Thread.Sleep(0);
                List<Ejercicio> listaresultado = new List<Ejercicio>();

                string _id = string.Empty;
                string _nombre = string.Empty;
                string _descripcion = string.Empty;
                string _basico = string.Empty;
                string _material = string.Empty;
                string _fecha = string.Empty;
                string _dificultad = string.Empty;
                string _musculos = string.Empty;

                xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(File.ReadAllText(_ruta));
                XmlNodeList nodos = xmlDocument.GetElementsByTagName("ejercicio");

                foreach (XmlNode a in nodos)
                {
                    _id = a.Attributes.GetNamedItem("id").Value;

                    foreach (XmlNode aux in a.ChildNodes)
                    {
                        if (aux.Name == "nombre")
                        {
                            _nombre = aux.InnerText;
                        }
                        else if (aux.Name == "descripcion")
                        {
                            _descripcion = aux.InnerText;
                        }
                        else if (aux.Name == "basico")
                        {
                            _basico = aux.InnerText;
                        }
                        else if (aux.Name == "material")
                        {
                            _material = aux.InnerText;
                        }
                        else if (aux.Name == "fecha")
                        {
                            _fecha = aux.InnerText;
                        }
                        else if (aux.Name == "dificultad")
                        {
                            _dificultad = aux.InnerText;
                        }
                    }
                    Ejercicio ejercicio = new Ejercicio()
                    {
                        Id = Int32.Parse(_id),
                        Nombre = _nombre,
                        Descripcion = _descripcion,
                        Dificultad = Int32.Parse(_dificultad),
                        Basico = _basico.Equals("True"),
                        MaterialNecesario = _material,
                        FechaModificacion = DateTime.Now
                    };
                    listaresultado.Add(ejercicio);
                }
                return listaresultado;
            });
        }

        public Task<Ejercicio> GetEjercicioAsync(int id)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(0);

                string _id = string.Empty;
                string _nombre = string.Empty;
                string _descripcion = string.Empty;
                string _basico = string.Empty;
                string _material = string.Empty;
                string _fecha = string.Empty;
                string _dificultad = string.Empty;
                string _musculos = string.Empty;

                xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(File.ReadAllText(_ruta));
                XmlNodeList nodos = xmlDocument.GetElementsByTagName("ejercicio");

                foreach (XmlNode a in nodos)
                {
                    if(id == a.Attributes.GetNamedItem("id").Value)
                    {

                    }

                    foreach (XmlNode aux in a.ChildNodes)
                    {
                        if (aux.Name == "nombre")
                        {
                            _nombre = aux.InnerText;
                        }
                        else if (aux.Name == "descripcion")
                        {
                            _descripcion = aux.InnerText;
                        }
                        else if (aux.Name == "basico")
                        {
                            _basico = aux.InnerText;
                        }
                        else if (aux.Name == "material")
                        {
                            _material = aux.InnerText;
                        }
                        else if (aux.Name == "fecha")
                        {
                            _fecha = aux.InnerText;
                        }
                        else if (aux.Name == "dificultad")
                        {
                            _dificultad = aux.InnerText;
                        }
                    }
                    return new Ejercicio()
                    {
                        Id = Int32.Parse(_id),
                        Nombre = _nombre,
                        Descripcion = _descripcion,
                        Dificultad = Int32.Parse(_dificultad),
                        Basico = _basico.Equals("True"),
                        MaterialNecesario = _material,
                        FechaModificacion = DateTime.Now
                    };
                }
            });
        }

        public Task<List<Ejercicio>> GetEjerciciosFechaAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool ReloadFichero()
        {
            xmlDocument.Load(_ruta);
            return true;
        }

        public bool UpdateFichero()
        {
            throw new NotImplementedException();
        }
    }
}
