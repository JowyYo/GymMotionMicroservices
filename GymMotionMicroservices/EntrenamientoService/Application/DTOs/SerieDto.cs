namespace EntrenamientoService.Application.DTOs
{
    public class SerieDto
    {
        public int Repeticiones { get; set; }
        public double Peso {  get; set; }

        public Guid EjercicioId { get; set; }
        public virtual EjercicioDto Ejercicio { get; set; }
    }
}
