using System;
using UIKit;
using Umbrella.Interfaces;
using Umbrella.iOS.Dependencies;

[assembly: Xamarin.Forms.Dependency(typeof(LaunchCalendar))]
namespace Umbrella.iOS.Dependencies
{
    public class LaunchCalendar:ILaunchCalendar
    {
        public void OpenCalendar(){
            UIApplication.SharedApplication.OpenUrl(new Foundation.NSUrl(@"calshow://"));
        }
    }
}
