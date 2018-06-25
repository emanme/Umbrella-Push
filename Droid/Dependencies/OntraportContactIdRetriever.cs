using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Umbrella.Interfaces;
using Umbrella.Droid.Dependencies;
using System.Net.Http;
using Newtonsoft.Json;
using Umbrella.Constants;
using Umbrella.Models;

[assembly: Xamarin.Forms.Dependency(typeof(OntraportContactIdRetriever))]
namespace Umbrella.Droid.Dependencies
{
    public class OntraportContactIdRetriever : IOntraportContactIdRetriever
    {
        public async Task<string> GetOntraportContactId(string email)
        {
            var contactId = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Api-Appid", OntraportApi.API_APP_ID);
                client.DefaultRequestHeaders.Add("Api-Key", OntraportApi.API_KEY);
                var response = await client.GetStringAsync(OntraportApi.ONTRAPORT_API_LINK_CONTACTS + "?" + OntraportApi.REQUEST_SEARCH + "=" + email);
                var data = JsonConvert.DeserializeObject<RootListJsonModel>(response);
                contactId = data.data.Count == 0 ? string.Empty : data.data[0].id;
            }
            return contactId;
        }
    }
}