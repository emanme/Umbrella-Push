using System.ComponentModel;
using Umbrella.Controls;
using Umbrella.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MultilineLabel), typeof(MultilineLabelRenderer))]
namespace Umbrella.Droid.Renderers
{
    public class MultilineLabelRenderer : LabelRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            MultilineLabel multilineLabel = (MultilineLabel) Element;
            if (multilineLabel != null && multilineLabel.Lines != -1)
            {
                Control.SetSingleLine(false);
                Control.SetLines(multilineLabel.Lines);
            }
        }
    }
}