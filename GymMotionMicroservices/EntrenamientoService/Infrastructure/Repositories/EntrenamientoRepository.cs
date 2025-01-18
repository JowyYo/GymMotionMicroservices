using EntrenamientoService.Application.Repositories;
using EntrenamientoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntrenamientoService.Infrastructure.Repositories
{
    public class EntrenamientoRepository : IEntrenamientoRepository
    {
        private readonly ApplicationDbContext _db;

        public EntrenamientoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Entrenamiento> CreateAsync(Entrenamiento ejercicio)
        {
            await _db.Entrenamientos.AddAsync(ejercicio);
            await _db.SaveChangesAsync();

            return ejercicio;
        }

        public async Task DeleteAsync(Entrenamiento ejercicio)
        {
            _db.Entrenamientos.Remove(ejercicio);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entrenamiento>> GetAllAsync()
        {
            return await _db.Entrenamientos.ToListAsync();
        }

        public async Task<Entrenamiento> GetByIdAsync(Guid id)
        {
            return await _db.Entrenamientos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Entrenamiento> UpdateAsync(Entrenamiento ejercicio)
        {
            _db.Entrenamientos.Update(ejercicio);
            await _db.SaveChangesAsync();

            return ejercicio;
        }
    }
}
