using System.Linq;
using Umbrella.Droid.Dependencies;
using Umbrella.Interfaces;
using Umbrella.Models;
using Xamarin.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppiontmentRetriever))]
namespace Umbrella.Droid.Dependencies
{
  
    public class AppiontmentRetriever : IAppointmentNewRetriever
    {
        public AppiontmentRetriever() { }
        public string AppoitmentTime
        {
            get
            {
                var app = AccountStore.Create(Forms.Context).FindAccountsForService("NewAppiontment").FirstOrDefault();
                return (app != null) ? app.Properties["AppoitmentTime"] : null;                
            }
        }

        public string AppoitmentDate
        {
            get
            {
                var app = AccountStore.Create(Forms.Context).FindAccountsForService("NewAppiontment").FirstOrDefault();
                return (app != null) ? app.Properties["AppoitmentDate"] : null;                
            }
        }     

        public AppointmentStoreNew GetNewAppointment()
        {
            var app = new AppointmentStoreNew();
            app = new AppointmentStoreNew()
            {
                AppoitmentDate = AppoitmentDate,
                AppoitmentTime = AppoitmentTime
            };                
            return app;          
        }
    }
}
