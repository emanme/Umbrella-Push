using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.Models
{
    public class Medal
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("introducer_id")]
        public string IntroducerId { get; set; }
        [JsonProperty("medal_name")]
        public string MedalName { get; set; }
        [JsonProperty("partner_id")]
        public string PartnerId { get; set; }
        [JsonProperty("action")]
        public string Status { get; set; }
        public string Description
        {
            get
            {
                switch (MedalName)
                {
                    case "Victory Medal":
                        return "An honor issued once you have secured at least one active recruit or commrade in every country in England.There are 45 countries in England";
                    case "Comms Expert Medal":
                        return "Command recognises and rewards those who are communications experts, those who show that they have been able to clearly explain to recruits the benefits of working with Umbrella and those interested in enlisting in the Umbrella Army with the Comms Expert medal. ";
                    case "Comms Expert Meda":
                        return "Command recognises and rewards those who are communications experts, those who show that they have been able to clearly explain to recruits the benefits of working with Umbrella and those interested in enlisting in the Umbrella Army with the Comms Expert medal. ";
                    case "Conqueror Medal":
                        return "Simply gain territory in either recruits of businesses or by growing the Umbrella Army at a rate of at least 10% per month for 12 consecutive months and Command will honour you with the Conqueror medal.";
                    case "Bravery Medal":
                        return "Command wants to recognize and reward this additional effort and with the Bravery Award and so as soon as 10 businesses with £1m + in annual sales come on board the distinction is yours.";
                    case "Defender Medal":
                        return "Umbrella does not claim to be perfect and the more territory we or members of the Army occupy the more likely it is that we will make mistakes. We need your help to help us identify these errors and help get us back on track as quickly as possible.";
                    case "Intelligence Medal":
                        return "The Intelligence Award is issued at the discretion of Umbrella and is given to Army who has given us the most valuable intelligence. It could have just been one incredible idea or perhaps it ongoing intelligence over months or years that, the award is reserved for those who have made the biggest positive impact on Umbrella, recruits & the Army.";
                    default:
                        return "";
                }
            }
        }
        public string ImageMedalBig
        {
            get
            {
                switch (MedalName)
                {
                    case "Victory Medal":
                        return "medal_victory_big";
                    case "Comms Expert Medal":
                        return "medal_expert_big";
                    case "Conqueror Medal":
                        return "medal_conqueror_big";
                    case "Bravery Medal":
                        return "medal_bravery_big";
                    case "Defender Medal":
                        return "medal_defender_big";
                    case "Intelligence Medal":
                        return "medal_intel_big";
                    default:
                        return "medal_grayed";
                }
            }
        }
        public string ImageMedal
        {
            get
            {
                switch (MedalName)
                {
                    case "Victory Medal":
                        return "medal_victory";
                    case "Comms Expert Medal":
                        return "medal_expert";
                    case "Conqueror Medal":
                        return "medal_conqueror";
                    case "Bravery Medal":
                        return "medal_bravery";
                    case "Defender Medal":
                        return "medal_defender";
                    case "Intelligence Medal":
                        return "medal_intel";
                    default:
                        return "medal_grayed";
                }
            }
        }
        public string MedalNameWithAction
        {
            get
            {
                return MedalName + " " + Status;
            }
        }
    }
    public class ListMedal
    {
        public List<Medal> response { get; set; }
    }
}
