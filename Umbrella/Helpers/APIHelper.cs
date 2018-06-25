using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Umbrella.Models;
using Umbrella.Constants;
using Umbrella.Enums;
using Xamarin.Forms;
using Umbrella.Interfaces;
using Umbrella.Models.Leads;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Net.Http;
namespace Umbrella.Helpers
{ 
    public static class APIHelper
    { 
        public async static Task<LoyaltyData> GetLoyaltyAsync()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
           
            var ls = new LoyaltyData();
            // var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/loyaltycard/");
            var client = new RestSharp.RestClient("http://mastereman.com/firebase/qr.php");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
            System.Diagnostics.Debug.WriteLine("GetLoyaltyAsync : " + credential.UserID.ToString());
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<LoyaltyData>(request, response => {
                System.Diagnostics.Debug.WriteLine(response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    ls = JsonConvert.DeserializeObject<LoyaltyData>(json);
                }
                catch (InvalidCastException e)
                {
                    System.Diagnostics.Debug.WriteLine("ERRor : " + e.ToString());
                }

                Wait.Set();
            });
            Wait.WaitOne();

            if (ls.points == "0")
            {
                System.Diagnostics.Debug.WriteLine("NULL if Stat" + ls.points);

                 
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("else Stat" + ls.points);


                //u.Registered = "";
                System.Diagnostics.Debug.WriteLine("u.Id " + ls.barcodedata);



            }

            return ls;
        }
        
       
         

