using System;
using Xamarin.Forms;

namespace Umbrella.Controls
{
    public delegate void SpringboardTappedEventHandler(object sender, EventArgs args);

    public partial class SpringboardButton : ContentView
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

        public event SpringboardTappedEventHandler Tapped;

        public SpringboardButton()
        {
            InitializeComponent();
        }

        private void SpringboardButtonTapped(object sender, EventArgs args)
        {
            Tapped?.Invoke(sender, args);
        }
    }
}
