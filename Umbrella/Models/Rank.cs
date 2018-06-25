using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.Models
{
    public class Rank
    {
        public string Id { get; set; }
        [JsonProperty("partner_id")]
        public int PartnerId { get; set; }

        [JsonProperty("rank_title")]
        public string Title { get; set; }

        [JsonProperty("rank")]
        public int Number { get; set; }
    }
}
