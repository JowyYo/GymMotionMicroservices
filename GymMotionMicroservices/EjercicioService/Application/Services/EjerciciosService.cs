using AutoMapper;
using EjercicioService.Application.DTOs;
using EjercicioService.Application.Repositories;
using EjercicioService.Domain.Entities;

namespace EjercicioService.Application.Services
{
    public class EjerciciosService : IEjerciciosService
    {
        private readonly IEjercicioRepository _repository;
        private readonly IMapper _mapper;

        public EjerciciosService(IEjercicioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EjercicioDto> CreateAsync(EjercicioDto ejercicioDto)
        {
            Ejercicio ejercicio = _mapper.Map<Ejercicio>(ejercicioDto);

            return _mapper.Map<EjercicioDto>(await _repository.CreateAsync(ejercicio));
        }

        public async Task DeleteAsync(Guid id)
        {
            Ejercicio ejercicio = await _repository.GetByIdAsync(id);

            await _repository.DeleteAsync(ejercicio);
        }

        public async Task<IEnumerable<EjercicioDto>> GetAllAsync()
            => _mapper.Map<IEnumerable<EjercicioDto>>(await _repository.GetAllAsync());
        

        public async Task<EjercicioDto> GetByIdAsync(Guid id)
            => _mapper.Map<EjercicioDto>(await _repository.GetByIdAsync(id));

        public async Task<EjercicioDto> UpdateAsync(Guid id, EjercicioDto ejercicioDto)
        {
            Ejercicio ejercicioDb = await _repository.GetByIdAsync(id);
            ejercicioDb.Update(_mapper.Map<Ejercicio>(ejercicioDto));
            
            return _mapper.Map<EjercicioDto>(await _repository.UpdateAsync(ejercicioDb));
        }
    }
}
