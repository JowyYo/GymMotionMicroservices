using EjercicioService.Domain.Entities;

namespace EjercicioService.Application.Repositories
{
    public interface IEjercicioRepository
    {
        Task<IEnumerable<Ejercicio>> GetAllAsync();
        Task<Ejercicio> GetByIdAsync(Guid id);
        Task<Ejercicio> CreateAsync(Ejercicio ejercicio);
        Task<Ejercicio> UpdateAsync(Ejercicio ejercicio);
        Task DeleteAsync(Ejercicio ejercicio);
    }
}
