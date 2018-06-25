using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Umbrella.Enums;

namespace Umbrella.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("displayname")]
        public string DisplayName { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("registered")]
        public DateTime Registered { get; set; }

        public AuthenticationStatus AuthenticationStatus { get; set; }
    }
}
