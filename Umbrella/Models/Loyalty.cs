using System;

using Newtonsoft.Json;

namespace Umbrella.Models
{
    public class Loyalty
    {
        [JsonProperty("partner_id")]
        public string PartnerId { get; set; }

        [JsonProperty("points")]
        public string Points { get; set; }

        [JsonProperty("package_level")]
        public string PackageLevel { get; set; }
       
        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("barcode_url")]
        public string BarcodeUrl { get; set; }
       
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        public string Fullname{
            get{
                return Firstname + " " + Lastname;
            }
        }
        
    }
}
