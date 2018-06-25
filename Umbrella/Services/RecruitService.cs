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
    public class RecruitService
    {
        public List<RecruitData> GetRecruitingDataApi()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/referred-and-earned/");

            var request = new RestRequest(Method.POST);
            request.AddParameter("owner_partner_id", credential.UserID.ToString());
            request.AddParameter("action", "get");
            request.AddParameter("populate_website", "army");
            request.AddParameter("service_name", "recruit");
            request.AddParameter("status", "lead");
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME_NEW);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY_NEW);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID_NEW);

            List<RecruitData> convert = new List<RecruitData>();

            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<RecruitData>(request, response => {
                System.Diagnostics.Debug.WriteLine("Recruit Lead " + response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("data", false).ToString();
                    convert = JsonConvert.DeserializeObject<List<RecruitData>>(diskSpaceArray);
                    convert = convert.Where(e => e.Status == "lead" && e.Type == "recruit").Select(e => e).OrderByDescending(e => e.DateRecruited).ToList();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("RecruitData Error : " + e.ToString());
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;
        }
        public List<RecruitData> GetRecruitingDataSoldApi()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/referred-and-earned/");

            var request = new RestRequest(Method.POST);
            request.AddParameter("owner_partner_id", credential.UserID.ToString());
            request.AddParameter("action", "get");
            request.AddParameter("populate_website", "army");
            request.AddParameter("service_name", "recruit");
            request.AddParameter("status", "sold");
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME_NEW);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY_NEW);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID_NEW);

            List<RecruitData> convert = new List<RecruitData>();

            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<RecruitData>(request, response => {
                System.Diagnostics.Debug.WriteLine("Recruit Sold " +response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("data", false).ToString();
                    convert = JsonConvert.DeserializeObject<List<RecruitData>>(diskSpaceArray);
                    convert = convert.Where(e => e.Status == "sold" && e.Type == "recruit").Select(e => e).OrderByDescending(e => e.DateRecruited).ToList();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("RecruitData Sold Error : " + e.ToString());
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;
        }

        public List<Recruit> GetRecruitedList()
        {
            var list = new List<Recruit>
            {
                new Recruit
                {
                   Name = "John Smith",
                   Business = "Accenture",
                   Description = "John Smith developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2018,6,12),
                   Morale = "85"
                },
                new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
                new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
                 new Recruit
                {
                   Name = "John Smith",
                   Business = "Accenture",
                   Description = "John Smith developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2018,6,12),
                   Morale = "85"
                },
                new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
                 new Recruit
                {
                   Name = "John Smith",
                   Business = "Accenture",
                   Description = "John Smith developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2018,6,12),
                   Morale = "85"
                },
                new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
                   new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
                 new Recruit
                {
                   Name = "John Smith",
                   Business = "Accenture",
                   Description = "John Smith developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2018,6,12),
                   Morale = "85"
                },
                new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
                   new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
            };

            return list;
        }
        public List<Recruit> GetRecruitingList()
        {
            var list = new List<Recruit>
            {
                new Recruit
                {
                   Name = "John Smith",
                   Business = "Accenture",
                   Description = "John Smith developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2018,6,12),
                   Morale = "85"
                },
                new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
                new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
                 new Recruit
                {
                   Name = "John Smith",
                   Business = "Accenture",
                   Description = "John Smith developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2018,6,12),
                   Morale = "85"
                },
                new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
                 new Recruit
                {
                   Name = "John Smith",
                   Business = "Accenture",
                   Description = "John Smith developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2018,6,12),
                   Morale = "85"
                },
                new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
                   new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
                 new Recruit
                {
                   Name = "John Smith",
                   Business = "Accenture",
                   Description = "John Smith developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2018,6,12),
                   Morale = "85"
                },
                new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
                   new Recruit
                {
                   Name = "Paula Clark",
                   Business = "Barclays Bank",
                   Description = "Paula Clark developed the theory of relativity, one of the 2 pillars of physics.",
                   DateRecruited = new DateTime(2017,12,6),
                   Morale = "50"
                },
            };

            return list;
        }
    }
}
