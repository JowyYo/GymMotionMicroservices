namespace EjercicioService.Domain.Entities
{
    public class Ejercicio
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public GrupoMuscular Group { get; set; }

        public Ejercicio() { }

        public void Update(Ejercicio ejercicio)
        {
            if (string.IsNullOrEmpty(ejercicio.Name))
                throw new ArgumentNullException("El nombre del ejercicio tiene que venir informado");

            Name = ejercicio.Name;
            Description = ejercicio.Description;
            Group = ejercicio.Group;
        }
    }

    public enum GrupoMuscular
    {
        Espalda,
        Pectoral,
        Hombro,
        Bíceps,
        Tríceps,
        Antebrazo,
        Cuadriceps,
        Femoral,
        Gluteo,
        Gemelo,
        Abdominales
    }
}
