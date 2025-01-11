using AutoMapper;
using EjercicioService.Application.DTOs;
using EjercicioService.Application.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioService.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjerciciosController : ControllerBase
    {
        private readonly IEjercicioRepository _repository;
        private readonly IMapper _mapper;

        public EjerciciosController(IEjercicioRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_mapper.Map<IEnumerable<EjercicioDto>>(_repository.GetAll()));
        }
    }
}
