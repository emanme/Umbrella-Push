using System;
namespace Umbrella.Models
{
    public class LoyaltyData
    {
        public string points { get; set; }
        public string barcodesrc { get; set; }
        public byte barcodedata { get; set; }
 
    }
    public class LeadsData
    {
       

        public string id{ get; set; }
        public string partner_id{ get; set; }
        public string title{ get; set; }
        public string first_name{ get; set; }
        public string last_name{ get; set; }
        public string  mobile_number{ get; set; }
        public string home_phone{ get; set; }
        public string office_phone{ get; set; }
        public string fax_number{ get; set; }
        public string email_address{ get; set; }
        public string work_email{ get; set; }
        public string facebook_email{ get; set; }
        public string website{ get; set; }
        public string company{ get; set; }
        public string birth_date{ get; set; }
        public string company_number{ get; set; }
        public string created_at{ get; set; }
        public string updated_at{ get; set; }
        public string address_line1{ get; set; }
        public string address_line2{ get; set; }
        public string town{ get; set; }
        public string city{ get; set; }
        public string county{ get; set; }
        public string postal_code{ get; set; }
        public string country{ get; set; }
        public string user_id{ get; set; }
        public string user_email{ get; set; }
    }
}
