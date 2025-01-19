namespace EntrenamientoService.Domain.Entities
{
    public class Entrenamiento : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Ejercicio> Ejercicios { get; set; }
        
        public Entrenamiento() { }

        public void Update(Entrenamiento ejercicio)
        {
            ejercicio.Validate();

            Name = ejercicio.Name;
            Description = ejercicio.Description;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentNullException("El nombre del ejercicio tiene que venir informado");
        }
    }
}
