using EjercicioService.Application.DTOs;

namespace EjercicioService.Application.Services
{
    public interface IEjerciciosService
    {
        Task<IEnumerable<EjercicioDto>> GetAllAsync();
        Task<EjercicioDto> GetByIdAsync(Guid id);
        Task<EjercicioDto> CreateAsync(EjercicioDto ejercicioDto);
        Task<EjercicioDto> UpdateAsync(Guid id, EjercicioDto ejercicioDto);
        Task DeleteAsync(Guid id);
    }
}
