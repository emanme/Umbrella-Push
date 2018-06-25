using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using RestSharp;
using System.Net;
using Umbrella.Constants;

namespace UmbrellaRestClient.Services
{
    public class ServiceRestClient
    {
        protected static RestClient client = new RestClient("https://" + UmbrellaApi.API_HOST + "/");
        protected static RestRequest request;
        public static bool ExecutePostRequest(object item, string resource)
        {
            request = new RestRequest(resource, Method.POST);
            IRestResponse response;
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
            //Json to post            
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            response = client.Execute(request);
            try
            {
                if (response != null && response.StatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ExecutePostRequestError: " + response.Content);
                    return false;
                }
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("ExecutePostRequestError: " + error.Message);
                return false;
            }
        }
        public static IRestResponse ExecuteReturnPostRequest(object item, string resource)
        {
            request = new RestRequest(resource, Method.POST);
            IRestResponse response;
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
            //Json to post           
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            response = client.Execute(request);
            return response;
        }
        public static bool ExecutePutRequest(object item, string resource)
        {
            request = new RestRequest(resource, Method.PUT);
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
            //Json to post
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            try
            {
                IRestResponse response = client.Execute(request);
                if (response != null && response.StatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ExecutePutRequestError: " + response.Content);
                    return false;
                }
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("ExecutePutRequestError: " + error.Message);
                return false;
            }
        }

        public static bool ExecuteDeleteRequest(string resource)
        {
            try
            {
                request = new RestRequest(resource, Method.DELETE);
                request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
                request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
                request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
                IRestResponse response = client.Execute(request);
                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    return true;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ExecuteDeleteRequestError: " + response.Content);
                    return false;
                }
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("ExecuteDeleteRequestError: " + error.Message);
                return false;
            }
        }

        public static IRestResponse ExecuteGetRequest(string resource)
        {
            request = new RestRequest(resource, Method.GET);
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
             IRestResponse response = client.Execute(request);
            return response;
        }

        public static async Task<IRestResponse> ExecuteGetTaskAsync(string resource)
        {
            request = new RestRequest(resource, Method.GET);
            request.AddHeader("umbrella-api-username", UmbrellaApi.USERNAME);
            request.AddHeader("umbrella-api-key", UmbrellaApi.PASSKEY);
            request.AddHeader("umbrella-partner-id", UmbrellaApi.PARTNER_ID);
            IRestResponse response = await client.ExecuteGetTaskAsync(request);
            return response;
        }
    }
}
