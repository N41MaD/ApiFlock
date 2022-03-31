using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiFlock.Dtos
{
    public class ApiProvinciaResponseDto
    {
        [JsonProperty("cantidad")]
        public long Cantidad { get; set; }

        [JsonProperty("inicio")]
        public long Inicio { get; set; }

        [JsonProperty("parametros")]
        public ParametrosDto Parametros { get; set; }

        [JsonProperty("provincias")]
        public List<ProvinciaDto> Provincias { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }
}
