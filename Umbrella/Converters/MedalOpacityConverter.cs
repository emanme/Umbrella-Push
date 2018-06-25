using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Umbrella.Converters
{
    public class MedalOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var medalWithAction = (string)value;
            var action = medalWithAction.Split(' ').Last().Trim();
            var medalName = medalWithAction.Replace(action, "").Trim();
            switch (medalName)
            {
                case "Victory Medal":
                    return "medal_victory_big";
                case "Comms Expert Medal":
                    return "medal_expert_big";
                case "Conqueror Medal":
                    return "medal_conqueror_big";
                case "Bravery Medal":
                    return "medal_bravery_big";
                case "Defender Medal":
                    return "medal_defender_big";
                case "Intelligence Medal":
                    return "medal_intel_big";
                default:
                    return "medal_grayed_big";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
