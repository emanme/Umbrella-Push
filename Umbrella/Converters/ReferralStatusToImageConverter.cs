using System;
using System.Globalization;
using Umbrella.Enums;
using Xamarin.Forms;

namespace Umbrella.Converters
{
    public class ReferralStatusToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (ReferralStatus) value;
            switch (status)
            {
                case ReferralStatus.BecamePartner:
                    return "check_mark";
                case ReferralStatus.NotSuitable:
                    return "wrong_mark";
                case ReferralStatus.FollowUpStage:
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
