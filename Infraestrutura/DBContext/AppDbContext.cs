using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.DBContext
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<HistoricoAprovacao> HistoricoAprovacoes { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Configuracao> Configuracoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=NotasCompras;User Id=sa;Password=Test@12345;")
                .LogTo(message => System.Diagnostics.Debug.WriteLine(message)); // Adicione esta linha para logar consultas;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoricoAprovacao>()
                .HasOne(b => b.Nota)
                .WithMany(a => a.Aprovacoes)
                .HasForeignKey(b => b.NotaId);
        }
    }

}
