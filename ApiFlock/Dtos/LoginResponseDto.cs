using Newtonsoft.Json;

namespace ApiFlock.Dtos
{
    public class LoginResponseDto
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "expirate_date")]
        public string ExpirateDate { get; set; }
    }
}
