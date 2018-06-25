using System;
using Xamarin.Forms;

namespace Naxam.Controls.Mapbox.Forms
{
	public class PointAnnotation: Annotation
	{
		public PointAnnotation()
		{
		}

		public Position Coordinate { get; set; }

        public string Icon { get; set; }
        public string Color { get; set; }
        public string MapType { get; set; }
       
	}
}
