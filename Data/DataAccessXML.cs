using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Data
{
    public class DataAccessXML : IDataAccess
    {
        XmlDocument xmlDocument = new XmlDocument();
        string xmlText = string.Empty;
        private string _path = "..\\..\\..\\..\\Data\\Files\\ejerciciosXML.xml";

        public bool CreateEjercicio(Ejercicio ejercicio)
        {
            if(ejercicio is not null)
            {
                xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(File.ReadAllText(_path));
                XmlNode Nodeejercicio = xmlDocument.CreateElement("ejercicio");
                XmlAttribute idAttribute = xmlDocument.CreateAttribute("id");
                idAttribute.Value = ejercicio.Id.ToString();
                Nodeejercicio.Attributes.Append(idAttribute);

                Type _type = ejercicio.GetType();

                System.Reflection.PropertyInfo[] listaPropiedades = _type.GetProperties();

                foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
                {
                    if (propiedad.Name != "Id")
                    {
                        XmlNode node = xmlDocument.CreateElement(propiedad.Name);
                        XmlText nodeText = xmlDocument.CreateTextNode(propiedad.GetValue(ejercicio, null).ToString());
                        node.AppendChild(nodeText);
                        Nodeejercicio.AppendChild(node);
                    }
                }
                xmlDocument.FirstChild.NextSibling.AppendChild(Nodeejercicio);
                xmlDocument.Save(_path);
                return true;
            }
            return false;
        }

        public bool DeleteEjercicio(int id)
        {
            if (GetEjercicioAsync(id).Id != -1)
            {
                xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(File.ReadAllText(_path));
                XmlNodeList nodos = xmlDocument.GetElementsByTagName("ejercicio");
                XmlNode ejercicioBorrar = null;

                string _id = id.ToString();
                foreach (XmlNode a in nodos)
                {
                    if (_id.Equals(a.Attributes.GetNamedItem("id").Value))
                    {
                        ejercicioBorrar = a;
                        break;
                    }
                }
                if(ejercicioBorrar != null)
                {
                    xmlDocument.FirstChild.NextSibling.RemoveChild(ejercicioBorrar);
                    xmlDocument.Save(_path);
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool EditEjercicio(Ejercicio ejercicio)
        {
            if(DeleteEjercicio(ejercicio.Id)!= false)
            {
                CreateEjercicio(ejercicio);
                return true;
            }
            return false;
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
                xmlDocument.LoadXml(File.ReadAllText(_path));
                XmlNodeList nodos = xmlDocument.GetElementsByTagName("ejercicio");

                foreach (XmlNode a in nodos)
                {
                    _id = a.Attributes.GetNamedItem("id").Value;

                    foreach (XmlNode aux in a.ChildNodes)
                    {
                        if (aux.Name == "Nombre")
                        {
                            _nombre = aux.InnerText;
                        }
                        else if (aux.Name == "Descripcion")
                        {
                            _descripcion = aux.InnerText;
                        }
                        else if (aux.Name == "Basico")
                        {
                            _basico = aux.InnerText;
                        }
                        else if (aux.Name == "MaterialNecesario")
                        {
                            _material = aux.InnerText;
                        }
                        else if (aux.Name == "FechaModificacion")
                        {
                            _fecha = aux.InnerText;
                        }
                        else if (aux.Name == "Dificultad")
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

                string _id = id.ToString();
                string _nombre = string.Empty;
                string _descripcion = string.Empty;
                string _basico = string.Empty;
                string _material = string.Empty;
                string _fecha = string.Empty;
                string _dificultad = string.Empty;
                string _musculos = string.Empty;

                xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(File.ReadAllText(_path));
                XmlNodeList nodos = xmlDocument.GetElementsByTagName("ejercicio");

                foreach (XmlNode a in nodos)
                {
                    if(_id.Equals(a.Attributes.GetNamedItem("id").Value))
                    {
                        foreach (XmlNode aux in a.ChildNodes)
                        {
                            if (aux.Name == "Nombre")
                            {
                                _nombre = aux.InnerText;
                            }
                            else if (aux.Name == "Descripcion")
                            {
                                _descripcion = aux.InnerText;
                            }
                            else if (aux.Name == "Basico")
                            {
                                _basico = aux.InnerText;
                            }
                            else if (aux.Name == "MaterialNecesario")
                            {
                                _material = aux.InnerText;
                            }
                            else if (aux.Name == "FechaModificacion")
                            {
                                _fecha = aux.InnerText;
                            }
                            else if (aux.Name == "Dificultad")
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
                }
                return new Ejercicio() { Id = -1, Nombre = "No existe." };
            });
        }

        public Task<List<Ejercicio>> GetEjerciciosFechaAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool ReloadFichero()
        {
            xmlDocument.Load(_path);
            return true;
        }

        public bool UpdateFichero()
        {
            throw new NotImplementedException();
        }
    }
}
