using System;
using System.Globalization;
using Umbrella.Enums;
using Xamarin.Forms;

namespace Umbrella.Converters
{
    public class ReferralStatusToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (ReferralStatus) value;
            switch (status)
            {
                case ReferralStatus.BecamePartner:
                    return "Became Partner";
                case ReferralStatus.NotSuitable:
                    return "Not Suitable";
                case ReferralStatus.FollowUpStage:
                    return "Follow\nUp Stage";
                default:
                    return "Follow\nUp Stage";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
