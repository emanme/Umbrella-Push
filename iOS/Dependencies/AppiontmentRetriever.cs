using System.Linq;
using Umbrella.Interfaces;
using Umbrella.iOS.Dependencies;
using Umbrella.Models;
using Xamarin.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppiontmentRetriever))]
namespace Umbrella.iOS.Dependencies
{
    public class AppiontmentRetriever : IAppointmentNewRetriever
    {
        public string AppoitmentTime
        {
            get
            {
                var app = AccountStore.Create().FindAccountsForService("NewAppiontment").FirstOrDefault();
                return (app != null) ? app.Properties["AppoitmentTime"] : null;
            }
        }

        public string AppoitmentDate
        {
            get
            {
                var app = AccountStore.Create().FindAccountsForService("NewAppiontment").FirstOrDefault();
                return (app != null) ? app.Properties["AppoitmentDate"] : null;
            }
        }     

        public AppointmentStoreNew GetNewAppointment()
        {
            if (AppoitmentTime != null)
            {
                var app = new AppointmentStoreNew();
                app = new AppointmentStoreNew()
                {
                    AppoitmentDate = AppoitmentDate,
                    AppoitmentTime = AppoitmentTime
                };                
                return app;
            }
            else
            {
                return null;
            }
        }
    }
}
