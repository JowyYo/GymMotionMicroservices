using EntrenamientoService.Domain.Entities;

namespace EntrenamientoService.Application.Repositories
{
    public interface IEntrenamientoRepository
    {
        Task<IEnumerable<Entrenamiento>> GetAllAsync();
        Task<Entrenamiento> GetByIdAsync(Guid id);
        Task<Entrenamiento> CreateAsync(Entrenamiento ejercicio);
        Task<Entrenamiento> UpdateAsync(Entrenamiento ejercicio);
        Task DeleteAsync(Entrenamiento ejercicio);
    }
}
