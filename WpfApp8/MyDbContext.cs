using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp8
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MyDbContext() : base("Server=DESKTOP-FCKMF1K\\SQLEXPRESS;Database=Testdb_db;Trusted_Connection=True;")
        {

        }
    }
}
