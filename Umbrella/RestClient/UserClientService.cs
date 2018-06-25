using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Umbrella.Constants;
using Umbrella.Enums;
using Umbrella.Models;
using RestSharp;
using System.Threading;

namespace Umbrella.RestClient
{
    public class UserClientService : ApiClient
    {
        protected override string Controller { get { return "user"; } }

        public UserClientService()
        {
        }

        public async Task<User> Authenticate(string username, string password, AuthenticationType authType)
        {
            string action = "generate_auth_cookie";
            string type = (authType == AuthenticationType.Username) ? "username" : "email";
            string url = $"{UmbrellaApi.SCHEME}://{UmbrellaApi.WP_HOST}/{UmbrellaApi.ROOT}" +
                $"/{Controller}/{action}/?{type}={username}&password={password}";

            var httpClient = new HttpClient();             
            var json = await httpClient.GetStringAsync(url).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<AuthenticationCookie>(json);

            if (result.Status.Equals("ok"))
            {
                if (result.CookieName.StartsWith("wordpress_logged_in_", StringComparison.CurrentCultureIgnoreCase))
                {
                    return result.User;
                }
            }
            else if (result.Status.Equals("error"))
            {
                Debug.WriteLine($"Error: {result.Error}");
            }

            return null;
        }
        public async  Task<User> AuthenticateToAPI(string username, string password, AuthenticationType authType)
        { 
            var ls = new LoginJson();
            ls.status = "empty";
            var Error = AuthenticationStatus.ServerError;
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/validateaccount/");
            //   var client = new RestSharp.RestClient("http://mastereman.com/restful/");
            var request = new RestRequest(Method.POST);

            request.AddParameter("email", username);
            request.AddParameter("password", password);
            request.AddParameter("Type", "army");
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);


            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            // var response = client.Execute(request, cts.Token);

            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<LoginJson>(request, response => {
                System.Diagnostics.Debug.WriteLine(response.Content);
                try
                {
                    System.Diagnostics.Debug.WriteLine("ResponseStatus " + response.ResponseStatus);

                    /* if(response.Content.Contains("<div>")){
                        System.Diagnostics.Debug.WriteLine("Pre ");
                        System.Diagnostics.Debug.WriteLine("Failed : ");
                        ls.status = "false";
                    }else{ */
                    try
                    {
                        var json = response.Content.Replace("<", "");
                        ls = JsonConvert.DeserializeObject<LoginJson>(json);
                        
                    }
                    catch (FormatException fex)
                    {
                        //Invalid json format
                        System.Diagnostics.Debug.WriteLine(fex);
                        System.Diagnostics.Debug.WriteLine("FormatException : ");
                        ls.status = "ServerError";
                    }
                    catch (Exception ex) //some other exception
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                        System.Diagnostics.Debug.WriteLine("Exception : " + ex.Message);
                        ls.status = "ServerError";
                    }
                    // }





                    Wait.Set();

                }
                catch (InvalidCastException e)
                {
                    System.Diagnostics.Debug.WriteLine("ERRor : " + e.ToString());
                }

                //  status = ls.Status;
                //  email = ls.Email;
                System.Diagnostics.Debug.WriteLine("ls.status " + ls.status.ToString());
                //  StopBusyIndicator();

            });
            Wait.WaitOne();
            System.Diagnostics.Debug.WriteLine("Finish asyncHandle");
            if (ls == null || ls.status == "ServerError")
            {
                System.Diagnostics.Debug.WriteLine("ServerError");
                User u = new User();
                //u.Username = username;
                //u.Email = username;
                u.AuthenticationStatus = AuthenticationStatus.ServerError;
                return u;
            }
            else if (ls != null && ls.status == "false")
            {
                System.Diagnostics.Debug.WriteLine("NULL if Stat" + ls.status);

                User u = new User();
                //u.Username = username;
                //u.Email = username;
                u.AuthenticationStatus = AuthenticationStatus.AuthenticationFailed;
                return u;
                // return null;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("else Stat" + ls.status);

                User u = new User();
                u.Username = username;
                u.Email = username;

                //  = int.TryParse(ls.partner_id);
                u.AuthenticationStatus = AuthenticationStatus.AuthenticationSuccess;

                if (Int32.TryParse(ls.partner_id, out int j))
                {
                    // Console.WriteLine(j);
                    u.Id = j;
                }
                u.FirstName = "";
                u.LastName = "";
                u.Nickname = "";
                u.DisplayName = "";
                u.Description = "";
                //u.Registered = "";
                System.Diagnostics.Debug.WriteLine("u.Id" + u.Id);
                System.Diagnostics.Debug.WriteLine("u.Email" + u.Email);
                System.Diagnostics.Debug.WriteLine("Returned" + ls.status);
                return u;

            }

        
        }
        public async Task<LoginJson> GetLoyatyData(string partner_id)
        {

            var ls = new LoginJson();
            var client = new RestSharp.RestClient($"{UmbrellaApi.SCHEME}://{UmbrellaApi.API_HOST_URL}/loyalt_ycard/");
          //  var client = new RestSharp.RestClient("http://mastereman.com/firebase/qr.php");
            var request = new RestRequest(Method.POST);
            request.AddParameter("partner_id", partner_id);
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);


           
            EventWaitHandle Wait = new AutoResetEvent(false);

            var asyncHandle = client.ExecuteAsync<LoginJson>(request, response => {
                System.Diagnostics.Debug.WriteLine(response.Content);
                try
                {
                    var json = response.Content.Replace("<", "");
                    ls = JsonConvert.DeserializeObject<LoginJson>(json);
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

                return null;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("else Stat" + ls.points);

               
                //u.Registered = "";
                System.Diagnostics.Debug.WriteLine("u.Id " + ls.barcode);
               
                return ls;

            }


        }
    }
}
