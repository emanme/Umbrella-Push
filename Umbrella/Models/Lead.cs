using System;
using Newtonsoft.Json;
using Umbrella.Converters;
using Umbrella.Helpers;

namespace Umbrella.Models
{
    public class Lead : ObservableBase
    {


        private string _EnquiryId;

        [JsonProperty("id")]
        public string EnquiryId { get { return this._EnquiryId; } set { this.SetProperty(ref this._EnquiryId, value); } }


        private string _ContactId;
        [JsonProperty("partner_id")]
        public string ContactId { get { return this._ContactId; } set { this.SetProperty(ref this._ContactId, value); } }

         
        public string Name { get { return this._FirstName + " " + this._LastName; }    }

        private string _FirstName;
        [JsonProperty("first_name")]
        public string FirstName { get { return this._FirstName; } set { this.SetProperty(ref this._FirstName, value); } }

        private string _LastName;
        [JsonProperty("last_name")]
        public string LastName { get { return this._LastName; } set { this.SetProperty(ref this._LastName, value); } }


        private string _Business;
        [JsonProperty("company")]
        public string Business { get { return this._Business; } set { this.SetProperty(ref this._Business, value); } }

        private string _Email;
        [JsonProperty("email_address")]
        public string Email { get { return this._Email; } set { this.SetProperty(ref this._Email, value); } }

        private string _Mobile;
        [JsonProperty("mobile_number")]
        public string Mobile { get { return this._Mobile; } set { this.SetProperty(ref this._Mobile, value); } }

        private string _Home;
        [JsonProperty("home_phone")]
        public string Home { get { return this._Home; } set { this.SetProperty(ref this._Home, value); } }

        private string _Office;
        [JsonProperty("office_phone")]
        public string Office { get { return this._Office; } set { this.SetProperty(ref this._Office, value); } }

        private string _ScheduledTime;
        [JsonProperty("callback_time")]
        public string ScheduledTime { get { return this._ScheduledTime; } set { this.SetProperty(ref this._ScheduledTime, value); } }

        private string _ContactEnquirye;
        [JsonProperty("contact_enquiry")]
        public string ContactEnquirye { get { return this._ContactEnquirye; } set { this.SetProperty(ref this._ContactEnquirye, value); } }


        private string _ScheduledDate;
        [JsonProperty("callback_date")]
        public string ScheduledDate { get { return this._ScheduledDate; } set { this.SetProperty(ref this._ScheduledDate, value); } }


        private string _Source;
        public string Source { get { return this._Source; } set { this.SetProperty(ref this._Source, value); } }

        private string _Category;
        public string Category { get { return this._Category; } set { this.SetProperty(ref this._Category, value); } }

        private string _Status;
        public string Status { get { return this._Status; } set { this.SetProperty(ref this._Status, value); } }

        private string _Enquiry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.";
        public string Enquiry { get { return this._Enquiry; } set { this.SetProperty(ref this._Enquiry, value); } }

        private DateTime _Created;
        public DateTime Created { get{ return this._Created; } set{ this.SetProperty(ref this._Created, value); } }
    }
}
