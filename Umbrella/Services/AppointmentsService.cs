using System;
using System.Collections.Generic;
using Umbrella.Models;
using UmbrellaRestClient.Services;
using Umbrella.Constants;
using RestSharp;
using System.Threading;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;
using Umbrella.Interfaces;

namespace Umbrella.Services
{
    public class AppointmentsService
    {

        public static IRestResponse SaveAppointment(Appointment ap)
        {
            IRestResponse response = null;
            try
            {            
                response = ServiceRestClient.ExecuteReturnPostRequest(ap, "appointments");
                if (response.Content != null)
                {
                    return (response);
                }
            }
            catch (Exception e)
            { }
            return response;
        }
        public AppointmentStoreUpdate GetCallbackHours()
        {
            var list = new AppointmentStoreUpdate();
            try
            {
                var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
                var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/callbackhours");
                var request = new RestRequest(Method.POST);
                request.AddParameter("partner_id", "77514");
                request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
                request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
                request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
                //   var content = response.Content;
                // List<Lead> convert = null;
                EventWaitHandle Wait = new AutoResetEvent(false);
                var asyncHandle = client.ExecuteAsync<AppointmentStoreUpdate>(request, response => {
                    System.Diagnostics.Debug.WriteLine("Appointment : " + response.Content);
                    try
                    {
                        var json = response.Content.Replace("<", "");
                        JObject jo = JObject.Parse(json);
                        var diskSpaceArray = jo.SelectToken("data", false).ToString().Replace("[", "").Replace("]", "");
                        list = JsonConvert.DeserializeObject<AppointmentStoreUpdate>(diskSpaceArray);
                        System.Diagnostics.Debug.WriteLine("list app : " + list.Fri_From);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("Appointment Error : " + e.ToString());
                    }

                    Wait.Set();
                });
                Wait.WaitOne();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("exception" + e.Message + " " + e.InnerException);
            }

            return list;
        }
    }
}
