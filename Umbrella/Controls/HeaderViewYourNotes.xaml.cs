using System;
using Umbrella.Views;
using Xamarin.Forms;

namespace Umbrella.Controls
{
    public partial class HeaderViewYourNotes : ContentView
    {
        public HeaderViewYourNotes()
        {
            InitializeComponent();
        }

        private async void TopupButtonTapped(object sender, EventArgs args)
        {
            var page = new TopupPage();
            await Navigation.PushAsync(page);
        }

        private async void SettingsButtonTapped(object sender, EventArgs args)
        {
            var page = new SettingsPage();
            await Navigation.PushAsync(page);
        }
        private async void BackButtonTapped(object sender, EventArgs args)
        {
            
            await Navigation.PopAsync();
          // await Navigation.
        }
    }
}
