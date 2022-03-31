using Newtonsoft.Json;

namespace ApiFlock.Dtos
{
    public class CentroideDto
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }
}
