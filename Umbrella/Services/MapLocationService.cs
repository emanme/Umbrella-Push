using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Umbrella.Constants;
using Umbrella.Interfaces;
using Umbrella.Models;
using Xamarin.Forms;

namespace Umbrella.Services
{
    public class MapLocationService
    {
        public List<MapLocation> GetMapRecruits()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/getfieldmaps/");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", 24757);
            request.AddParameter("type", "recruit");
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME_NEW);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY_NEW);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID_NEW);

            List<MapLocation> convert = null;
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<List<MapLocation>>(request, response => {
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("data", false).ToString();
                    System.Diagnostics.Debug.WriteLine("testing " + diskSpaceArray);
                    convert = JsonConvert.DeserializeObject<List<MapLocation>>(diskSpaceArray);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Pin Recruits Error : " + e.ToString());
                    convert = new List<MapLocation>();
                }

                Wait.Set();
            });
            Wait.WaitOne();
            return convert;
        }
        public List<MapLocation> GetMapComrades()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/getfieldmaps/");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", 24757);
            request.AddParameter("type", "comrades");
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME_NEW);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY_NEW);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID_NEW);

            List<MapLocation> convert = null;
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<List<MapLocation>>(request, response => {
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("data", false).ToString();
                    System.Diagnostics.Debug.WriteLine("testing com " + diskSpaceArray);
                    convert = JsonConvert.DeserializeObject<List<MapLocation>>(diskSpaceArray);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Pin Comrades Error : " + e.ToString());
                    convert = new List<MapLocation>();
                }

                Wait.Set();
            });
            Wait.WaitOne();
            return convert;
        }
    }
}
