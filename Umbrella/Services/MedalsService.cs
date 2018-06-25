using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umbrella.Constants;
using Umbrella.Interfaces;
using Umbrella.Models;
using Xamarin.Forms;

namespace Umbrella.Services
{
    public class MedalsService  
    {
        public List<Medal> GetAllMedals()
        {
            var list = new List<Medal>
            {
                new Medal()
                {
                    Id = "6",
                    IntroducerId = "16792",
                    PartnerId = "16792",
                    MedalName = "Victory Medal",
                    Status = "lock"
                },
            };
            return list;
        }
        public List<Medal> GetMedals()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/getmedals/");

            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);

            List<Medal> convert = new List<Medal>();
            var medalOrigList = new List<string>
            {
                "Victory Medal",
                "Comms Expert Medal",
                "Conqueror Medal",
                "Bravery Medal",
                "Defender Medal",
                "Intelligence Medal"
            };
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<Medal>(request, response => {
                System.Diagnostics.Debug.WriteLine(response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("response", false).ToString();
                    convert = JsonConvert.DeserializeObject<List<Medal>>(diskSpaceArray);
                    convert = convert.OrderBy(x => medalOrigList.IndexOf(x.MedalName)).ToList();
                    App.MedalDatabase.SaveMedalsAsync(convert);

                    foreach (var item in convert)
                    {
                        System.Diagnostics.Debug.WriteLine("medals " + item.MedalName + " " + item.PartnerId + " " + item.Status);
                    }

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("MedalError : " + e.ToString());
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;
        }
    }
}
