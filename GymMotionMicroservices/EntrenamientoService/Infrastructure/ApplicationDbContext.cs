using EntrenamientoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntrenamientoService.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         
            modelBuilder.Entity<Ejercicio>()
                .HasOne(b => b.Entrenamiento)
                .WithMany(a => a.Ejercicios)
                .HasForeignKey(b => b.EntrenamientoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Serie>()
                .HasOne(b => b.Ejercicio)
                .WithMany(a => a.Series)
                .HasForeignKey(b => b.EjercicioId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Entrenamiento> Entrenamientos { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<Serie> Series { get; set; }
    }
}
