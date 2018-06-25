using System;
using System.Globalization;
using Umbrella.Enums;
using Xamarin.Forms;

namespace Umbrella.Converters
{
    public class CharityStatusToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (CharityStatus) value;
            switch (status)
            {
                case CharityStatus.Funded:
                    return "Funded";
                case CharityStatus.Cancelled:
                    return "Cancelled";
                case CharityStatus.Funding:
                    return "Funding";
                default:
                    return "Funding";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
