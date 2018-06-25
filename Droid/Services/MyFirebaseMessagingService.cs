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
using Firebase.Messaging;
using Android.Media;
using Plugin.Badge;
using Umbrella.Utilities;
using Umbrella.Views;
using Xamarin.Forms;
using Umbrella.Models;
using Umbrella.Interfaces;
using Android.Graphics;
using Java.Net;
using Java.IO;
using System.Net;
using Android.Support.V4.App;

namespace Umbrella.Droid.Services
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        private int _notifCount;
        const string TAG = "MyFirebaseMsgService";
        private static readonly int ButtonClickNotificationId = 1000;
        public override void HandleIntent(Intent p0)
        {
            //set badge foreground/background
            var credentials = DependencyService.Get<ICredentialRetriever>().GetCredential();
            base.HandleIntent(p0);
            //set badge foreground/background
            if (credentials.UserID == p0.Extras.GetString("partner_id"))
            {
                Global.SetNotifBadge(Global.GetNotifCount() + 1);
                CrossBadge.Current.SetBadge(Global.GetNotifCount());
                Notify(p0);
            }
        }
        public void Notify(Intent intent)
        {
            var rand = new Random();
            var randomNum = rand.Next();
            Bundle valuesForActivity = new Bundle();
            valuesForActivity.PutInt("topicId", randomNum);

            Global.SetNotifTopic(intent.Extras.GetString("push_type"));
            Global.SetListTopic(randomNum, intent.Extras.GetString("push_type"));

         
            Intent resultIntent = new Intent(this, typeof(MainActivity));
            resultIntent.PutExtras(valuesForActivity);

            Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(this);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));
            stackBuilder.AddNextIntent(resultIntent);

            // Create the PendingIntent with the back stack:            
            PendingIntent resultPendingIntent =
                stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

            var fullmessage = intent.Extras.GetString("message") + "\n" + intent.Extras.GetString("article_data");
            var imageBitmap = GetImageBitmapFromUrl(intent.Extras.GetString("image_url"));

            NotificationCompat.BigPictureStyle picstyle = new NotificationCompat.BigPictureStyle();
            picstyle.BigPicture(imageBitmap);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(this)
            .SetAutoCancel(true)
            .SetContentIntent(resultPendingIntent)
            .SetContentTitle(intent.Extras.GetString("title"))
            .SetNumber(Global.GetNotifCount())
            .SetStyle(picstyle)
            .SetSmallIcon(Resource.Drawable.UmbrellaArmyFavicon)
            .SetContentText(String.Format(fullmessage));

            // Finally, publish the notification:
            NotificationManager notificationManager =
                (NotificationManager)GetSystemService(Context.NotificationService);
            notificationManager.Notify(ButtonClickNotificationId, builder.Build());

            if (Global.GetNotifTopic() != "general" || Global.GetNotifTopic() != "general_android")
            {
                var message = new StartLongRunningTaskMessage();
                MessagingCenter.Send(message, "StartLongRunningTaskMessage");
            }

        }
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }
    }
}