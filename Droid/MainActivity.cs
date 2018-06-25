using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Plugin.Badge;
using Plugin.FirebasePushNotification;
using SegmentedControl.FormsPlugin.Android;
using Stripe;
using System;
using System.Linq;
using Umbrella.Constants;
using Umbrella.Droid.Services;
using Umbrella.Models;
using Umbrella.Utilities;
using Xamarin.Auth;
using Xamarin.Forms;

namespace Umbrella.Droid
{
    [Activity(
        Label = "@string/appName",
        Icon = "@drawable/UmbrellaArmyFavicon",
        Theme = "@style/Theme.Main",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize
        | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Com.Mapbox.Mapboxsdk.Mapbox.GetInstance(this, MapboxSetting.AccessToken);

            Forms.Init(this, bundle);
            CachedImageRenderer.Init(null);
            SegmentedControlRenderer.Init();
            
            //INITIALIZE BEFORE LOAD APPLICATION
            InitializeStripeClient();

            LoadApplication(new App());

            //INITIALIZE AFTER LOAD APPLICATION
            InitilizeFireBase();
            InitializeMessagingSubscription();
        }

        private static void InitializeStripeClient()
        {
            //StripeConfiguration.HttpMessageHandler = new HttpClientHandler();
            StripeClient.DefaultPublishableKey = StripeClientConstants.DefaultPublishableKey;
        }

        private void InitializeMessagingSubscription()
        {
            MessagingCenter.Subscribe<StartLongRunningTaskMessage>(this, "StartLongRunningTaskMessage", message => {
                var intent = new Intent(this, typeof(LongRunningTaskService));
                StartService(intent);
            });
            MessagingCenter.Subscribe<StartCustomerMessage>(this, "StartCustomerMessage", message => {
                var intent = new Intent(this, typeof(CustomerBackgroundRunningService));
                StartService(intent);
            });
            MessagingCenter.Subscribe<Credential>(this, "SaveUserData", SaveUserData);
            MessagingCenter.Subscribe<string>(this, "RemoveUserData", RemoveUserData);
            MessagingCenter.Subscribe<AppointmentStoreNew>(this, "NewAppiontment", SaveNewAppiontment);
            MessagingCenter.Subscribe<string>(this, "NewAppiontment", RemoveNewAppiontmentData);
            MessagingCenter.Subscribe<Models.Card>(this, "SaveCard", SaveCard);
        }

        private void InitilizeFireBase()
        {
            FirebasePushNotificationManager.ProcessIntent(Intent);

            if (Intent != null && Intent.Extras != null)
            {
                int topic = Intent.Extras.GetInt("topicId");
                var notifList = Global.GetAllTopic();
                var currentTopic = notifList.Any(e => e.Key == topic) ? notifList.Where(e => e.Key == topic).Select(p => p.Value).FirstOrDefault() : string.Empty;
                Global.SetNotifTopic(currentTopic);
                App.IsNotified = true;
            }
        }

        private void SaveNewAppiontment(AppointmentStoreNew app)
        {
            Account account = new Account();
            account.Properties.Add("AppoitmentTime", app.AppoitmentTime);
            account.Properties.Add("AppoitmentDate", app.AppoitmentDate);
            AccountStore.Create(Forms.Context).Save(account, "NewAppiontment");
        }

        private void RemoveNewAppiontmentData(string message)
        {
            var account = AccountStore.Create(Forms.Context).FindAccountsForService("NewAppiontment").FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create(Forms.Context).Delete(account, "NewAppiontment");
            }
            System.Diagnostics.Debug.WriteLine(message);
        }

        private void SaveUserData(Credential credential)
        {
            Account account = new Account
            {
                Username = credential.User.Username
            };
            account.Properties.Add("Password", credential.Password);
            account.Properties.Add("Email", credential.User.Email);
            account.Properties.Add("UserID", credential.User.Id.ToString());
            AccountStore.Create(Forms.Context).Save(account, App.AppName);
        }

        private void RemoveUserData(string message)
        {
            var account = AccountStore.Create(Forms.Context).FindAccountsForService(App.AppName).FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create(Forms.Context).Delete(account, App.AppName);
            }
            System.Diagnostics.Debug.WriteLine(message);
        }

        private async void SaveCard(Models.Card card)
        {
            var stripeCard = new Stripe.Card
            {
                Name = card.Name,
                Number = card.Number,
                ExpiryMonth = card.ExpiryMonth,
                ExpiryYear = card.ExpiryYear,
                CVC = card.CVC
            };
            try
            {
                await StripeClient.CreateToken(stripeCard, StripeClient.DefaultPublishableKey);
                StripeConfiguration.SetApiKey(StripeClientConstants.ApiKey); //"sk_test_BQokikJOvBiI2HlWgH4olfQ2");
            }
            catch (Exception ex)
            {
                // Handle a failure
                Console.WriteLine(ex);
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            FirebasePushNotificationManager.ProcessIntent(intent);
        }
    }
}
