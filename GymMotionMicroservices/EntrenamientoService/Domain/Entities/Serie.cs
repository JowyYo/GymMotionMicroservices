namespace EntrenamientoService.Domain.Entities
{
    public class Serie : BaseEntity
    {
        public int Repeticiones { get; set; }
        public double Peso {  get; set; }

        public Guid EjercicioId { get; set; }
        public virtual Ejercicio Ejercicio { get; set; }
    }
}
