using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Umbrella.Droid
{
    [Activity(
        Label = "@string/appName",
        Icon = "@drawable/UmbrellaArmyFavicon",
        Theme = "@style/Theme.Splash",
        MainLauncher = true,
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize
        | ConfigChanges.Orientation
    )]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}
