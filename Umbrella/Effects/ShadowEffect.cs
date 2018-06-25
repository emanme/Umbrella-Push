using Xamarin.Forms;

namespace Umbrella.Effects
{
    public class ShadowEffect : RoutingEffect
    {
        public float DistanceX { get; set; }

        public float DistanceY { get; set; }

        public float Radius { get; set; }

        public Color Color { get; set; }

        public ShadowEffect() : base("Umbrella.Effects.ShadowEffect")
        {
        }
    }
}
