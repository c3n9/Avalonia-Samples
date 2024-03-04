using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChat.Models
{
    public class DBConnection : DbContext
    {
        public virtual DbSet<ChatMessage> ChatMessage { get; set; }

        public virtual DbSet<Chatroom> Chatroom { get; set; }

        public virtual DbSet<Department> Department { get; set; }

        public virtual DbSet<Employee> Employee { get; set; }

        //public virtual DbSet<EmployeeChatroom> EmployeeChatroom { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Username=postgres;Password=1;Database=ChitChat");
        }
        
    }
}
