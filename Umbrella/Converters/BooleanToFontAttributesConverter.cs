using System;
using System.Globalization;
using Xamarin.Forms;

namespace Umbrella.Converters
{
    public class BooleanToFontAttributesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isUnread = (bool) value;
            if (isUnread)
            {
                return FontAttributes.Bold;
            }
            else
            {
                return FontAttributes.None;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
