using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.Models
{
    public class StripeApiCustomer
    {
        public string id { get; set; }
        public string account_balance { get; set; }
        public string email { get; set; }
        public string source { get; set; }
    }
    public class RootStripeApiJsonData
    {
        public List<StripeApiCustomer> data { get; set; }
    }
}
