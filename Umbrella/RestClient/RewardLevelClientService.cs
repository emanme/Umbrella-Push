using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UmbrellaRestClient.Services;
using Umbrella.Models;
using System.Net.Http;
using Umbrella.Constants;
using Umbrella.Interfaces;
using Xamarin.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Umbrella.RestClient
{
    public class RewardLevelClientService : ApiClient
    {
        protected override string Controller { get { return "reward_level"; } }

        public RewardLevelClientService()
        {
        }

        public async Task<int> GetRewardLevel(string email)
        {
            var rest = await ServiceRestClient.ExecuteGetTaskAsync("reward_level/?email="+ email).ConfigureAwait(false);
            System.Diagnostics.Debug.WriteLine("resultrest" + rest);
            var obj = JObject.Parse(rest.Content);
            System.Diagnostics.Debug.WriteLine("objreward" + obj);
            var result = (string)obj["reward_level"];
            System.Diagnostics.Debug.WriteLine("Resultreward" + result);
            if (result != null)
            {
                return int.Parse(result);
            }
            return 1;
        }

        public async Task<Rank> GetRankAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var rank = new Rank();

                try
                {
                    var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();

                    client.DefaultRequestHeaders.Add("umbrella-api-username", UmbrellaApi.USERNAME);
                    client.DefaultRequestHeaders.Add("umbrella-api-key", UmbrellaApi.PASSKEY);
                    client.DefaultRequestHeaders.Add("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("partner_id", credential.UserID.ToString())
                    });

                    var response = await client.PostAsync($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/rank", formContent);
                    var responseString = await response.Content.ReadAsStringAsync();

                    rank = JsonConvert.DeserializeObject<Rank>(responseString);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }

                return rank;
            }
        }
    }
}
