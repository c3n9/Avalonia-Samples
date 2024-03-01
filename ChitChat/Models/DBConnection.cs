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
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Chatroom> Chatroom { get; set; }
        public DbSet<ChatroomEmployee> ChatroomEmployee { get; set; }
        public DbSet<ChatMessage> ChatMessage { get; set; }
        public DbSet<Department> Department { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Username=postgres;Password=1;Database=ChitChat");
        }
        
    }
}
