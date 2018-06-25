using System;
using Newtonsoft.Json;
using Umbrella.Helpers;
using Umbrella.Converters;

namespace Umbrella.Models
{
    public class CallBack : ObservableBase
    {
        public Lead Lead { get; set; }

        public string ContactType { get; set; }

        public DateTime ScheduledDateTime { get; set; }

        private string _EnquiryId;

        [JsonProperty("id")]
        public string EnquiryId { get { return this._EnquiryId; } set { this.SetProperty(ref this._EnquiryId, value); } }


        private string _ContactId;
        [JsonProperty("partner_id")]
        public string ContactId { get { return this._ContactId; } set { this.SetProperty(ref this._ContactId, value); } }

        private string _Name;
        [JsonProperty("last_name")]
        public string Name { get { return this._Name; } set { this.SetProperty(ref this._Name, value); } }

        private string _Business;
        [JsonProperty("company")]
        public string Business { get { return this._Business; } set { this.SetProperty(ref this._Business, value); } }

        private string _Email;
        [JsonProperty("email_address")]
        public string Email { get { return this._Email; } set { this.SetProperty(ref this._Email, value); } }

    }
}
