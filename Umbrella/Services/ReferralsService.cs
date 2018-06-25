    using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Constants;
using Umbrella.Enums;
using Umbrella.Models;

namespace Umbrella.Services
{
    public class ReferralsService
    {
        public async Task<bool> SubmitOntraportContactApi(OntraportContact contact)
        {
            using (HttpClient client = new HttpClient())
            {
                var userProfile = contact;
                var content = JsonConvert.SerializeObject(userProfile, new JsonSerializerSettings());
                client.DefaultRequestHeaders.Add("Api-Appid", OntraportApi.API_APP_ID);
                client.DefaultRequestHeaders.Add("Api-Key", OntraportApi.API_KEY);
                var response = await client.PostAsync(OntraportApi.ONTRAPORT_API_LINK_CONTACTS, new StringContent(content, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
        }
        public async Task<bool> SubmitOntraportContactApiArmy(OntraportContactArmy contact)
        {
            using (HttpClient client = new HttpClient())
            {
                var userProfile = contact;
                var content = JsonConvert.SerializeObject(userProfile, new JsonSerializerSettings());
                client.DefaultRequestHeaders.Add("Api-Appid", OntraportApi.API_APP_ID);
                client.DefaultRequestHeaders.Add("Api-Key", OntraportApi.API_KEY);
                var response = await client.PostAsync(OntraportApi.ONTRAPORT_API_LINK_CONTACTS, new StringContent(content, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
        }
        public List<Referral> GetReferrals()
        {
            var list = new List<Referral>();

            list.Add(new Referral
            {
                Name = "Abraham Michael Edward Johnson",
                Business = "Elite Construction Services Ltd",
                Relationship = "Friend",
                EmailAddress = "from_test_mail@gmail.com",
                PhoneNumber = "09091234567",
                MobileNumber = "123-4567-890",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = ReferralStatus.BecamePartner,
                Created = DateTime.Now
            });

            list.Add(new Referral
            {
                Name = "Abraham Michael Edward Johnson",
                Business = "Elite Construction Services Ltd",
                Relationship = "Friend",
                EmailAddress = "from_test_mail@gmail.com",
                PhoneNumber = "09091234567",
                MobileNumber = "123-4567-890",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = ReferralStatus.NotSuitable,
                Created = DateTime.Now
            });

            list.Add(new Referral
            {
                Name = "Abraham Michael Edward Johnson",
                Business = "Elite Construction Services Ltd",
                Relationship = "Friend",
                EmailAddress = "from_test_mail@gmail.com",
                PhoneNumber = "09091234567",
                MobileNumber = "123-4567-890",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = ReferralStatus.FollowUpStage,
                Created = DateTime.Now
            });

            list.Add(new Referral
            {
                Name = "Abraham Michael Edward Johnson",
                Business = "Elite Construction Services Ltd",
                Relationship = "Friend",
                EmailAddress = "from_test_mail@gmail.com",
                PhoneNumber = "09091234567",
                MobileNumber = "123-4567-890",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = ReferralStatus.BecamePartner,
                Created = DateTime.Now
            });

            list.Add(new Referral
            {
                Name = "Abraham Michael Edward Johnson",
                Business = "Elite Construction Services Ltd",
                Relationship = "Friend",
                EmailAddress = "from_test_mail@gmail.com",
                PhoneNumber = "09091234567",
                MobileNumber = "123-4567-890",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = ReferralStatus.BecamePartner,
                Created = DateTime.Now
            });

            list.Add(new Referral
            {
                Name = "John Jackson",
                Business = "Premier Plumbers Ltd",
                Relationship = "Friend",
                EmailAddress = "from_test_mail@gmail.com",
                PhoneNumber = "09091234567",
                MobileNumber = "123-4567-890",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = ReferralStatus.NotSuitable,
                Created = DateTime.Now
            });

            list.Add(new Referral
            {
                Name = "John Jackson",
                Business = "Premier Plumbers Ltd",
                Relationship = "Friend",
                EmailAddress = "from_test_mail@gmail.com",
                PhoneNumber = "09091234567",
                MobileNumber = "123-4567-890",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = ReferralStatus.FollowUpStage,
                Created = DateTime.Now
            });

            list.Add(new Referral
            {
                Name = "John Jackson",
                Business = "Premier Plumbers Ltd",
                Relationship = "Friend",
                EmailAddress = "from_test_mail@gmail.com",
                PhoneNumber = "09091234567",
                MobileNumber = "123-4567-890",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = ReferralStatus.BecamePartner,
                Created = DateTime.Now
            });

            list.Add(new Referral
            {
                Name = "John Jackson",
                Business = "Premier Plumbers Ltd",
                Relationship = "Friend",
                EmailAddress = "from_test_mail@gmail.com",
                PhoneNumber = "09091234567",
                MobileNumber = "123-4567-890",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = ReferralStatus.FollowUpStage,
                Created = DateTime.Now
            });

            list.Add(new Referral
            {
                Name = "John Jackson",
                Business = "Premier Plumbers Ltd",
                Relationship = "Friend",
                EmailAddress = "from_test_mail@gmail.com",
                PhoneNumber = "09091234567",
                MobileNumber = "123-4567-890",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = ReferralStatus.BecamePartner,
                Created = DateTime.Now
            });

            return list;
        }
    }
}
