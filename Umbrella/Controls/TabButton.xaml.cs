using System;
using Xamarin.Forms;

namespace Umbrella.Controls
{
    public delegate void TabTappedEventHandler(object sender, EventArgs args);

    public partial class TabButton : ContentView
    {
        public ImageSource Icon
        {
            get { return ButtonIcon.Source; }
            set { ButtonIcon.Source = value; }
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

        public TabButton()
        {
            InitializeComponent();
        }

        private void TabButtonTapped(object sender, EventArgs args)
        {
            Tapped?.Invoke(sender, args);
        }
    }
}
