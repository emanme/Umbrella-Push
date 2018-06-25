using Android.Content;
using Android.Net;
using Umbrella.Droid.Dependencies;
using Umbrella.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnectionChecker))]
namespace Umbrella.Droid.Dependencies
{
    public class ConnectionChecker : IConnectionChecker
    {
        public bool IsConnected { get; set; }

        public void CheckNetworkConnection()
        {
            var connectivityManager = (ConnectivityManager) Forms.Context
                .ApplicationContext.GetSystemService(Context.ConnectivityService);
            var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = false;
            }
        }
    }
}
