using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    public class MyDbContext : DbContext
    {
        public DbSet<Ejercicio> Ejercicios { get; set; }

        public MyDbContext() : base("Musqui")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
