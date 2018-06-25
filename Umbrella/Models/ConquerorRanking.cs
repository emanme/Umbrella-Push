using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Umbrella.Models
{
    public class ConquerorRanking
    {
        public string Name { get; set; }
        public string RankNumber { get; set; }
        public DateTime DateRanked { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string NumberOfAchievements { get; set; }
        public string Amount { get; set; }
        public string ImageString {

            get{
                switch(RankNumber){
                    case "1":
                        return "war1";
                    case "2":
                        return "war2";
                    case "3":
                        return "war3";
                    case "4":
                        return "war4";
                    case "5":
                        return "war5";
                    default:
                        return "war1";
                }
            }
        }
    }
    public class TopRecruits
    {
        [JsonProperty("first_name")]
        public string Firstname { get; set; }
        [JsonProperty("last_name")]
        public string Lastname { get; set; }
        [JsonProperty("rank")]
        public string RankNumber { get; set; }
        [JsonProperty("rank_title")]
        public string RankTitle { get; set; }
        public DateTime DateRanked { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("recruit")]
        public string NumberOfAchievements { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        public string NameWithTitle {
            get{
                return RankTitle + " " + Firstname;
            }
        }
        public int Index { get; set; }

        public string ImageString
        {

            get
            {
                switch (RankNumber)
                {
                    case "1":
                        return "war1";
                    case "2":
                        return "war2";
                    case "3":
                        return "war3";
                    case "4":
                        return "war4";
                    case "5":
                        return "war5";
                    default:
                        return "war1";
                }
            }
        }
    }
    public class TopComrades
    {
        [JsonProperty("first_name")]
        public string Firstname { get; set; }
        [JsonProperty("last_name")]
        public string Lastname { get; set; }
        [JsonProperty("rank")]
        public string RankNumber { get; set; }
        [JsonProperty("rank_title")]
        public string RankTitle { get; set; }
        public DateTime DateRanked { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("comrade")]
        public string NumberOfAchievements { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        public string NameWithTitle
        {
            get
            {
                return RankTitle + " " + Firstname;
            }
        }
        public int Index { get; set; }
        public string ImageString
        {

            get
            {
                switch (RankNumber)
                {
                    case "1":
                        return "war1";
                    case "2":
                        return "war2";
                    case "3":
                        return "war3";
                    case "4":
                        return "war4";
                    case "5":
                        return "war5";
                    default:
                        return "war1";
                }
            }
        }
    }
    public class TopResources
    {
        [JsonProperty("first_name")]
        public string Firstname { get; set; }
        [JsonProperty("last_name")]
        public string Lastname { get; set; }
        [JsonProperty("rank")]
        public string RankNumber { get; set; }
        [JsonProperty("rank_title")]
        public string RankTitle { get; set; }
        public DateTime DateRanked { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("resource")]
        public string NumberOfAchievements { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        public int Index { get; set; }
        public string NameWithTitle
        {
            get
            {
                return RankTitle + " " + Firstname;
            }
        }
        public string ImageString
        {

            get
            {
                switch (RankNumber)
                {
                    case "1":
                        return "war1";
                    case "2":
                        return "war2";
                    case "3":
                        return "war3";
                    case "4":
                        return "war4";
                    case "5":
                        return "war5";
                    default:
                        return "war1";
                }
            }
        }
    }
}
