using System;
using UIKit;
using Umbrella.Interfaces;
using Umbrella.iOS.Dependencies;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceChecker))]
namespace Umbrella.iOS.Dependencies
{
    public class DeviceChecker : IDeviceChecker
    {
        public int GetDeviceVersion()
        {
            var ver = 0;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            {
                if ((UIScreen.MainScreen.Bounds.Height * UIScreen.MainScreen.Scale) == 1136)
                {
                    ver = 5;

                }
                else if ((UIScreen.MainScreen.Bounds.Height * UIScreen.MainScreen.Scale) == 1334)
                {
                    ver = 6;
                }
                else if ((UIScreen.MainScreen.Bounds.Height * UIScreen.MainScreen.Scale) == 1920 || (UIScreen.MainScreen.Bounds.Height * UIScreen.MainScreen.Scale) == 2208)
                {
                    ver = 61;
                }
            }
            return ver;
        }
    }
}
