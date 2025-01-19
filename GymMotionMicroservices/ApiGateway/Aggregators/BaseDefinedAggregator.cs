using System.Net;
using ApiGateway.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ocelot.Middleware;
using Ocelot.Multiplexer;

namespace ApiGateway.Aggregators
{
    public abstract class BaseDefinedAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            foreach (HttpContext response in responses) 
            {
                HttpStatusCode httpStatus = response.Items.DownstreamResponse().StatusCode;
                if (httpStatus != HttpStatusCode.OK && httpStatus != HttpStatusCode.NoContent) 
                { 
                    string contentRespoonse = await response.Items.DownstreamResponse().Content.ReadAsStringAsync();
                    return GetDownstreamResponseFromResponsesAndReturnObject(responses, contentRespoonse, httpStatus, "ERROR");
                }
            }

            return await ExecuteAggregate(responses);
        }

        public abstract Task<DownstreamResponse> ExecuteAggregate(List<HttpContext> responses);

        public DownstreamResponse GetDownstreamResponseFromResponsesAndReturnObject(List<HttpContext> responses, object returnObject, HttpStatusCode statusCode = HttpStatusCode.OK, string reasonPhase = "OK") 
        { 
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(returnObject, settings));
            stringContent = stringContent.AddMediaTypeJsonHeader();
            List<Header> headers = responses.SelectMany(x => x.Items.DownstreamResponse().Headers).ToList();

            return new DownstreamResponse(stringContent, statusCode, headers, reasonPhase);
        }
    }
}
