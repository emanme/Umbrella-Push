using System;
using System.Linq;
using Foundation;
using Plugin.FirebasePushNotification;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfCalendar.XForms.iOS;
using UIKit;
using Umbrella.Models;
using Xamarin.Auth;
using Xamarin.Forms;
using Stripe;
using ModernHttpClient;
using SegmentedControl.FormsPlugin.iOS;
using UserNotifications;    
using Umbrella.iOS.Services;
using Umbrella.Constants;
using Mapbox;
using Naxam.Controls.Mapbox.Platform.iOS;
using FFImageLoading.Forms.Touch;
using Plugin.FirebasePushNotification.Abstractions;
using System.Collections.Generic;
using Firebase.CloudMessaging;
using Com.OneSignal;
namespace Umbrella.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        IOSLongRunningTask longRunningTaskExample;
        MessageTimerService messageTimer;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            InitializeUIAndRenderer();
            InitializeStripeClient();

            global::Xamarin.Forms.Forms.Init();
            SegmentedControlRenderer.Init();
            CachedImageRenderer.Init();
            Xamarin.FormsMaps.Init();
            LoadApplication(new App());
            //dEGMnMzTDJc:APA91bGJcxkCwfgLxOhtnqefs6IMtyIWmecx90aR1fKqi8QOIk50UX2Fouv23qWZBDUx2efoHqdiCsqFsrru1x4KO
            WireUpLongRunningTask();
           /////ee InitilizeFireBase(options);
            /////ee InitializeMessagingSubscription();
            OneSignal.Current.StartInit("4189cc79-00f4-4182-8baf-31b1f012b906")
               .EndInit();

            return base.FinishedLaunching(app, options);
           
        }

        private static void InitilizeFireBase(NSDictionary options)
        {
            FirebasePushNotificationManager.Initialize(options, new NotificationUserCategory[]
            {
                new NotificationUserCategory("message",new List<NotificationUserAction> {
                    new NotificationUserAction("Reply","Reply",NotificationActionType.Foreground)
                }),
                new NotificationUserCategory("request",new List<NotificationUserAction> {
                    new NotificationUserAction("Accept","Accept"),
                    new NotificationUserAction("Reject","Reject",NotificationActionType.Destructive)
                })
           });
        }

        private void InitializeMessagingSubscription()
        {
            MessagingCenter.Subscribe<Credential>(this, "SaveUserData", SaveUserData, null);
            MessagingCenter.Subscribe<string>(this, "RemoveUserData", RemoveUserData, null);
            MessagingCenter.Subscribe<AppointmentStoreNew>(this, "NewAppiontment", SaveNewAppiontment, null);
            MessagingCenter.Subscribe<string>(this, "NewAppiontment", RemoveNewAppiontmentData, null);
            MessagingCenter.Subscribe<Models.Card>(this, "SaveCard", SaveCard, null);
        }

        private static void InitializeStripeClient()
        {
            StripeConfiguration.HttpMessageHandler = new NativeMessageHandler();
            Stripe.StripeClient.DefaultPublishableKey = StripeClientConstants.DefaultPublishableKey;
        }

        private static void InitializeUIAndRenderer()
        {
            UIColor colorPrimary = UIColor.Clear.FromHex(0x435742);

            UINavigationBar.Appearance.TintColor = colorPrimary;
            UITabBar.Appearance.TintColor = colorPrimary;

            UINavigationBar.Appearance.BarTintColor = UIColor.White;
            UITabBar.Appearance.BarTintColor = UIColor.White;

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = colorPrimary
            });

            new SfBusyIndicatorRenderer();
            new SfCalendarRenderer();

            MGLAccountManager.AccessToken = MapboxSetting.AccessToken;
            new MapViewRenderer();
        }
        void WireUpLongRunningTask()
        {
            MessagingCenter.Subscribe<StartLongRunningTaskMessage>(this, "StartLongRunningTaskMessage", message => {
                longRunningTaskExample = new IOSLongRunningTask();
                longRunningTaskExample.Start();
            });
            MessagingCenter.Subscribe<StartCustomerMessage>(this, "StartCustomerMessage", async message => {
                messageTimer = new MessageTimerService();
                await messageTimer.Start();
            });

            MessagingCenter.Subscribe<StopCustomerMessage>(this, "StopCustomerMessage", message => {
                messageTimer.Stop();
            });
        }
        public override void DidEnterBackground(UIApplication application)
        {
            FirebasePushNotificationManager.Disconnect();
        }
        private void SaveNewAppiontment(AppointmentStoreNew app)
        {
            Account account = new Account();            
            account.Properties.Add("AppoitmentTime", app.AppoitmentTime);
            account.Properties.Add("AppoitmentDate", app.AppoitmentDate);
            AccountStore.Create().Save(account, "NewAppiontment");
        }
      
       
        private void SaveUserData(Credential credential)
        {
            Account account = new Account
            {
                Username = credential.User.Username
            };
            account.Properties.Add("Password", credential.Password);
            account.Properties.Add("Email", credential.User.Email);
            account.Properties.Add("UserID", credential.UserID);
            
            System.Diagnostics.Debug.WriteLine(" SaveUserData credential333 " +credential. UserID);
            //account.Properties.g
            AccountStore.Create().Save(account, App.AppName);
        }

        private void RemoveUserData(string message)
        {
            var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create().Delete(account, App.AppName);
            }
            System.Diagnostics.Debug.WriteLine(message);
        }
        private void RemoveNewAppiontmentData(string message)
        {
            var account = AccountStore.Create().FindAccountsForService("NewAppiontment").FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create().Delete(account, App.AppName);
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
                var token = await Stripe.StripeClient.CreateToken(stripeCard);

                // Slightly different for non-Apple Pay use, see 
                // 'Sending the token to your server' for more info
                //await CreateBackendCharge(token);
            }
            catch (Exception ex)
            {
                // Handle a failure
                Console.WriteLine(ex);
            }
        }
        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
#if DEBUG
            FirebasePushNotificationManager.DidRegisterRemoteNotifications(deviceToken,FirebaseTokenType.Sandbox);
            System.Diagnostics.Debug.WriteLine("token " + deviceToken);
#endif
#if RELEASE
                    FirebasePushNotificationManager.DidRegisterRemoteNotifications(deviceToken,FirebaseTokenType.Production);
#endif

        }

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            FirebasePushNotificationManager.RemoteNotificationRegistrationFailed(error);

        }
        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            FirebasePushNotificationManager.DidReceiveMessage(userInfo);

            System.Diagnostics.Debug.WriteLine("userInfo " + userInfo);
        }

        public override void OnActivated(UIApplication uiApplication)
        {
            FirebasePushNotificationManager.Connect();
            base.OnActivated(uiApplication);

        }   
    }

}
