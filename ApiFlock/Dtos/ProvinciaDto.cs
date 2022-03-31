using Newtonsoft.Json;

namespace ApiFlock.Dtos
{
    public class ProvinciaDto
    {
        [JsonProperty("centroide")]
        public CentroideDto Centroide { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }
    }
}
