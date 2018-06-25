using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Umbrella.Constants;
using Umbrella.Interfaces;
using Umbrella.Models;
using Umbrella.RestClient;
using Xamarin.Forms;

namespace Umbrella.Services
{
    public class RewardLevelsService
    {
        private RewardLevelClientService _rewardLevelClientService;

        public RewardLevelsService()
        {
            _rewardLevelClientService = new RewardLevelClientService();
        }

        public async Task<int> GetRewardLevel(string email)
        {
            return await _rewardLevelClientService.GetRewardLevel(email);
        }

        public async Task<Rank> GetRankAsync()
        {
            return await _rewardLevelClientService.GetRankAsync();
        }
        public Rank GetReward()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/rank/");

            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);

            Rank convert = null;

            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<Rank>(request, response => {
                System.Diagnostics.Debug.WriteLine(response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    convert = JsonConvert.DeserializeObject<Rank>(json);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("RankError : " + e.ToString());
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;

        }
        public List<RewardLevel> GetRewardLevels()
        {
            var list = new List<RewardLevel>();

            list.Add(new RewardLevel
            {
                Level = 1,
                ImageUri = "ar1",
                Rewards = new List<string>
                {
                    "A Big Kiss"
                },
                Requirements = new List<string>
                {
                    "Active Umbrella Account & Are Paying Your Bills"
                },
                IsCurrent = false
            });

            list.Add(new RewardLevel
            {
                Level = 2,
                ImageUri = "ar2",
                Rewards = new List<string>
                {
                    "Reputation Radar"  ,
                    "Fax to Email Tool",
                    "Voice Broadcast Tool",
                    "SMS Broadcast Tool",
                    "Umbrella Branding Removed",
                    "Umbrella Branding Removed"
                },
                Requirements = new List<string>
                {
                    "Connected Call Answering or Live Chat Service",
                    "Answers 60 Second Satisfaction Survey Monthly",
                    "Facebook Account Synced with Umbrella",
                    "Backup Payment Method on File"
                },
                IsCurrent = false
            });

            list.Add(new RewardLevel
            {
                Level = 3,
                ImageUri = "ar3",
                Rewards = new List<string>
                {
                    "Company & Director Radar",
                    "Consumer Radar (coming soon)",
                    "Monthly Raffle with £200+ Prize",
                    "Medium Weight Directory Ranking"
                },
                Requirements = new List<string>
                {
                    "Using Postcode or Eligibility Checker on Website",
                    "Using Call Answering + Live Chat Service",
                    "Directory Given to Ineligible Leads by Phone, Email, etc",
                    "Using Umbrella Mobile App"
                },
                IsCurrent = true
            });

            list.Add(new RewardLevel
            {
                Level = 4,
                ImageUri = "ar4",
                Rewards = new List<string>
                {
                    "Invitations to Umbrella’s Events",
                    "Media Contacts & PR Services",
                    "Advanced Call Management",
                    "TPS Database Access",
                    "Super Powered Radars",
                    "TPS Database Access",
                },
                Requirements = new List<string>
                {
                    "Qualifying Questions via Phone, Live Chat & Checker",
                    "Eligibility/Postcode Tool on ALL Major Webpages",
                    "Updates Status of All Leads in Support Centre",
                    "Actively BUYING Leads from the Umbrella Network"
                },
                IsCurrent = false
            });

            list.Add(new RewardLevel
            {
                Level = 5,
                ImageUri = "ar5",
                Rewards = new List<string>
                {
                    "FREE Part Time Virtual PA",
                    "Heavyweight Directory Ranking",
                    "VIP Treatment at Umbrella’s Events"
                },
                Requirements = new List<string>
                {
                    "At least 2 Qualifying Questions",
                    "Businesses Prime 01/02/08x Number Supplied by us",
                    "Maintains Account Balance of £500+",
                    "Uses Umbrella’s “Smart Contact Forms” on Website",
                    "Refers at Least 1 New Partner to us a Month",
                    "Maintains Account Balance of £500+",
                },
                IsCurrent = false
            });

            return list;
        }
    }
}
