using Newtonsoft.Json;

namespace ApiFlock.Dtos
{
    public class ParametrosDto
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
    }
}
