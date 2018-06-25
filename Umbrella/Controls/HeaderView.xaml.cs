using System;
using Umbrella.Views;
using Xamarin.Forms;

namespace Umbrella.Controls
{
    public partial class HeaderView : ContentView
    {
        public HeaderView()
        {
            InitializeComponent();
        }

        private async void TopupButtonTapped(object sender, EventArgs args)
        {
            var page = new EarningsPage();
            await Navigation.PushAsync(page);   
        }
        private async void CreditCardTapped(object sender, EventArgs args)
        {
            var page = new LoyaltyPage();
            await Navigation.PushAsync(page);
        }

        private async void SettingsButtonTapped(object sender, EventArgs args)
        {
            var page = new SettingsPage();
            await Navigation.PushAsync(page);
        }

        private async void SateliteDishButtonTapped(object sender, EventArgs e)
        {
            var page = new ConquerorRankingPage();
            await Navigation.PushAsync(page);
        }
        private async void UmbrellaLogoTapped(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
