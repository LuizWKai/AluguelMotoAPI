using Microsoft.EntityFrameworkCore;
using AluguelMotos.Models;


namespace AluguelMotos.DataBase
{
    public class ConnectionContext : DbContext
    {

        public DbSet<EntregadoresUser> EntregadoresUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost,Port=5432;Database=DataBaseALuguelMotos;User Id=postgres;Password=123456;TrustServerCertificate=True;");

        public DbSet<Motos> Motos { get; set; }

    }
    
}