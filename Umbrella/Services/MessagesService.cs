using System;
using System.Collections.Generic;
using Umbrella.Enums;
using Umbrella.Models;
using Xamarin.Forms;
using UmbrellaRestClient.Services;
using Umbrella.Interfaces;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Umbrella.Constants;
using RestSharp;

namespace Umbrella.Services
{
    public class MessagesService
    {
        public List<Message> GetTempoTop(){
            return new List<Message>()
            {
                new Message(){
                    Subject= "Test Top Secret",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Sed volutpat, ipsum eget dapibus maximus, ipsum nibh tempor ipsum, ac hendrerit metus urna ut orci. ",
                    Image = "guy_gray",
                    HasAttachment = false,
                    Received = DateTime.Now

                }
            };
        }
        public List<Message> GetMessages()
        {
            var list = new List<Message>();
            try
            {
                var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
                var rest = ServiceRestClient.ExecuteGetRequest("messages/?email=" + credential.User.Email);
                var obj = JObject.Parse(rest.Content);
                dynamic msg = Newtonsoft.Json.JsonConvert.DeserializeObject(obj.ToString());
                var stud = msg.replies;
                var Subject = (string)obj["subject"];
                string Sender = "", Email = "";
                foreach (var rep in stud)
                {
                    string str = rep.from_email;
                    if (str != null)
                    {
                        string tr = str.Trim().Replace("<", ",").Replace(">", "").Replace("\"", "");
                        string[] separators = { "," };
                        string[] words = tr.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        Sender = words[0];
                        Email = words[1];
                    }
                    list.Add(new Message
                    {                      

                        Image = ImageSource.FromUri(new Uri("http://www.mens-hairstyle.com/wp-content/uploads/2016/06/Good-Men-Haircuts.jpg")),
                        Sender = Sender,
                        Email = Email,
                        Subject = msg.subject,
                        Body = rep["body_text"],
                        Type = MessageType.UmbrellaMessages,
                        IsUnread = true,
                        HasAttachment = false,
                        Received = DateTime.Now
                    });
                    
                }
            }
            catch (Exception e)
            {

            }       
            return list;
        }
        public List<Message> GetAllMessages()
        {
            var list = new List<Message>();
            try
            {
                var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
                var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/messages");
                var request = new RestRequest(Method.POST);
                request.AddParameter("email", credential.User.Email);
                request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
                request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
                request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
                //   var content = response.Content;
                // List<Lead> convert = null;
                EventWaitHandle Wait = new AutoResetEvent(false);
                List<Message> listMsg = new List<Message>();
                var asyncHandle = client.ExecuteAsync<Message>(request, response => {
                    System.Diagnostics.Debug.WriteLine("Message Data" + response.Content);
                    try
                    {
                        var json = response.Content.Replace("<div>", "");
                        json = json.Replace("<\\/div>", "");
                        //json = json.Replace("[", string.Empty).Replace("]", string.Empty);
                        //json = "[" + json + "]";
                        System.Diagnostics.Debug.WriteLine("json " + json);
                        JArray obj = JArray.Parse(json);
                        System.Diagnostics.Debug.WriteLine("obj " + obj);
                        var msglist = obj.ToObject<List<MessageList>>();
                        foreach (var item in msglist)
                        {

                            list.Add(new Message()
                            {
                                Subject = item.subject,
                                Body = item.description,
                                Image = "guy_gray"
                            });
                        }
                      
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("Messages Error : " + e.ToString());
                    }

                    Wait.Set();
                });
                Wait.WaitOne();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("execiption" + e.Message + " " + e.InnerException);
            }

            return list;
        }
        
    }
}
