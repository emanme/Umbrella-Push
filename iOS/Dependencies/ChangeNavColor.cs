using System;
using UIKit;
using Umbrella.Interfaces;
using Umbrella.iOS.Dependencies;
using Xamarin.Forms;

[assembly: Dependency(typeof(ChangeNavColor))]
namespace Umbrella.iOS.Dependencies
{
    public class ChangeNavColor : IChangeNavColor
    {
        public void ChangeNavigationBlackBG()
        {
            System.Diagnostics.Debug.WriteLine("asdafsdsd");
            UINavigationBar.Appearance.BarTintColor = UIColor.Black;
        }

        public void ChangeNavigationWhiteBG()
        {
            UINavigationBar.Appearance.BarTintColor = UIColor.White;
        }
    }
}
