using Agencia_viajes_dse.Models;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajes_dse.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destino_AR>().HasKey(am => new
            {
                am.Id_AR,
                am.Id_Destino
            });

            modelBuilder.Entity<Destino_AR>().HasOne(m => m.Destino).WithMany(am => am.Destinos_ARs).HasForeignKey(m => m.Id_Destino);
            modelBuilder.Entity<Destino_AR>().HasOne(m => m.AR).WithMany(am => am.Destinos_ARs).HasForeignKey(m => m.Id_AR);

            modelBuilder.Entity<Destino_Gastos>().HasKey(am => new
            {
                am.Id_Gastos,
                am.Id_Destino
            });

            modelBuilder.Entity<Destino_Gastos>().HasOne(m => m.Destino).WithMany(am => am.Destinos_Gastos).HasForeignKey(m => m.Id_Destino);
            modelBuilder.Entity<Destino_Gastos>().HasOne(m => m.Gastos_Extra).WithMany(am => am.Destinos_Gastos).HasForeignKey(m => m.Id_Gastos);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AR> ARS { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Destino_AR> Destino_ARs { get; set; }
        public DbSet<Destino_Gastos> Destinos_Gastos { get; set; }
        public DbSet<Gastos_Extra> Gastos_Extras { get; set; }
        public DbSet<Reservacion> Reservaciones { get; set; }
    }
}
