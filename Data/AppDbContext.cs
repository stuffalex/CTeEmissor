using CTeEmissor.Dominio.Model;
using Microsoft.EntityFrameworkCore;

namespace CTeEmissor.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Viagem> Viagem { get; set; }
        public DbSet<Carga> Carga { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<CTeNota> Cte { get; set; }
        public DbSet<Aliquota> Aliquota { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=database.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
