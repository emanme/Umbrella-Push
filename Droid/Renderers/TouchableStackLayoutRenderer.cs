using Umbrella.Controls;
using Umbrella.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TouchableStackLayout), typeof(TouchableStackLayoutRenderer))]
namespace Umbrella.Droid
{
    public class TouchableStackLayoutRenderer : VisualElementRenderer<View>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            SetBackgroundResource(Resource.Drawable.viewcellbackground);

            base.OnElementChanged(e);
        }
    }
}
