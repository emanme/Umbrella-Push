using System;
using System.Collections.Generic;
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
    public class CalendarEventsService
    {
        public List<CalendarEvent> GetCalendarApiWeek()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/calendar/");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddParameter("action", "get");
            request.AddParameter("1", "flag_status");
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);

            List<CalendarEvent> convert = null;
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<List<CalendarEvent>>(request, response => {
                System.Diagnostics.Debug.WriteLine("Calendar Week Data " + response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("data", false).ToString();
                    if (diskSpaceArray == "[]")
                    {
                        convert = new List<CalendarEvent>();
                    }
                    else
                    {
                        convert = JsonConvert.DeserializeObject<List<CalendarEvent>>(diskSpaceArray);
                        foreach (var item in convert)
                        {
                            item.Subject = item.Subject.Replace("\\", "");
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Calendar Error : " + e.ToString());
                    convert = new List<CalendarEvent>();
                }

                Wait.Set();
            });
            Wait.WaitOne();
            return convert;
        }
        public List<CalendarEvent> GetCalendarApiMonth()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/calendar/");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddParameter("action", "get");
            request.AddParameter("2", "flag_status");
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);

            List<CalendarEvent> convert = null;
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<List<CalendarEvent>>(request, response => {
                System.Diagnostics.Debug.WriteLine("Calendar Month Data " + response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("data", false).ToString();
                    if (diskSpaceArray == "[]")
                    {
                        convert = new List<CalendarEvent>();
                    }
                    else
                    {
                        convert = JsonConvert.DeserializeObject<List<CalendarEvent>>(diskSpaceArray);
                        foreach (var item in convert)
                        {
                            item.Subject = item.Subject.Replace("\\", "");
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Calendar Error : " + e.ToString());
                    convert = new List<CalendarEvent>();
                }

                Wait.Set();
            });
            Wait.WaitOne();
            return convert;
        }
        public List<CalendarEvent> GetCalendarApiYear()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/calendar/");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddParameter("action", "get");
            request.AddParameter("0", "flag_status");
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);

            List<CalendarEvent> convert = null;
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<List<CalendarEvent>>(request, response => {
                System.Diagnostics.Debug.WriteLine("Calendar Year Data " + response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("data", false).ToString();
                    if (diskSpaceArray == "[]")
                    {
                        convert = new List<CalendarEvent>();
                    }
                    else
                    {
                        convert = JsonConvert.DeserializeObject<List<CalendarEvent>>(diskSpaceArray);
                        foreach (var item in convert)
                        {
                            item.Subject = item.Subject.Replace("\\", "");
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Calendar Error : " + e.ToString());
                    convert = new List<CalendarEvent>();
                }

                Wait.Set();
            });
            Wait.WaitOne();
            return convert;
        }
        public List<CalendarEvent> GetCalendarApi()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/calendar/");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddParameter("action", "get");
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);

            List<CalendarEvent> convert = null;
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<List<CalendarEvent>>(request, response => {
                System.Diagnostics.Debug.WriteLine("Calendar Data " + response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("data", false).ToString();
                    if (diskSpaceArray == "[]")
                    {
                        convert = new List<CalendarEvent>();
                    }
                    else
                    {
                        convert = JsonConvert.DeserializeObject<List<CalendarEvent>>(diskSpaceArray);
                        foreach (var item in convert)
                        {
                            item.Subject = item.Subject.Replace("\\", "");
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Calendar Error : " + e.ToString());
                    convert = new List<CalendarEvent>();
                }

                Wait.Set();
            });
            Wait.WaitOne();
            return convert;
        }
    }
}
