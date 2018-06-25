using System;
using CoreGraphics;
using UIKit;
using Umbrella.Custom;
using Umbrella.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomImage), typeof(CustomImageRenderer))]
namespace Umbrella.iOS.Renderers
{
    public class CustomImageRenderer : ImageRenderer
    {
        private UIImageView nativeElement;
        private CustomImage formsElement;
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                // Grab the Xamarin.Forms control (not native)
                formsElement = e.NewElement as CustomImage;
                // Grab the native representation of the Xamarin.Forms control
                nativeElement = Control as UIImageView;
                // Set up a tap gesture recognizer on the native control
                nativeElement.UserInteractionEnabled = true;
                UILongPressGestureRecognizer tgr = new UILongPressGestureRecognizer(TapHandler);
                nativeElement.AddGestureRecognizer(tgr);
            }
        }

        public void TapHandler(UILongPressGestureRecognizer tgr)
        {
            CGPoint touchPoint = tgr.LocationInView(nativeElement);
            formsElement.OnTapEvent((int)touchPoint.X, (int)touchPoint.Y);
        }
    }
}
