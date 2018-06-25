using System;
using Xamarin.Forms;

namespace Umbrella.Controls
{
    public partial class FooterItem : ContentView
    {
        public ImageSource Icon
        {
            get { return ButtonIcon.Source; }
            set { ButtonIcon.Source = value; }
        }
        public double WidthReq
        {
            get { return ButtonIcon.WidthRequest; }
            set { ButtonIcon.WidthRequest = value; }
        }
        public double HeightReq
        {
            get { return ButtonIcon.HeightRequest; }
            set { ButtonIcon.HeightRequest = value; }
        }
        public string Label
        {
            get { return ButtonLabel.Text; }
            set { ButtonLabel.Text = value; }
        }

        public double LabelSize
        {
            get { return ButtonLabel.FontSize; }
            set { ButtonLabel.FontSize = value; }
        }

        public Color LabelColor
        {
            get { return ButtonLabel.TextColor; }
            set { ButtonLabel.TextColor = value; }
        }

        public event TabTappedEventHandler Tapped;

        public FooterItem()
        {
            InitializeComponent();
        }

        private void ItemTapped(object sender, EventArgs args)
        {
            Tapped?.Invoke(sender, args);
        }
    }
}
