using ApiGateway.Aggregators.DTOs;
using ApiGateway.Aggregators.DTOs.EntrenamientoDtoAggregate;
using Newtonsoft.Json;
using Ocelot.Configuration;
using Ocelot.Middleware;

namespace ApiGateway.Aggregators
{
    public class GetEntrenamientoByIdAggregator : BaseDefinedAggregator
    {
        public override async Task<DownstreamResponse> ExecuteAggregate(List<HttpContext> responses)
        {
            EntrenamientoDto entrenamiento = new EntrenamientoDto();
            List<EjercicioDto> ejercicios = new List<EjercicioDto>();

            foreach (HttpContext response in responses) 
            {
                string downStreamRouteKey = ((DownstreamRoute)response.Items["DownstreamRoute"]).Key;
                string contentResponse = await response.Items.DownstreamResponse().Content.ReadAsStringAsync();
                if (downStreamRouteKey == "GetEntrenamientoById")
                    entrenamiento = JsonConvert.DeserializeObject<EntrenamientoDto>(contentResponse);
                if (downStreamRouteKey == "GetAllEjercicios")
                    ejercicios = JsonConvert.DeserializeObject<List<EjercicioDto>>(contentResponse);
            }

            entrenamiento.setEjercicioInEntrenamientoEjercicio(ejercicios);

            return GetDownstreamResponseFromResponsesAndReturnObject(responses, entrenamiento);
        }
    }
}
