using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Umbrella.Converters
{
    public class MedalImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var medalWithAction = (string)value;
            var action = medalWithAction.Split(' ').Last().Trim();
            var medalName = medalWithAction.Replace(action, "").Trim();
            if (action.Equals("unlock"))
            {
                switch (medalName)
                {
                    case "Victory Medal":
                        return "medal_victory";
                    case "Comms Expert Medal":
                        return "medal_expert";
                    case "Conqueror Medal":
                        return "medal_conqueror";
                    case "Bravery Medal":
                        return "medal_bravery";
                    case "Defender Medal":
                        return "medal_defender";
                    case "Intelligence Medal":
                        return "medal_intel";
                    default:
                        return "medal_grayed";
                }
            }
            else
            {
                return "medal_grayed";
            }
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
