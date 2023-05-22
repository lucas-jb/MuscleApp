using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Data
{
    public class DataAccessDapper : IDataAccess
    {
        private readonly string connectionString = "Data Source=POTAS\\SQLEXPRESS;Initial Catalog=Ejercicios;Integrated Security=True";

        public Task<Ejercicio> GetEjercicioAsync(int id)
        {
            return Task.Run(() =>
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Ejercicio WHERE Id = @Id";
                    return connection.QuerySingleOrDefault<Ejercicio>(query, new { Id = id });
                }
            });
        }

        public Task<List<Ejercicio>> GetEjerciciosFechaAsync(DateTime date)
        {
            return Task.Run(() =>
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Ejercicio WHERE FechaModificacion = @FechaModificacion";
                    return connection.Query<Ejercicio>(query, new { FechaModificacion = date }).AsList();
                }
            });
        }

        public Task<List<Ejercicio>> GetAllEjerciciosAsync()
        {
            return Task.Run(() =>
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Ejercicio";
                    return connection.Query<Ejercicio>(query).AsList();
                }
            });
        }

        public bool CreateEjercicio(Ejercicio ejercicio)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Ejercicio (Nombre, Descripcion, Dificultad, Basico, MaterialNecesario, MusculosInvolucrados, FechaModificacion) VALUES (@Nombre, @Descripcion, @Dificultad, @Basico, @MaterialNecesario, @MusculosInvolucrados, @FechaModificacion)";
                connection.Execute(query, ejercicio);
                return true;
            }
        }

        public bool DeleteEjercicio(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Ejercicio WHERE Id = @Id";
                connection.Execute(query, new { Id = id });
                return true;
            }
        }

        public bool EditEjercicio(Ejercicio ejercicio)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Ejercicio SET Nombre = @Nombre, Descripcion = @Descripcion, Dificultad = @Dificultad, Basico = @Basico, MaterialNecesario = @MaterialNecesario, MusculosInvolucrados = @MusculosInvolucrados, FechaModificacion = @FechaModificacion WHERE Id = @Id";
                connection.Execute(query, ejercicio);
                return true;
            }
        }

        public bool UpdateFichero()
        {
            throw new NotImplementedException();
        }

        public bool ReloadFichero()
        {
            throw new NotImplementedException();
        }
    }
}
