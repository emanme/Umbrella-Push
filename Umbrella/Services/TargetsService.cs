using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umbrella.Constants;
using Umbrella.Interfaces;
using Umbrella.Models;
using Xamarin.Forms;

namespace Umbrella.Services
{
    public class TargetsService
    {
        public async Task<ListTargets> GetTargets()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var list = new ListTargets();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("umbrella-api-username", UmbrellaApi.USERNAME);
                client.DefaultRequestHeaders.Add("umbrella-api-key", UmbrellaApi.PASSKEY);
                client.DefaultRequestHeaders.Add("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("partner_id", credential.UserID.ToString())
                });
                var response = await client.PostAsync($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/targets/", formContent);
                var responseString = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<ListTargets>(responseString);

            }

            return list;
        }
        public List<Target> GetTargetsTrial()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/targets/");

            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);

            List<Target> convert = new List<Target>();

            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<Target>(request, response => {
                System.Diagnostics.Debug.WriteLine(response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");   
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("response", false).ToString();
                    convert = JsonConvert.DeserializeObject<List<Target>>(diskSpaceArray);
                    convert = convert.OrderBy(x => x.TargetDate.Month).ToList();
                    App.TargetsDatabase.SaveTargetsAsync(convert);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("TargetError : " + e.ToString());
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;
        }

    }
}
