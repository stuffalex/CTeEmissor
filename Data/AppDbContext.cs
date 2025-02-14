using Microsoft.EntityFrameworkCore;
using CTeEmissor.Dominio.Models;

namespace CTeEmissor.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Viagem> Viagem { get; set; }
        public DbSet<Carga> Carga { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<CTeNota> Cte { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=database.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
