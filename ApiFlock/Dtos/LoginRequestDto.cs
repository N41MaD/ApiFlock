using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiFlock.Dtos
{
    public class LoginRequestDto
    {
        [EmailAddress]
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        [Required]
        public string Password { get; set; }
    }
}
