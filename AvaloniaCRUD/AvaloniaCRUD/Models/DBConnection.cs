using Microsoft.EntityFrameworkCore;

namespace AvaloniaCRUD.Models;

public class DBConnection : DbContext
{
    public DbSet<Role> Role { get; set; }
    public DbSet<User> User { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=127.0.0.1;Username=postgres;Password=1;Database=CRUD");
    }
}