using System;
using Newtonsoft.Json;

namespace Umbrella.Models
{
    public class MapLocation
    {
        [JsonProperty("map_id")]
        public string Id { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("long")]
        public string Longitude { get; set; }
        [JsonProperty("lat")]
        public string Latitude { get; set; }
        [JsonProperty("full_name")]
        public string Fullname { get; set; }
        [JsonProperty("partner_id")]
        public string PartnerId { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
