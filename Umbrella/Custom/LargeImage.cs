using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Umbrella.Custom
{
    public class LargeImage : Image
    {
        public static readonly BindableProperty ImageSourceProperty =
       BindableProperty.Create("ImageSource", typeof(string), typeof(LargeImage), default(string), propertyChanged: (bindable, oldValue, newValue) =>
       {
           if (Device.RuntimePlatform != Device.Android)
           {
               var image = (LargeImage)bindable;

               var baseImage = (Image)bindable;
               baseImage.Source = image.ImageSource;
           }
       });

        public string ImageSource
        {
            get { return GetValue(ImageSourceProperty) as string; }
            set { SetValue(ImageSourceProperty, value); }
        }
    }

}
