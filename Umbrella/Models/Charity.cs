using Umbrella.Enums;

namespace Umbrella.Models
{
    public class Charity
    {
        public string Name { get; set; }

        public string Business { get; set; }

        public string Message { get; set; }

        public decimal Donation { get; set; }

        public CharityStatus Status { get; set; }
    }
}
