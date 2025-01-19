namespace EntrenamientoService.Application.DTOs
{
    public class EjercicioDto
    {
        public Guid EjercicioId { get; set; }

        public int ObjetivoRepeticiones { get; set; }
        public double TiempoDescanso { get; set; }
        public int UnidadTiempo { get; set; }

        public IEnumerable<SerieDto> Series { get; set; }
    }
}
