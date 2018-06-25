using UIKit;
using Umbrella.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TimePicker), typeof(CustomTimePickerRenderer))]
namespace Umbrella.iOS
{
    public class CustomTimePickerRenderer : TimePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);
            if (Element != null)
            {
                var timePicker = (UIDatePicker)Control.InputView;
                timePicker.MinuteInterval = 15;
            }
        }
    }
}
