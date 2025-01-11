using EjercicioService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EjercicioService.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Ejercicio> Ejercicios { get; set; }
    }
}
