using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Umbrella.Constants;
using Umbrella.Interfaces;
using Umbrella.Models;
using Xamarin.Forms;

namespace Umbrella.Services
{
    public class ConquerorRankingService
    {
        public List<ConquerorRanking> GetMostResourcesList()
        {
            var list = new List<ConquerorRanking>()
            {
                new ConquerorRanking()
                {
                    Name = "PRIVATE DARTHOS",
                    RankNumber = "1",
                    Description = "I am a young professional working part-time as IT analyst and I like cars.",
                    Location = "London",
                    DateRanked = new DateTime(17,06,12),
                    NumberOfAchievements = "22",
                    Amount ="£100"
                },
                 new ConquerorRanking()
                {
                    Name = "GENERAL WILLIS",
                    RankNumber = "2",
                    Description = "I am a young professional working part-time as IT analyst and I like cars.",
                    Location = "Liverpool",
                    DateRanked = new DateTime(17,10,01),
                    NumberOfAchievements = "19",
                     Amount ="£82"
                },
                  new ConquerorRanking()
                {
                    Name = "CAPTAIN HAMILTON",
                    RankNumber = "3",
                    Description = "I am a young professional working part-time as IT analyst and I like cars.",
                    Location = "Glasgow",
                    DateRanked = new DateTime(17,09,23),
                    NumberOfAchievements = "16",
                     Amount ="£74"
                },
            };
            return list;
        }
        public List<ConquerorRanking> GetMostNewRecruitsList()
        {
            var list = new List<ConquerorRanking>()
            {
                new ConquerorRanking()
                {
                    Name = "PRIVATE DARTHOS",
                    RankNumber = "1",
                    Description = "I am a young professional working part-time as IT analyst and I like cars.",
                    Location = "London",
                    DateRanked = new DateTime(17,06,12),
                    NumberOfAchievements = "22",
                },
                 new ConquerorRanking()
                {
                    Name = "GENERAL WILLIS",
                    RankNumber = "2",
                    Description = "I am a young professional working part-time as IT analyst and I like cars.",
                    Location = "Liverpool",
                    DateRanked = new DateTime(17,10,01),
                    NumberOfAchievements = "19",
                },
                  new ConquerorRanking()
                {
                    Name = "CAPTAIN HAMILTON",
                    RankNumber = "3",
                    Description = "I am a young professional working part-time as IT analyst and I like cars.",
                    Location = "Glasgow",
                    DateRanked = new DateTime(17,09,23),
                    NumberOfAchievements = "16"
                },
            };
            return list;
        }
        public List<ConquerorRanking> GetMostNewComradesList()
        {
            var list = new List<ConquerorRanking>()
            {
                new ConquerorRanking()
                {
                    Name = "PRIVATE DARTHOS",
                    RankNumber = "1",
                    Description = "I am a young professional working part-time as IT analyst and I like cars.",
                    Location = "London",
                    DateRanked = new DateTime(17,06,12),
                    NumberOfAchievements = "22",
                },
                 new ConquerorRanking()
                {
                    Name = "GENERAL WILLIS",
                    RankNumber = "2",
                    Description = "I am a young professional working part-time as IT analyst and I like cars.",
                    Location = "Liverpool",
                    DateRanked = new DateTime(17,10,01),
                    NumberOfAchievements = "19",
                },
                  new ConquerorRanking()
                {
                    Name = "CAPTAIN HAMILTON",
                    RankNumber = "3",
                    Description = "I am a young professional working part-time as IT analyst and I like cars.",
                    Location = "Glasgow",
                    DateRanked = new DateTime(17,09,23),
                    NumberOfAchievements = "16"
                },
            };
            return list;
        }
        public List<TopRecruits> GetTopRecruits()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/targets/");

            var request = new RestRequest(Method.POST);
            request.AddParameter("type", "recruit");
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);

            List<TopRecruits> convert = new List<TopRecruits>();

            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<TopRecruits>(request, response => {
                System.Diagnostics.Debug.WriteLine(response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("response", false).ToString();
                    convert = JsonConvert.DeserializeObject<List<TopRecruits>>(diskSpaceArray);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Top Recruit Error : " + e.ToString());
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;
        }
        public List<TopComrades> GetTopComrades()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/targets/");

            var request = new RestRequest(Method.POST);
            request.AddParameter("type", "comrade");
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);

            List<TopComrades> convert = new List<TopComrades>();

            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<TopComrades>(request, response => {
                System.Diagnostics.Debug.WriteLine(response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("response", false).ToString();
                    convert = JsonConvert.DeserializeObject<List<TopComrades>>(diskSpaceArray);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Top Comrades Error : " + e.ToString());
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;
        }
        public List<TopResources> GetTopResources()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/targets/");

            var request = new RestRequest(Method.POST);
            request.AddParameter("type", "resources");
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);

            List<TopResources> convert = new List<TopResources>();

            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<TopResources>(request, response => {
                System.Diagnostics.Debug.WriteLine(response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("response", false).ToString();
                    convert = JsonConvert.DeserializeObject<List<TopResources>>(diskSpaceArray);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Top Resources Error : " + e.ToString());
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;
        }

    }
}
