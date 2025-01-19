namespace ApiGateway.Aggregators.DTOs.EntrenamientoDtoAggregate
{
    public class EntrenamientoEjercicioDto
    {
        public Guid EjercicioId { get; set; }
        public EjercicioDto Ejercicio { get; set; }

        public int ObjetivoRepeticiones { get; set; }
        public double TiempoDescanso { get; set; }
        public int UnidadTiempo { get; set; }

        public IEnumerable<SerieDto> Series { get; set; }

        public void setEjercicio(EjercicioDto ejercicio)
        {
            Ejercicio = ejercicio;
        }
    }
}
