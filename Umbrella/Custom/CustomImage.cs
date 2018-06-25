using System;
using Umbrella.Helpers;
using Xamarin.Forms;

namespace Umbrella.Custom
{
    public class CustomImage : Image
    {
        public event EventHandler<PointEventArgs> TapEvent;
        public void OnTapEvent(int x, int y)
        {
            var method = TapEvent;
            if (method != null)
            {
                method(this, new PointEventArgs(x, y));
            }
        }
    }
}
