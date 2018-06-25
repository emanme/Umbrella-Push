using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Umbrella.Converters
{
    public class MoraleTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var moraleText = (string)value;
            var morale = Int32.Parse(moraleText);

            if (morale >= 70 && morale <= 100)
            {
                return Color.FromHex("#435742");
            }
            else if (morale >= 29 && morale <= 69)
            {
                return Color.Gray;
            }
            return Color.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
