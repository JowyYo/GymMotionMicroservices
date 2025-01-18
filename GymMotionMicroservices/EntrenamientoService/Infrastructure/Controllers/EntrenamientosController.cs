using EntrenamientoService.Application.DTOs;
using EntrenamientoService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntrenamientoService.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrenamientosController : ControllerBase
    {
        private readonly IEntrenamientosService _service;

        public EntrenamientosController(IEntrenamientosService service) 
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
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] EntrenamientoDto ejercicioDto)
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
        public async Task<IActionResult> CreateAsync([FromBody] EntrenamientoDto ejercicioDto)
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
