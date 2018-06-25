using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Umbrella.Controls
{
    public partial class SegmentedTab : ContentView
    {
        public delegate void TabTappedEventHandler(object sender, EventArgs args);

        public double WidthReq
        {
            get { return Background.WidthRequest; }
            set { Background.WidthRequest = value; }
        }
        public double HeightReq
        {
            get { return Background.HeightRequest; }
            set { Background.HeightRequest = value; }
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

        public event TabTappedEventHandler Tapped;
        public SegmentedTab()
        {
            InitializeComponent();
        }
        private void TabButtonTapped(object sender, EventArgs args)
        {
            Tapped?.Invoke(sender, args);
        }
    }
}
