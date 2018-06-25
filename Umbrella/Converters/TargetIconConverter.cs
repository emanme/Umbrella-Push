using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Umbrella.Converters
{
    public class TargetIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = (string)value;
            var isAcquired = text.Split(' ')[0];
            var month = text.Split(' ')[1];
            var year = text.Split(' ')[2];

            if (isAcquired.Equals("True") && DateTime.Now.Year > Int32.Parse(year))
            {
                return "target_icon_green";
            }
            else if (DateTime.Now.Year == Int32.Parse(year))
            {
                if (isAcquired.Equals("True") && DateTime.Now.Month <= DateConverter(month))
                {
                    return "target_icon_green";
                }
            }
            else if (isAcquired.Equals("False") && DateTime.Now.Year > Int32.Parse(year))
            {
                return "target_icon_red";
            }
            return "target_icon_gray";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        private int DateConverter(string date)
        {
            var month = date.Split(' ')[0];
            switch (month)
            {
                case "Jan":
                    return 1;
                case "Feb":
                    return 2;
                case "Mar":
                    return 3;
                case "May":
                    return 4;
                case "Apr":
                    return 5;
                case "Jun":
                    return 6;
                case "Jul":
                    return 7;
                case "Aug":
                    return 8;
                case "Sep":
                    return 9;
                case "Oct":
                    return 10;
                case "Nov":
                    return 11;
                case "Dec":
                    return 12;

            }
            return 0;
        }
    }
}
