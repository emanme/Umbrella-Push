using System.Collections.Generic;
using Umbrella.Enums;
using Umbrella.Models;

namespace Umbrella.Services
{
    public class CharitiesService
    {
        public List<Charity> GetCharities()
        {
            var list = new List<Charity>();

            list.Add(new Charity
            {
                Name = "Richard Howard",
                Business = "Elite Construction Services Ltd",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris.",
                Donation = 15.20m,
                Status = CharityStatus.Funded
            });

            list.Add(new Charity
            {
                Name = "Richard Howard",
                Business = "Elite Construction Services Ltd",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris.",
                Donation = 15.20m,
                Status = CharityStatus.Cancelled
            });

            list.Add(new Charity
            {
                Name = "Richard Howard",
                Business = "Elite Construction Services Ltd",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris.",
                Donation = 15.20m,
                Status = CharityStatus.Funding
            });

            list.Add(new Charity
            {
                Name = "Richard Howard",
                Business = "Elite Construction Services Ltd",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris.",
                Donation = 15.20m,
                Status = CharityStatus.Funded
            });

            list.Add(new Charity
            {
                Name = "Richard Howard",
                Business = "Elite Construction Services Ltd",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris.",
                Donation = 15.20m,
                Status = CharityStatus.Funding
            });

            list.Add(new Charity
            {
                Name = "Richard Howard",
                Business = "Elite Construction Services Ltd",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris.",
                Donation = 15.20m,
                Status = CharityStatus.Funding
            });

            list.Add(new Charity
            {
                Name = "Richard Howard",
                Business = "Elite Construction Services Ltd",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris.",
                Donation = 15.20m,
                Status = CharityStatus.Cancelled
            });

            list.Add(new Charity
            {
                Name = "Richard Howard",
                Business = "Elite Construction Services Ltd",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris.",
                Donation = 15.20m,
                Status = CharityStatus.Funded
            });

            list.Add(new Charity
            {
                Name = "Richard Howard",
                Business = "Elite Construction Services Ltd",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris.",
                Donation = 15.20m,
                Status = CharityStatus.Cancelled
            });

            list.Add(new Charity
            {
                Name = "Richard Howard",
                Business = "Elite Construction Services Ltd",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris.",
                Donation = 15.20m,
                Status = CharityStatus.Funding
            });

            return list;
        }
    }
}
