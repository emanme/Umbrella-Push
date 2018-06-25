using Newtonsoft.Json;
using Umbrella.Enums;

namespace Umbrella.Models
{
    public class AuthenticationCookie
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("cookie")]
        public string Cookie { get; set; }

        [JsonProperty("cookie_name")]
        public string CookieName { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
