using System.Collections.Generic;
using Newtonsoft.Json;

namespace Umbrella.Models
{
    public class RewardLevel
    {
        [JsonProperty("reward_level")]
        public int Level { get; set; }

        public string ImageUri { get; set; }

        public List<string> Rewards { get; set; }

        public List<string> Requirements { get; set; }

        public bool IsCurrent { get; set; }
    }
}
