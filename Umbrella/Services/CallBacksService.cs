using System;
using System.Collections.Generic;
using Umbrella.Models;

namespace Umbrella.Services
{
    public class CallBacksService
    {
        public List<CallBack> GetCallBacks()
        {
            var list = new List<CallBack>();

            list.Add(new CallBack
            {
                Lead = new Lead
                {
                    EnquiryId = "15490-16792-1",
                    ContactId = "1",
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
                },
                ContactType = "Mobile",
                ScheduledDateTime = DateTime.Now
            });

            list.Add(new CallBack
            {
                Lead = new Lead
                {
                    EnquiryId = "15490-16792-1",
                    ContactId = "2",
                  //  Name = "2Abraham Michael Edward Johnson",
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
                },
                ContactType = "Mobile",
                ScheduledDateTime = DateTime.Now
            });

            list.Add(new CallBack
            {
                Lead = new Lead
                {
                    EnquiryId ="15490-16792-1",
                    ContactId = "3",
                  //  Name = "3Abraham Michael Edward Johnson",
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
                },
                ContactType = "Mobile",
                ScheduledDateTime = DateTime.Now
            });
            /*
            list.Add(new CallBack
            {
                Lead = new Lead
                {
                    EnquiryId = "15490-16792-4",
                    ContactId = "4",
                    Name = "4Abraham Michael Edward Johnson",
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
                },
                ContactType = "Mobile",
                ScheduledDateTime = DateTime.Now
            });

            list.Add(new CallBack
            {
                Lead = new Lead
                {
                    EnquiryId = "15490-16792-5",
                    ContactId = "5",
                    Name = "5Abraham Michael Edward Johnson",
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
                },
                ContactType = "Mobile",
                ScheduledDateTime = DateTime.Now
            });

            list.Add(new CallBack
            {
                Lead = new Lead
                {
                    EnquiryId = "15490-16792-6",
                    ContactId = "6",
                    Name = "6Richard Howard",
                    Business = "Premier Mobile Phones Ltd",
                    Email = "richard1000@gmail.com",
                    Mobile = "0776 776 77615",
                    Home = "01689 874215",
                    Office = "0203 458 50",
                    Source = "Live Web Chat",
                    Category = "Lead",
                    Status = "Scheduled",
                    Enquiry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                    Created = DateTime.Now
                },
                ContactType = "Mobile",
                ScheduledDateTime = DateTime.Now
            });

            list.Add(new CallBack
            {
                Lead = new Lead
                {
                    EnquiryId = "15490-16792-7",
                    ContactId = "7",
                    Name = "7Richard Howard",
                    Business = "Premier Mobile Phones Ltd",
                    Email = "richard1000@gmail.com",
                    Mobile = "0776 776 77615",
                    Home = "01689 874215",
                    Office = "0203 458 50",
                    Source = "Live Web Chat",
                    Category = "Lead",
                    Status = "Scheduled",
                    Enquiry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                    Created = DateTime.Now
                },
                ContactType = "Mobile",
                ScheduledDateTime = DateTime.Now
            });

            list.Add(new CallBack
            {
                Lead = new Lead
                {
                    EnquiryId = "15490-16792-8",
                    ContactId = "8",
                    Name = "8Richard Howard",
                    Business = "Premier Mobile Phones Ltd",
                    Email = "richard1000@gmail.com",
                    Mobile = "0776 776 77615",
                    Home = "01689 874215",
                    Office = "0203 458 50",
                    Source = "Live Web Chat",
                    Category = "Lead",
                    Status = "Scheduled",
                    Enquiry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                    Created = DateTime.Now
                },
                ContactType = "Mobile",
                ScheduledDateTime = DateTime.Now
            });

            list.Add(new CallBack
            {
                Lead = new Lead
                {
                    EnquiryId = "15490-16792-9",
                    ContactId = "9",
                    Name = "9Richard Howard",
                    Business = "Premier Mobile Phones Ltd",
                    Email = "richard1000@gmail.com",
                    Mobile = "0776 776 77615",
                    Home = "01689 874215",
                    Office = "0203 458 50",
                    Source = "Live Web Chat",
                    Category = "Lead",
                    Status = "Scheduled",
                    Enquiry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                    Created = DateTime.Now
                },
                ContactType = "Mobile",
                ScheduledDateTime = DateTime.Now
            });

            list.Add(new CallBack
            {
                Lead = new Lead
                {
                    EnquiryId = "15490-16792-10",
                    ContactId = "10",
                    Name = "Richard Howard",
                    Business = "Premier Mobile Phones Ltd",
                    Email = "richard1000@gmail.com",
                    Mobile = "0776 776 77615",
                    Home = "01689 874215",
                    Office = "0203 458 50",
                    Source = "Live Web Chat",
                    Category = "Lead",
                    Status = "Scheduled",
                    Enquiry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                    Created = DateTime.Now
                },
                ContactType = "Mobile",
                ScheduledDateTime = DateTime.Now
            });*/

            return list;
        }
    }
}
