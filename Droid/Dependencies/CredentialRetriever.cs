using System.Linq;
using Umbrella.Droid.Dependencies;
using Umbrella.Interfaces;
using Umbrella.Models;
using Xamarin.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(CredentialRetriever))]
namespace Umbrella.Droid.Dependencies
{
    public class CredentialRetriever : ICredentialRetriever
    {
        public string UserName
        {
            get
            {
                var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Username : null;
            }
        }

        public string Password
        {
            get
            {
                var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Properties["Password"] : null;
            }
        }
        public string UserID
        {
            get
            {
                var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Properties["UserID"] : null;
            }
        }
        public string Email
        {
            get
            {
                var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Properties["Email"] : null;
            }
        }

        public Credential GetCredential()
        {
            if (Password != null)
            {
                var credential = new Credential();
                credential.User = new User()
                {
                    Username = UserName,
                    Email = Email
                };
                credential.Password = Password;
                credential.UserID = UserID;
                return credential;
            }
            else
            {
                return null;
            }
        }
    }
}
