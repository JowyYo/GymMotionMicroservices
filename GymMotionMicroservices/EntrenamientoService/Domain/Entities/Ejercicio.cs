namespace EntrenamientoService.Domain.Entities
{
    public class Ejercicio : BaseEntity
    {
        public Guid EjercicioId { get; set; }

        public int ObjetivoRepeticiones { get; set; }
        public double TiempoDescanso { get; set; }
        public UnidadTiempo UnidadTiempo { get; set; }

        public Guid EntrenamientoId { get; set; }
        public virtual Entrenamiento Entrenamiento { get; set; }

        public IEnumerable<Serie> Series { get; set; }
    }

    public enum UnidadTiempo
    {
        Minutos,
        Segundos
    }
}
