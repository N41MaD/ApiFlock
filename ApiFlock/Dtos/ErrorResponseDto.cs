using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ApiFlock.Dtos
{
    public class ErrorResponse
    {
        [Newtonsoft.Json.JsonConstructor]
        public ErrorResponse(int errorCode, string errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }

        [JsonProperty("error_code")]
        [JsonPropertyName("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("error_description")]
        [JsonPropertyName("error_description")]
        public string ErrorDescription { get; set; }

    }
}
