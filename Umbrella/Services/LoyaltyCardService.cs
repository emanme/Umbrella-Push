using System;
using System.Collections.Generic;
using Umbrella.Models;
using UmbrellaRestClient.Services;
using Umbrella.Constants;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Umbrella.Interfaces;
using RestSharp;
namespace Umbrella.Services
{
    public class LoyaltyCardPointService
    {
      
        public static IRestResponse GetLoyaltyPoints()
        {
            IRestResponse response = null;
            try
            {
                var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
                response = ServiceRestClient.ExecuteGetRequest("loyaltycard/?partner_id=" + UmbrellaApi.PARTNER_ID);               
                if (response.Content != null)
                {
                    return (response);
                }
            }
            catch(Exception e)
            {}          
            return response;
        }
        public class LoyalPoint
        {
            public int points { get; set; }
            public string barcode { get; set; }
            public byte[] barcodedata { get; set; }
        }
    }
}
