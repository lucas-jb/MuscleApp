using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataAccessDDBB : IDataAccess
    {
        private readonly List<Ejercicio> _repo = new List<Ejercicio>();
        public string connectionString = "Data Source=POTAS\\SQLEXPRESS;Initial Catalog=Ejercicios;Integrated Security=True";


        public bool CreateEjercicio(Ejercicio ejercicio)
        {
            string queryString = "INSERT INTO Ejercicio (Id, Nombre, Descripcion, Dificultad, Basico, MaterialNecesario, FechaModificacion) " +
                                 "VALUES" +
                                 "(@id, @nombre, @descripcion, @dificultad, @basico, @material, @fecha)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(queryString, con))
            {
                cmd.Parameters.AddWithValue("@id", ejercicio.Id);
                cmd.Parameters.AddWithValue("@nombre", ejercicio.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", ejercicio.Descripcion);
                cmd.Parameters.AddWithValue("@dificultad", ejercicio.Dificultad);
                cmd.Parameters.AddWithValue("@basico", ejercicio.Basico);
                cmd.Parameters.AddWithValue("@material", ejercicio.MaterialNecesario);
                cmd.Parameters.AddWithValue("@fecha", ejercicio.FechaModificacion);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public bool DeleteEjercicio(int id)
        {
            string queryString = "DELETE FROM Ejercicio WHERE Id = @id ";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(queryString, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public bool EditEjercicio(Ejercicio ejercicio)
        {
            string queryString = "UPDATE Ejercicio " +
                                 "SET Nombre = @nombre, Descripcion = @descripcion, Dificultad = @dificultad, Basico = @basico, MaterialNecesario = @material, FechaModificacion = GETDATE() " +
                                 "WHERE Id = @id;";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(queryString, con))
            {
                cmd.Parameters.AddWithValue("@id", ejercicio.Id);
                cmd.Parameters.AddWithValue("@nombre", ejercicio.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", ejercicio.Descripcion);
                cmd.Parameters.AddWithValue("@dificultad", ejercicio.Dificultad);
                cmd.Parameters.AddWithValue("@basico", ejercicio.Basico);
                cmd.Parameters.AddWithValue("@material", ejercicio.MaterialNecesario);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public Task<List<Ejercicio>> GetAllEjerciciosAsync()
        {
            return Task.Run(() =>
            {
                string queryString = "SELECT * FROM Ejercicio";
                List<Ejercicio> list = new List<Ejercicio>();
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(queryString, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Ejercicio()
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Dificultad = reader.GetInt32(3),
                                Basico = reader.GetBoolean(4),
                                MaterialNecesario = reader.GetString(5),
                                FechaModificacion = reader.GetDateTime(6),
                            });
                        }
                    }
                    return list;
                }
                return new List<Ejercicio>();
            });
        }

        public Task<Ejercicio> GetEjercicioAsync(int id)
        {
            return Task.Run(() =>
            {
                string queryString = "SELECT * FROM Ejercicio WHERE Id = @id";
                Ejercicio ejercicio = new Ejercicio();
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(queryString, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ejercicio = new Ejercicio()
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Dificultad = reader.GetInt32(3),
                                Basico = reader.GetBoolean(4),
                                MaterialNecesario = reader.GetString(5),
                                FechaModificacion = reader.GetDateTime(6),
                            };
                        }
                    }
                    return ejercicio;
                }
                return new Ejercicio();
            });
        }

        public Task<List<Ejercicio>> GetEjerciciosFechaAsync(DateTime date)
        {
            return Task.Run(() =>
            {
                string queryString = "SELECT * FROM Ejercicio WHERE FechaModificacion = @date";
                List<Ejercicio> list = new List<Ejercicio>();
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(queryString, con))
                {
                    cmd.Parameters.AddWithValue("@date", date);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Ejercicio()
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Dificultad = reader.GetInt32(3),
                                Basico = reader.GetBoolean(4),
                                MaterialNecesario = reader.GetString(5),
                                FechaModificacion = reader.GetDateTime(6),
                            });
                        }
                    }
                    return list;
                }
                return new List<Ejercicio>();
            });
        }

        public bool ReloadFichero()
        {
            throw new NotImplementedException();
        }

        public bool UpdateFichero()
        {
            throw new NotImplementedException();
        }
    }
}
