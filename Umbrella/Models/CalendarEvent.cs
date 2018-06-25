using System;
using Newtonsoft.Json;

namespace Umbrella.Models
{
    public class CalendarEvent
    {
        [JsonProperty("summary")]
        public string Subject { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        public string Message { get; set; }
        [JsonProperty("start_date")]
        public DateTime StartEventDateTime { get; set; }
        [JsonProperty("end_date")]
        public DateTime EndEventDateTime { get; set; }
        public string StringLocation{
            get{
                if(string.IsNullOrEmpty(Location)){
                    return "No Location";
                }
                return "Location: " + Location;
            }
        }
    }
}
