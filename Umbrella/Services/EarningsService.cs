using System;
using System.Collections.Generic;
using Umbrella.Models;
using UmbrellaRestClient.Services;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Umbrella.Interfaces;
using Umbrella.Constants;
namespace Umbrella.Services
{
    public class EarningsService
    {
        public List<Earning> GetEarnings()
        {
            var list = new List<Earning>();
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
           /* var rest = ServiceRestClient.ExecuteGetRequest("previousreferrals/?partner_id="+ UmbrellaApi.PARTNER_ID);
            var obj = JObject.Parse(rest.Content);
            foreach(var i in obj)
            {
                var t = i;
            }*/
            list.Add(new Earning
            {
                Name = "Richard Howard",
                Business = "Premier Mobile Phones Ltd",
                Value = 15.20m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = "Earned!",
                Created = DateTime.Now
            });

            list.Add(new Earning
            {
                Name = "Richard Howard",
                Business = "Premier Mobile Phones Ltd",
                Value = 20.20m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = "Earned!",
                Created = DateTime.Now
            });

            list.Add(new Earning
            {
                Name = "Richard Howard",
                Business = "Premier Mobile Phones Ltd",
                Value = 56.00m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = "Earned!",
                Created = DateTime.Now
            });

            list.Add(new Earning
            {
                Name = "Richard Howard",
                Business = "Premier Mobile Phones Ltd",
                Value = 15.20m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = "Earned!",
                Created = DateTime.Now
            });

            list.Add(new Earning
            {
                Name = "Richard Howard",
                Business = "Premier Mobile Phones Ltd",
                Value = 15.20m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = "Earned!",
                Created = DateTime.Now
            });

            list.Add(new Earning
            {
                Name = "Richard Howard",
                Business = "Premier Mobile Phones Ltd",
                Value = 15.20m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = "Earned!",
                Created = DateTime.Now
            });

            list.Add(new Earning
            {
                Name = "Richard Howard",
                Business = "Premier Mobile Phones Ltd",
                Value = 15.20m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = "Earned!",
                Created = DateTime.Now
            });

            list.Add(new Earning
            {
                Name = "Richard Howard",
                Business = "Premier Mobile Phones Ltd",
                Value = 15.20m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = "Earned!",
                Created = DateTime.Now
            });

            list.Add(new Earning
            {
                Name = "Richard Howard",
                Business = "Premier Mobile Phones Ltd",
                Value = 15.20m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = "Earned!",
                Created = DateTime.Now
            });

            list.Add(new Earning
            {
                Name = "Richard Howard",
                Business = "Premier Mobile Phones Ltd",
                Value = 15.20m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Status = "Earned!",
                Created = DateTime.Now
            });

            return list;
        }

        public static string GetTotalEarnings()
        {
            try
            {
                var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
                var rest = ServiceRestClient.ExecuteGetRequest("earnings/?email=" + credential.User.Email);
                var obj = JObject.Parse(rest.Content);
                var result = (string)obj["acount_balance"];
                if (result != null)
                {
                    return (result);
                }
            }
            catch(Exception e)
            {}          
            return "0";
        }
    }
}
