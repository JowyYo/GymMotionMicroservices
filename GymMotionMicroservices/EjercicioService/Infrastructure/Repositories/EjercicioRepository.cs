using EjercicioService.Application.Repositories;
using EjercicioService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EjercicioService.Infrastructure.Repositories
{
    public class EjercicioRepository : IEjercicioRepository
    {
        private readonly ApplicationDbContext _db;

        public EjercicioRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Ejercicio> CreateAsync(Ejercicio ejercicio)
        {
            await _db.Ejercicios.AddAsync(ejercicio);
            await _db.SaveChangesAsync();

            return ejercicio;
        }

        public async Task DeleteAsync(Ejercicio ejercicio)
        {
            _db.Ejercicios.Remove(ejercicio);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ejercicio>> GetAllAsync()
        {
            return await _db.Ejercicios.ToListAsync();
        }

        public async Task<Ejercicio> GetByIdAsync(Guid id)
        {
            return await _db.Ejercicios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ejercicio> UpdateAsync(Ejercicio ejercicio)
        {
            _db.Ejercicios.Update(ejercicio);
            await _db.SaveChangesAsync();

            return ejercicio;
        }
    }
}
