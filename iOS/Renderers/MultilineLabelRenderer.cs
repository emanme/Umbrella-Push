using Umbrella.Controls;
using Umbrella.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MultilineLabel), typeof(MultilineLabelRenderer))]
namespace Umbrella.iOS.Renderers
{
    public class MultilineLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            MultilineLabel multilineLabel = (MultilineLabel) Element;
            if (multilineLabel != null && multilineLabel.Lines != -1)
            {
                Control.Lines = multilineLabel.Lines;
            }
        }
    }
}