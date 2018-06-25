using System;
using Umbrella.Enums;

namespace Umbrella.Models
{
    public class Referral
    {
        public string Name { get; set; }

        public string Business { get; set; }

        public string Relationship { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string Message { get; set; }

        public ReferralStatus Status { get; set; }

        public DateTime Created { get; set; }
    }
}
