using System;
using Xamarin.Forms;

namespace Umbrella.Controls
{
    public partial class LabelTabButton : ContentView
    {
        public string Title
        {
            get { return ButtonTitle.Text; }
            set { ButtonTitle.Text = value; }
        }

        public double TitleSize
        {
            get { return ButtonTitle.FontSize; }
            set { ButtonTitle.FontSize = value; }
        }

        public Color TitleColor
        {
            get { return ButtonTitle.TextColor; }
            set { ButtonTitle.TextColor = value; }
        }

        public string Description
        {
            get { return ButtonDescription.Text; }
            set { ButtonDescription.Text = value; }
        }

        public double DescriptionSize
        {
            get { return ButtonDescription.FontSize; }
            set { ButtonDescription.FontSize = value; }
        }

        public Color DescriptionColor
        {
            get { return ButtonDescription.TextColor; }
            set { ButtonDescription.TextColor = value; }
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

        public LabelTabButton()
        {
            InitializeComponent();
        }

        private void TabButtonTapped(object sender, EventArgs args)
        {
            Tapped?.Invoke(sender, args);
        }
    }
}
