using System.Reflection;
using Umbrella.Controls;
using Umbrella.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(StillTabbedPage), typeof(StillTabbedPageRenderer))]
namespace Umbrella.Droid.Renderers
{
    public class StillTabbedPageRenderer : TabbedPageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            var propInfo = typeof(TabbedPageRenderer).GetProperty("UseAnimations", BindingFlags.Instance | BindingFlags.NonPublic);
            propInfo.SetValue(this, false);
        }
    }
}
