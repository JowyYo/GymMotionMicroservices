using EjercicioService.Application.DTOs;
using EjercicioService.Application.Services;
using EjercicioService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioService.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjerciciosController : ControllerBase
    {
        private readonly IEjerciciosService _service;

        public EjerciciosController(IEjerciciosService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() 
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] EjercicioDto ejercicioDto)
        {
            try
            {
                return Ok(await _service.UpdateAsync(id, ejercicioDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EjercicioDto ejercicioDto)
        {
            try
            {
                return Ok(await _service.CreateAsync(ejercicioDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
