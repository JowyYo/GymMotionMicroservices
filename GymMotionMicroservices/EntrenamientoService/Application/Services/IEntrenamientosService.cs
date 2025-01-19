using EntrenamientoService.Application.DTOs;

namespace EntrenamientoService.Application.Services
{
    public interface IEntrenamientosService
    {
        Task<IEnumerable<EntrenamientoDto>> GetAllAsync();
        Task<EntrenamientoDto> GetByIdAsync(Guid id);
        Task<EntrenamientoDto> CreateAsync(EntrenamientoDto ejercicioDto);
        Task<EntrenamientoDto> UpdateAsync(Guid id, EntrenamientoDto ejercicioDto);
        Task DeleteAsync(Guid id);
    }
}
