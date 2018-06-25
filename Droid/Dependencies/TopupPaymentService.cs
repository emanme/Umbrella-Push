using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Umbrella.Interfaces;
using Stripe;
using System.Threading.Tasks;
using Umbrella.Droid.Dependencies;
using System.Net.Http;
using Xamarin.Auth;
using Xamarin.Forms;
using Umbrella.Constants;
using Newtonsoft.Json;
using Umbrella.Models;
using System.Net;
using RestSharp;

[assembly: Xamarin.Forms.Dependency(typeof(TopupPaymentService))]
namespace Umbrella.Droid.Dependencies
{
    public class TopupPaymentService : ITopupPaymentService
    {
        private readonly string _stripeCustomerApiUri = "https://api.stripe.com/v1/customers";
        private readonly string _stripeSearchQueryUri = "https://api.stripe.com/v1/search?query=";
        private OntraportContactIdRetriever _contactRetriever = new OntraportContactIdRetriever();
        //recommended to be stored in server
        private readonly string _stripeSecretTestkey = StripeClientConstants.ApiKey;
        // sk_test_E01Kh96YOzRtkhD5wItn8CDd portal api

        public async Task<Dictionary<bool,string>> ProcessCustomerCard(Models.Card card, int amount, string email)
        {
            Dictionary<bool, string> result;
            var customerId = await CheckCustomerHasStripeAccnt(email);
            if (!string.IsNullOrEmpty(customerId))
            {
                StripeToken stripeToken = new StripeToken();

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                StripeConfiguration.SetApiKey(StripeClientConstants.ApiKey);

                var tokenOptions = new StripeTokenCreateOptions()
                {
                    Card = new StripeCreditCardOptions()
                    {
                        Number = card.Number,
                        ExpirationYear = card.ExpiryYear,
                        ExpirationMonth = card.ExpiryMonth,
                        Cvc = card.CVC,
                        Name = card.Name
                    }
                };
                var tokenService = new StripeTokenService();
                try
                {
                    stripeToken = tokenService.Create(tokenOptions, new StripeRequestOptions() { ApiKey = Stripe.StripeClient.DefaultPublishableKey });
                    var cardOptions = new StripeCardCreateOptions()
                    {
                        SourceToken = stripeToken.Id,
                    };

                    var cardService = new StripeCardService();
                    StripeCard newCard = cardService.Create(customerId, cardOptions, new StripeRequestOptions() { ApiKey = _stripeSecretTestkey });
                    return result = await ChargeCustomerCard(customerId, amount, newCard.Id);
                }
                catch (StripeException e)
                {
                    return result = new Dictionary<bool, string>()
                    {
                         { false, e.Message }
                    };
                }
              

            }
            else
            {
                StripeToken stripeToken = new StripeToken();

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                StripeConfiguration.SetApiKey(StripeClientConstants.ApiKey);
              
                var tokenOptions = new StripeTokenCreateOptions()
                {
                    Card = new StripeCreditCardOptions()
                    {
                        Number = card.Number,
                        ExpirationYear = card.ExpiryYear,
                        ExpirationMonth = card.ExpiryMonth,
                        Cvc = card.CVC,
                        Name = card.Name
                    }
                };
                var tokenService = new StripeTokenService();
                try
                {
                    stripeToken = tokenService.Create(tokenOptions, new StripeRequestOptions() { ApiKey = Stripe.StripeClient.DefaultPublishableKey });
                }
                catch (StripeException e)
                {
                    return result = new Dictionary<bool, string>()
                    {
                         { false, e.Message }
                    };
                }
                try
                {
                    var customerOptions = new StripeCustomerCreateOptions()
                    {
                        Email = email,
                        SourceToken = stripeToken.Id,
                    };

                    var customerService = new StripeCustomerService();
                    StripeCustomer customer = customerService.Create(customerOptions, new StripeRequestOptions() { ApiKey = _stripeSecretTestkey });
                    return result = await ChargeCustomerCard(customer.Id, amount, stripeToken.StripeCard.Id);
                    
                } 
                catch (StripeException e)
                {
                    return result = new Dictionary<bool, string>()
                        {
                            { false, e.Message }
                        };
                }

            }
            return result = new Dictionary<bool, string>();
        }
        public async Task<List<RetrievedCard>> GetAllCurrentCards(string email)
        {
            var list = new List<RetrievedCard>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {StripeClientConstants.ApiKey}");
                var response = await client.GetStringAsync(_stripeSearchQueryUri + email + "&prefix=false");
                var data = JsonConvert.DeserializeObject<RootStripeApiJsonData>(response);
                var customerId = data.data.Count == 0 ? string.Empty : data.data[0].id;

                StripeConfiguration.SetApiKey(StripeClientConstants.ApiKey);

                var cardService = new StripeCardService();

                StripeList<StripeCard> cardlist = cardService.List(customerId,
                  new StripeListOptions() { Limit = 5 },
                  false,
                  new StripeRequestOptions() { ApiKey = _stripeSecretTestkey }
                );
                if (cardlist.Any())
                {
                    foreach (var item in cardlist)
                    {
                        list.Add(new RetrievedCard()
                        {
                            Name = item.Name,
                            Last4 = item.Last4,
                            Id = item.Id
                        });
                    }
                }
                else
                {
                    return list;
                }

                return list;
            }
        }
        public async Task<Dictionary<bool,string>> ProcessExistingCard(int amount,string email, RetrievedCard card)
        {
            Dictionary<bool, string> result;
            var customerId = await CheckCustomerHasStripeAccnt(email);
            return result = await ChargeCustomerCard(customerId, amount, card.Id);
        }
        private async Task<Dictionary<bool,string>> ChargeCustomerCard(string customer_Id, int amount, string tokenId)
        {
            Dictionary<bool, string> result;
            StripeConfiguration.SetApiKey(StripeClientConstants.ApiKey);
            var charges = new StripeChargeService();
            try
            {
                var charge = charges.Create(new StripeChargeCreateOptions
                {
                    Amount = amount,
                    Currency = "gbp",
                    Description = "Top up charge",
                    CustomerId = customer_Id,
                    SourceTokenOrExistingSourceId = tokenId,
                }, new StripeRequestOptions() { ApiKey = _stripeSecretTestkey });
                if (charge != null)
                {
                    await SendPurchaseOntraport(amount, customer_Id);
                    return result = new Dictionary<bool, string>()
                    {
                        { true, "Topup Success" }
                    };
                }
                else
                {
                    await SendTagFailedPaymentOntraport();
                    return result = new Dictionary<bool, string>()
                    {
                        { false, "Charge Failed" }
                    };
                }
            }
            catch(StripeException e)
            {
                await SendTagFailedPaymentOntraport();
                return result = new Dictionary<bool, string>()
                {
                    { false, e.Message }
                };
            }
        }
        private async Task SendPurchaseOntraport(int amount,string customerId)
        {
            var service = new CredentialRetriever();
            var email = service.GetCredential().User.Email;
            var contactId = await _contactRetriever.GetOntraportContactId(email);
            using (HttpClient client = new HttpClient())
            {
                var newAmount = amount / 100;
                string xmlData = "<purchases contact_id='"+contactId+"' product_id ='"+GetProductId(amount)+"'><field name='Price'>"+ newAmount + "</field></purchases>";

                var requestContent = string.Format("appid={0}&key={1}&return_id={2}&reqType={3}&data={4}",
                        Uri.EscapeDataString(OntraportApi.API_APP_ID),
                        Uri.EscapeDataString(OntraportApi.API_KEY),
                        Uri.EscapeDataString(OntraportApi.RETURN_ID.ToString()),
                        Uri.EscapeDataString(OntraportApi.REQUEST_SALE),
                        Uri.EscapeDataString(xmlData));

                var response = await client.PostAsync(OntraportApi.ONTRAPORT_API_LINK, new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded"));
            }
        }
        private async Task SendTagFailedPaymentOntraport()
        {
            var service = new CredentialRetriever();
            var email = service.GetCredential().User.Email;
            var contactId = await _contactRetriever.GetOntraportContactId(email);
            using (HttpClient client = new HttpClient())
            {
                string xmlData = "<contact id='"+ contactId + "'><tag>Umbrella App - Payment Declined</tag></contact>";

                var requestContent = string.Format("appid={0}&key={1}&return_id={2}&reqType={3}&data={4}",
                        Uri.EscapeDataString(OntraportApi.API_APP_ID),
                        Uri.EscapeDataString(OntraportApi.API_KEY),
                        Uri.EscapeDataString(OntraportApi.RETURN_ID.ToString()),
                        Uri.EscapeDataString("add_tag"),
                        Uri.EscapeDataString(xmlData));

                var response = await client.PostAsync(OntraportApi.ONTRAPORT_API_LINK_CONTACTS2, new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded"));
            }
        }
        private async Task<string> CheckCustomerHasStripeAccnt(string email)
        {
            var customerId = "";
            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {StripeClientConstants.ApiKey}");
                var response = await client.GetStringAsync(_stripeSearchQueryUri + email + "&prefix=false");
                var data = JsonConvert.DeserializeObject<RootStripeApiJsonData>(response);
                return customerId = data.data.Count == 0 ? string.Empty : data.data[0].id;
            }
        }
        private string GetProductId(int amount)
        {
            switch (amount)
            {
                case 2500:
                    return "15";
                case 5000:
                    return "16";
                case 7500:
                    return "17";
                case 10000:
                    return "18";
                case 15000:
                    return "20";
                case 25000:
                    return "22";
                default:
                    return "";
            }
        }

    }
}