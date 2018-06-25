using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Umbrella.Controls
{
    public partial class TabCustomButton : ContentView
    {
        public ImageSource Icon
        {
            get { return ButtonIcon.Source; }
            set { ButtonIcon.Source = value; }
        }
        public double HeightReq
        {
            get { return ButtonIcon.HeightRequest; }
            set { ButtonIcon.HeightRequest = value; }
        }
        public double WidthReq
        {
            get { return ButtonIcon.WidthRequest; }
            set { ButtonIcon.WidthRequest = value; }
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

        public Color BorderColor
        {
            get { return BackgroundColor; }
            set { BackgroundColor = value; }
        }

        public Color Color
        {
            get { return Background.BackgroundColor; }
            set { Background.BackgroundColor = value; }
        }

        public bool HasIcon
        {
            get { return ButtonIcon.IsVisible; }
            set { ButtonIcon.IsVisible = value; }
        }

        public event TabTappedEventHandler Tapped;
        public TabCustomButton()
        {
            InitializeComponent();
        }
        private void TabButtonTapped(object sender, EventArgs args)
        {
            Tapped?.Invoke(sender, args);
        }
    }
}
