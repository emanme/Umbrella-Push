using System.Collections.Generic;
using Newtonsoft.Json;

namespace Umbrella.Models
{
    public class Appointment
    {
        public int user_id { get; set; }
        public string partner_id { get; set; }
        public string open_from { get; set; }
        public string open_to { get; set; }
        public string call_back_length { get; set; }
        public string call_back_delay { get; set; }
        public string morning { get; set; }
        public string afternoon { get; set; }
        public string evening { get; set; }
        public string close { get; set; }
        public string book_time_type { get; set; }
        public string day { get; set; }
        public string date { get; set; }
        public string updated_at { get; set; }
        public string created_at { get; set; }
        public string type { get; set; }
        public string action { get; set; }
        public string passkey { get; set; }
    }

    public class AppointmentStoreUpdate
    {
        [JsonProperty("monday_open_from")]
        public string Mon_From { get; set; }
        [JsonProperty("monday_open_to")]
        public string Mon_Till { get; set; }
        [JsonProperty("monday_close")]
        public string LabelClose1 { get; set; }
        [JsonProperty("tuesday_open_from")]
        public string Tue_From { get; set; }
        [JsonProperty("tuesday_open_to")]
        public string Tue_Till { get; set; }
        [JsonProperty("tuesday_close")]
        public string LabelClose2 { get; set; }
        [JsonProperty("wednesday_open_from")]
        public string Wen_From { get; set; }
        [JsonProperty("wednesday_open_to")]
        public string Wen_Till { get; set; }
        [JsonProperty("wednesday_close")]
        public string LabelClose3 { get; set; }
        [JsonProperty("thursday_open_from")]
        public string Thur_From { get; set; }
        [JsonProperty("thursday_open_to")]
        public string Thur_Till { get; set; }
        [JsonProperty("thursday_close")]
        public string LabelClose4 { get; set; }
        [JsonProperty("friday_open_from")]
        public string Fri_From { get; set; }
        [JsonProperty("friday_open_to")]
        public string Fri_Till { get; set; }
        [JsonProperty("friday_close")]
        public string LabelClose5 { get; set; }
        [JsonProperty("saturday_open_from")]
        public string Sat_From { get; set; }
        [JsonProperty("saturday_open_to")]
        public string Sat_Till { get; set; }
        [JsonProperty("saturday_close")]
        public string LabelClose6 { get; set; }
        [JsonProperty("sunday_open_from")]
        public string Sun_From { get; set; }
        [JsonProperty("sunday_open_to")]
        public string Sun_Till { get; set; }
        [JsonProperty("sunday_close")]
        public string LabelClose7 { get; set; }
      
    }
    public class AppointmentStoreNew
    {
        public string AppoitmentTime { get; set; }
        public string AppoitmentDate { get; set; }
    }
}
