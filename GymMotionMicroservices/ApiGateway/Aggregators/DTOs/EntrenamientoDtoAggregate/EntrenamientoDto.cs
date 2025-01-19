namespace ApiGateway.Aggregators.DTOs.EntrenamientoDtoAggregate
{
    public class EntrenamientoDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<EntrenamientoEjercicioDto> Ejercicios { get; set; }

        public void setEjercicioInEntrenamientoEjercicio(List<EjercicioDto> ejercicios)
        {
            foreach (EntrenamientoEjercicioDto entrenamientoEjercicio in Ejercicios)
            {
                EjercicioDto ejercicio = ejercicios.FirstOrDefault(x => x.Id == entrenamientoEjercicio.EjercicioId);

                entrenamientoEjercicio.setEjercicio(ejercicio);
            }
        }
    }
}
