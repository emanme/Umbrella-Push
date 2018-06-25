using System;
using System.Collections.Generic;
using Umbrella.Models;

namespace Umbrella.Services
{
    public class LeadsService
    {
        public List<Lead> GetLeads()
        {
            var list = new List<Lead>();
          
            list.Add(new Lead
            {
                EnquiryId = "15490 - 16792 - 1",
                ContactId = "15490",
                //Name = "1Abraham Michael Edward Johnson",
                Business = "Elite Construction Services Ltd",
                Email = "richard1000@gmail.com",
                Mobile = "0776 776 77615",
                Home = "01689 874215",
                Office = "0203 458 50",
                Source = "Live Web Chat",
                Category = "Lead",
                Status = "Upcoming",
                Enquiry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Created = DateTime.Now
            }); 
 
            return list;
        }
    }
}