        class AuthenticationResult
        {
            public AuthenticationStatus Status { get; set; }
            public User User { get; set; }
        }
    }
    public class APIHelper2{

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
                    convert = new List<TopRecruits>();
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
                    convert = new List<TopComrades>();
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
                    convert = new List<TopResources>();
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;
        }

        public List<Lead> GetLead()         {             var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();             var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/enquiryusers/");             var ls = new Lead();             var request = new RestRequest(Method.POST);             request.AddParameter("partner_id", credential.UserID.ToString());             request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);             request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);             request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);              List<Lead> convert = null;             EventWaitHandle Wait = new AutoResetEvent(false);              var asyncHandle = client.ExecuteAsync<List<Lead>>(request, response => {
                System.Diagnostics.Debug.WriteLine("Lead " + response.Content);                 try                 {
                    var json = response.Content.Replace("<", "");                     JObject jo = JObject.Parse(json);                     var diskSpaceArray = jo.SelectToken("data", false).ToString();
                    if (diskSpaceArray == "[]"){
                        convert = new List<Lead>();
                    }
                    else{
                        convert = JsonConvert.DeserializeObject<List<Lead>>(diskSpaceArray);
                    }

                }                 catch (Exception e)                 {                     System.Diagnostics.Debug.WriteLine("Lead Error : " + e.ToString());                     convert = new List<Lead>();                 }                  Wait.Set();             });             Wait.WaitOne();             return convert;         }
        public Loyalty GetLoyalty()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();

            //  var ls = new Lead();

            System.Diagnostics.Debug.WriteLine($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/loyaltycard/");

           // var client = new RestSharp.RestClient("http://mastereman.com/restful/sampleleads.php");

            var ls = new Loyalty();
             var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/loyaltycard/");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
            //   var content = response.Content;
           // List<Lead> convert = null;
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<Loyalty>(request, response => {
                System.Diagnostics.Debug.WriteLine("Loyalty " +response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    ls = JsonConvert.DeserializeObject<Loyalty>(json);
                    App.LoyaltyDatabase.SaveLoyaltysAsync(ls);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("ERRor : " + e.ToString());
                    ls = new Loyalty();
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return ls;
        }
     /*   public List<Lead> GetDatabaseLead()
        {
            var l = await App.LeadsDatabase.GetItemsAsync();
            var ll = new List<Lead>();
            foreach (var o in l)
            {
                System.Diagnostics.Debug.WriteLine("x list " + o.Name);
                ll.Add(o);
            }
            return ll;
            
        }*/

        public List<CallBack> GetCallBack()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();

            var ls = new CallBack();
            // var dd = new Data();
            // var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/loyaltycard/");
            var client = new RestSharp.RestClient("http://mastereman.com/firebase/leads.php");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
            System.Diagnostics.Debug.WriteLine("GetCallBack: " + credential.UserID.ToString());

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            System.Diagnostics.Debug.WriteLine("ERRor : " + content.ToString());
            JObject jo = JObject.Parse(content);
            var diskSpaceArray = jo.SelectToken("data", false).ToString();

            List<CallBack> convert = JsonConvert.DeserializeObject<List<CallBack>>(diskSpaceArray);

            // DiskSpaceInfo[] diskSpaceArray = jo.SelectToken("d", false).ToObject<DiskSpaceInfo[]>();
            // System.Diagnostics.Debug.WriteLine("Count : " + convert);

            return convert;
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
                System.Diagnostics.Debug.WriteLine("Medal " + response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("response", false).ToString();
                    convert = JsonConvert.DeserializeObject<List<Medal>>(diskSpaceArray);
                    convert = convert.OrderBy(x => medalOrigList.IndexOf(x.MedalName)).ToList();
                    App.MedalDatabase.SaveMedalsAsync(convert);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("MedalError : " + e.ToString());
                    convert = new List<Medal>();
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;
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
                System.Diagnostics.Debug.WriteLine("Rank " + response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    convert = JsonConvert.DeserializeObject<Rank>(json);
                    App.RankDatabase.SaveRanksAsync(convert);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("RankError : " + e.ToString());
                    convert = new Rank();
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;

        }
        public async Task<RewardLevel> SendReward(Notes note)
        {

            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();

            //  var ls = new Lead();

            //System.Diagnostics.Debug.WriteLine($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/enquiryusers/");

            var client = new RestSharp.RestClient("http://mastereman.com/restful/pages/samplereward.php");

            var ls = new Lead();
            //   var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/enquiryusers/");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddParameter("status", note.status);
            request.AddParameter("category", note.category);
            request.AddParameter("contact_enquiry", note.contact_enquiry);
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
            //   var content = response.Content;
            RewardLevel convert = null;
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<Lead>(request, response => {
                System.Diagnostics.Debug.WriteLine(response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    // var diskSpaceArray = jo.SelectToken("data", false).ToString();
                    convert = JsonConvert.DeserializeObject<RewardLevel>(json);
                    // convert = JsonConvert.DeserializeObject<RewardLevel>(diskSpaceArray);

                    System.Diagnostics.Debug.WriteLine("jo : " + convert.ToString());
                    System.Diagnostics.Debug.WriteLine("-end-");

                }
                catch (InvalidCastException e)
                {
                    System.Diagnostics.Debug.WriteLine("ERRor : " + e.ToString());
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;
        }
        public async Task<List<Notes>> GetNotes()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();

            //  var ls = new Lead();

          //  System.Diagnostics.Debug.WriteLine($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/enquiryusers/");

            var client = new RestSharp.RestClient("http://mastereman.com/restful/pages/notes.php");

            var ls = new Notes();
            
           // var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/notes/");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
            //   var content = response.Content;
            List<Notes> convert = null;
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<Notes>(request, response => {
                System.Diagnostics.Debug.WriteLine("notes "+response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("data", false).ToString();
                    // ls = JsonConvert.DeserializeObject<Lead>(json);
                    convert = JsonConvert.DeserializeObject<List<Notes>>(diskSpaceArray);

                    System.Diagnostics.Debug.WriteLine("convert : " + convert.Count());

                }
                 
                catch (InvalidCastException e)
                {
                    System.Diagnostics.Debug.WriteLine("ERRor : " + e.ToString());
                }

                Wait.Set();
            });
            Wait.WaitOne();

            return convert;
        }
        public async Task<String>  ActionsButton(LeadsActionType LeadsActionType ,string leads_id)
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();

            //  var ls = new Lead();

            //  System.Diagnostics.Debug.WriteLine($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/enquiryusers/");

            var client = new RestSharp.RestClient("http://mastereman.com/restful/pages/markasconverted.php");

            var ls = new Notes();

            // var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/notes/");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", credential.UserID.ToString());
            request.AddParameter("leads_id", leads_id.ToString());
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
            //   var content = response.Content;
            List<Notes> convert = null;
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<Notes>(request, response => {
                System.Diagnostics.Debug.WriteLine("notes " + response.Content);
                try
                {
                   /* var json = response.Content.Replace("<", "");
                    JObject jo = JObject.Parse(json);
                    var diskSpaceArray = jo.SelectToken("data", false).ToString();
                    // ls = JsonConvert.DeserializeObject<Lead>(json);
                    convert = JsonConvert.DeserializeObject<List<Notes>>(diskSpaceArray);

                    System.Diagnostics.Debug.WriteLine("convert : " + convert.Count());
*/
                }

                catch (InvalidCastException e)
                {
                    System.Diagnostics.Debug.WriteLine("ERRor : " + e.ToString());
                }

                Wait.Set();
            });
            Wait.WaitOne();
            var returnString="";
            if(LeadsActionType == LeadsActionType.MarkAsConverted){
                returnString = "Succesfully Mark as Converted";
            }
            else if (LeadsActionType == LeadsActionType.SellEnquiry)
            {
                returnString = "Succesfully Mark as SellEnquiry";
            }
            else if (LeadsActionType == LeadsActionType.Unconvertible)
            {
                returnString = "Succesfully Mark as Unconvertible";
            }
            else if (LeadsActionType == LeadsActionType.BookCallBack)
            {
                returnString = "BookCallBack";
            }
            else if (LeadsActionType == LeadsActionType.ChangeCategory)
            {
                returnString = "Category Changed";
            }
            return returnString;
        }
    }
}
