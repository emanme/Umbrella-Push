using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Umbrella.Converters
{
    public class ImagePulseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var moraleText = (string)value;
            var morale = Int32.Parse(moraleText);

            if(morale >= 70 && morale <= 100)
            {
                return "heart_rate_green_trans";
            }
            else if(morale >= 29 && morale <= 69)
            {
                return "heart_rate_yellow_trans";
            }
            return "heart_rate_red_trans";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
