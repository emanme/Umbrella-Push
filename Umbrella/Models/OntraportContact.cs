using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.Models
{
    public class OntraportContact
    {
        [JsonProperty("firstname")]
        public string Firstname { get; set; }
        [JsonProperty("lastname")]
        public string Lastname { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("office_phone")]
        public string OfficePhone { get; set; }
        [JsonProperty("cell_phone")]
        public string CellPhone { get; set; }
        [JsonProperty("f1561")]
        public string Message { get; set; }
        [JsonProperty("n_lead_source")]
        public int PhoneUsed {  get; set; }
        [JsonProperty("freferrer")]
        public string AccountUsed { get; set; }
        [JsonProperty("f1652")]
        public int Relationship { get; set; }
    }
    public class OntraportContactArmy
    {
        [JsonProperty("firstname")]
        public string Firstname { get; set; }
        [JsonProperty("lastname")]
        public string Lastname { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("office_phone")]
        public string OfficePhone { get; set; }
        [JsonProperty("cell_phone")]
        public string CellPhone { get; set; }
        [JsonProperty("f1561")]
        public string Message { get; set; }
        [JsonProperty("n_lead_source")]
        public int PhoneUsed { get; set; }
        [JsonProperty("freferrer")]
        public string AccountUsed { get; set; }
        [JsonProperty("f1652")]
        public int Relationship { get; set; }
        [JsonProperty("f1669")]
        public int LeadInfo { get; set; }
        [JsonProperty("referral_page")]
        public string ReferralPage { get; set; }
    }

    public class OntraportJsonModel
    {
        public string id { get; set; }
    }
    public class RootListJsonModel
    {
        public List<OntraportJsonModel> data { get; set; }
    }
    public class OntraportEnquiryContact
    {
        [JsonProperty("f1561")]
        public string Message { get; set; }
        [JsonProperty("f1653")]
        public int EnquiryType { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
