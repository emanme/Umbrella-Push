using System;
using System.Globalization;
using Umbrella.Enums;
using Xamarin.Forms;

namespace Umbrella.Converters
{
    public class CharityStatusToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (CharityStatus) value;
            switch (status)
            {
                case CharityStatus.Funded:
                    return "check_mark";
                case CharityStatus.Cancelled:
                    return "wrong_mark";
                case CharityStatus.Funding:
                    return "in_progress_mark";
                default:
                    return "in_progress_mark";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
