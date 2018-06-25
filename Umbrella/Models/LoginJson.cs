using System;
using System.Collections.Generic;

namespace Umbrella.Models
{
    public class LoginJson
    {
        public IList<IDictionary<string, dynamic>> data { get; set; }
        public LoginJson()
        {
        }
        public  string status { get; set; } 
        public  string barcode { get; set; } 
        public  string points { get; set; } 
        public string partner_id { get; set; }
        public string sub_account_id { get; set; }
        public string email { get; set; }
        public string message { get; set; }

    }
}
