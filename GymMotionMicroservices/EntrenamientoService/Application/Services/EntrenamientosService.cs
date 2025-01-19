using AutoMapper;
using EntrenamientoService.Application.DTOs;
using EntrenamientoService.Application.Repositories;
using EntrenamientoService.Domain.Entities;

namespace EntrenamientoService.Application.Services
{
    public class EntrenamientosService : IEntrenamientosService
    {
        private readonly IEntrenamientoRepository _repository;
        private readonly IMapper _mapper;

        public EntrenamientosService(IEntrenamientoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EntrenamientoDto> CreateAsync(EntrenamientoDto ejercicioDto)
        {
            Entrenamiento ejercicio = _mapper.Map<Entrenamiento>(ejercicioDto);

            return _mapper.Map<EntrenamientoDto>(await _repository.CreateAsync(ejercicio));
        }

        public async Task DeleteAsync(Guid id)
        {
            Entrenamiento ejercicio = await _repository.GetByIdAsync(id);

            await _repository.DeleteAsync(ejercicio);
        }

        public async Task<IEnumerable<EntrenamientoDto>> GetAllAsync()
            => _mapper.Map<IEnumerable<EntrenamientoDto>>(await _repository.GetAllAsync());
        

        public async Task<EntrenamientoDto> GetByIdAsync(Guid id)
            => _mapper.Map<EntrenamientoDto>(await _repository.GetByIdAsync(id));

        public async Task<EntrenamientoDto> UpdateAsync(Guid id, EntrenamientoDto ejercicioDto)
        {
            Entrenamiento ejercicioDb = await _repository.GetByIdAsync(id);
            ejercicioDb.Update(_mapper.Map<Entrenamiento>(ejercicioDto));
            
            return _mapper.Map<EntrenamientoDto>(await _repository.UpdateAsync(ejercicioDb));
        }
    }
}
