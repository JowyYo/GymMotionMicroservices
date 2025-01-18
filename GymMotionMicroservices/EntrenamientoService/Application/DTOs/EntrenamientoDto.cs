namespace EntrenamientoService.Application.DTOs
{
    public class EntrenamientoDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<EjercicioDto> Ejercicios { get; set; }
    }
}
