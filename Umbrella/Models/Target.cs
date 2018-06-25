using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.Models
{
    public class Target
    {
        [JsonProperty("target_id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string RewardName { get; set; }
        [JsonProperty("description")]
        public string TargetDescription { get; set; }
        [JsonProperty("new_recruits")]
        public string RecruitCount { get; set; }
        [JsonProperty("new_comrades")]
        public string ComradesCount { get; set; }
        [JsonProperty("target_date")]
        public DateTime TargetDate { get; set; }
        [JsonProperty("target")]
        public string TargetAmount { get; set; }
        public bool IsTargetAcquired { get; set; }
        public string TargetAmountString
        {
            get
            {
                return "£" + TargetAmount.ToString();
            }
        }
        public string IsAcquiredWithDate
        {
            get
            {
                return IsTargetAcquired.ToString() + " " + TargetDate.ToString("MMM yyyy");
            }
        }
    }
    public class Response
    {
        public string target_id { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string new_recruits { get; set; }
        public string new_comrades { get; set; }
        public string target { get; set; }
        public string target_date { get; set; }
        public string partner_id { get; set; }
    }
    public class ListTargets
    {
        public List<Target> response { get; set; }
    }
}
