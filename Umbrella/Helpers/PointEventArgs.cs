using System;
namespace Umbrella.Helpers
{
    public class PointEventArgs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
