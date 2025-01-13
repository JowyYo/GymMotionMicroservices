namespace EjercicioService.Application.DTOs
{
    public class EjercicioDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Group {  get; set; }
    }
}
