using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Umbrella.Models
{
    public class Recruit
    {
        public string Name { get; set; }
        public string Business { get; set; }
        public string Morale { get; set; }
        public DateTime DateRecruited { get; set; }
        public string Description { get; set; }
    }
    public class RecruitData
    {
        [JsonProperty("re_id")]
        public string Re_Id { get; set; }
        [JsonProperty("owner_partner_id")]
        public string OwnerId { get; set; }
        [JsonProperty("business_name")]
        public string Business { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("re_date")]
        public DateTime DateRecruited { get; set; }
        [JsonProperty("background")]
        public string Description { get; set; }
        [JsonProperty("first_name")]
        public string Firstname { get; set; }
        [JsonProperty("last_name")]
        public string Lastname { get; set; }
        public string Morale {
            get{
                return "10";
            }
        }
        public string Fullname {
            get{
                return Firstname + " " + Lastname;
            }
        }
    }

    public class ListRecruitData
    {
        public List<RecruitData> response { get; set; }
    }
}
