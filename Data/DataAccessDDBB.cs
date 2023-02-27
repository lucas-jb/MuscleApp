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

        public void Connecction(string queryString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(queryString, con))
            {
                cmd.Parameters.AddWithValue("@id", "asdf");
                //cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = "asdf";
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    string gola = "";
                    while (reader.Read())
                    {
                        gola += reader.GetString(0) + " // " + reader.GetString(1) + " // " + reader.GetDecimal(2).ToString() + "\r\n";
                    }
                }
            }
        }

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
                Connecction("SELECT * FROM Ejercicio");
                return new List<Ejercicio>();
            });
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
            throw new NotImplementedException();
        }

        public bool UpdateFichero()
        {
            throw new NotImplementedException();
        }
    }
}
