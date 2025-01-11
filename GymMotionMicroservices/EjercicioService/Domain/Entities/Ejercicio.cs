namespace EjercicioService.Domain.Entities
{
    public class Ejercicio
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public GrupoMuscular Group { get; set; }
    }

    public enum GrupoMuscular
    {
        Pectoral,
        Espalda
    }
}
