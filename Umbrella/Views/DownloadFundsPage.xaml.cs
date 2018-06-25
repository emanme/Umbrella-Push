using System;
using System.Collections.Generic;
using Umbrella.Interfaces;
using Xamarin.Forms;

namespace Umbrella.Views
{
    public partial class DownloadFundsPage : ContentPage
    {
        public DownloadFundsPage()
        {
            InitializeComponent();
            App.Current.Resources["backgroundColor"] = Color.Black;
            App.Current.Resources["backTextColor"] = Color.White;
            var ver = DependencyService.Get<IDeviceChecker>().GetDeviceVersion();
            if (ver == 5)
            {
                labelFont.FontSize = 11;
                AbsoluteLayout.SetLayoutBounds(labelFont,new Rectangle(.5, 1, .7, .6));
                AbsoluteLayout.SetLayoutBounds(imgeBig, new Rectangle(.5, .5, 1, .3));
                AbsoluteLayout.SetLayoutBounds(imgSmall, new Rectangle(.5, .5, 1, .2));
            }
            else if (ver == 6)
            {
                labelFont.FontSize = 10;
                AbsoluteLayout.SetLayoutBounds(labelFont, new Rectangle(.5, 1.1, .7, .6));
                AbsoluteLayout.SetLayoutBounds(imgeBig, new Rectangle(.5, .5, 1, .3));
                AbsoluteLayout.SetLayoutBounds(imgSmall, new Rectangle(.5, .5, 1, .15));
            }
            else if (ver == 61)
            {
                labelFont.FontSize = 10;
                AbsoluteLayout.SetLayoutBounds(labelFont, new Rectangle(.5, 1.1, .7, .6));
                AbsoluteLayout.SetLayoutBounds(imgeBig, new Rectangle(.5, .5, 1, .3));
                AbsoluteLayout.SetLayoutBounds(imgSmall, new Rectangle(.5, .5, 1, .15));
            }
        }
    }
}
