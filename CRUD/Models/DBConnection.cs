using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models
{
    internal class DBConnection : DbContext
    {
        public virtual DbSet<Role> Role { get; set; }

        public virtual DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Username=postgres;Password=1;Database=CRUD");
        }
        
    }
}
