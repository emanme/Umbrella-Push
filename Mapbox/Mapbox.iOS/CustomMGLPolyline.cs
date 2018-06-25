using System;
using Foundation;
using Mapbox;
using Naxam.Controls.Mapbox.Forms;
using UIKit;

namespace Naxam.Mapbox.Platform.iOS
{
    public class CustomMGLPolyline : MGLAnnotationView
    {
        private UIImageView _imageView;
    
        public CustomMGLPolyline(string reuseIdentifier, UIImage image) : base(reuseIdentifier)
        {
            this._imageView = new UIImageView(image);
            this.AddSubview(this._imageView);
            this.Frame = this._imageView.Frame;
        }
       
    }
}
