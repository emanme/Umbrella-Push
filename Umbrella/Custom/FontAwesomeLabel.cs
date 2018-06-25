using Xamarin.Forms;

namespace Umbrella.Custom
{
    public class FontAwesomeLabel : Label
    {
        public const string Typeface = "FontAwesome";

        public FontAwesomeLabel()
        {
        }

        public FontAwesomeLabel(string fontAwesomeIcon = null)
        {
            Text = fontAwesomeIcon;
            FontFamily = Typeface;
        }
    }
}
