using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Constants;
using Umbrella.Interfaces;
using Umbrella.iOS.Dependencies;
using Umbrella.Models;


[assembly: Xamarin.Forms.Dependency(typeof(OntraportContactIdRetriever))]
namespace Umbrella.iOS.Dependencies
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
