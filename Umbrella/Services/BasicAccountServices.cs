using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Constants;
using Umbrella.Interfaces;
using Umbrella.Models;
using Xamarin.Forms;

namespace Umbrella.Services
{
    public class BasicAccountServices
    {
        public async Task<bool> CreateUserOntraport(string email)
        {
            using (HttpClient client = new HttpClient())
            {
                string xmlData = "<contact><Group_Tag name='Contact Information'><field name='Email'>" + email + "</field></Group_Tag></contact>";
                var requestContent = string.Format("appid={0}&key={1}&return_id={2}&reqType={3}&data={4}",
                       Uri.EscapeDataString(OntraportApi.API_APP_ID),
                       Uri.EscapeDataString(OntraportApi.API_KEY),
                       Uri.EscapeDataString(OntraportApi.RETURN_ID.ToString()),
                       Uri.EscapeDataString("add"),
                       Uri.EscapeDataString(xmlData));
                var res = await client.PostAsync(OntraportApi.ONTRAPORT_API_LINK_CONTACTS2, new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded"));

                return res.IsSuccessStatusCode;
            }

        }
        public async Task<bool> ForgetPasswordService(string contactId)
        {
            using (HttpClient client = new HttpClient())
            {
                string xmlData = "<contact id='" + contactId + "'><tag>Umbrella App - Forgotten Password</tag></contact>";

                var requestContent = string.Format("appid={0}&key={1}&return_id={2}&reqType={3}&data={4}",
                        Uri.EscapeDataString(OntraportApi.API_APP_ID),
                        Uri.EscapeDataString(OntraportApi.API_KEY),
                        Uri.EscapeDataString(OntraportApi.RETURN_ID.ToString()),
                        Uri.EscapeDataString("add_tag"),
                        Uri.EscapeDataString(xmlData));

                var response = await client.PostAsync(OntraportApi.ONTRAPORT_API_LINK_CONTACTS2, new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded"));
                return response.IsSuccessStatusCode;
            }
        }
        public async Task<bool> SyncEnquiryTypeOntraport(int enquiryType,string contactEnquiry,string email)
        {
            using (HttpClient client = new HttpClient())
            {
                var requestContent = string.Format("email={0}&f1653={1}&f1572={2}",
                         Uri.EscapeDataString(email),
                         Uri.EscapeDataString(enquiryType.ToString()),
                         Uri.EscapeDataString(contactEnquiry));
                client.DefaultRequestHeaders.Add("Api-Appid", OntraportApi.API_APP_ID);
                client.DefaultRequestHeaders.Add("Api-Key", OntraportApi.API_KEY);
                var res = await client.PostAsync(OntraportApi.ONTRAPORT_API_LINK_CONTACTSMERGE, new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded"));
                if (res.IsSuccessStatusCode)
                {
                    SendEnquiryTag();
                    return res.IsSuccessStatusCode;
                }
                return res.IsSuccessStatusCode;
            }

        }
        private async void SendEnquiryTag()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var contact_id = await DependencyService.Get<IOntraportContactIdRetriever>().GetOntraportContactId(credential.User.Email);
            using (HttpClient client = new HttpClient())
            {
                string xmlData = "<contact id='" + contact_id + "'><tag>Umbrella App - Contact Form</tag></contact>";

                var requestContent = string.Format("appid={0}&key={1}&return_id={2}&reqType={3}&data={4}",
                        Uri.EscapeDataString(OntraportApi.API_APP_ID),
                        Uri.EscapeDataString(OntraportApi.API_KEY),
                        Uri.EscapeDataString(OntraportApi.RETURN_ID.ToString()),
                        Uri.EscapeDataString("add_tag"),
                        Uri.EscapeDataString(xmlData));

                var response = await client.PostAsync(OntraportApi.ONTRAPORT_API_LINK_CONTACTS2, new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded"));

            }
        }
    }
}
