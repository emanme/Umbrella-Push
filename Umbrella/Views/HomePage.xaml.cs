using Plugin.Badge;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Umbrella.Interfaces;
using Umbrella.Models;
using Umbrella.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
         
            CheckConnection();
            HandleReceivedMessages();
            HomeFooter.SetRewardLevelIcon(Global.GetrewardPoints());
        }
        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessages>(this, "TickedMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    HomeFooter.BadgeVisibility = 1;
                    var notifList = Global.GetAllTopic();
                    var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();
                    HomeFooter.BadgeCountMessage = currentMessageCount.ToString();
                });
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Current.Resources["backgroundColor"] = Color.White;
            App.Current.Resources["backTextColor"] = Color.FromHex("#435742");
            var notifList = Global.GetAllTopic();
            var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();

            if (currentMessageCount <= 0)
            {
                HomeFooter.BadgeVisibility = 0;
            }
            else
            {
                HomeFooter.BadgeVisibility = 1;
                HomeFooter.BadgeCountMessage = currentMessageCount.ToString();
            }
            HomeFooter.SetRewardLevelIcon(Global.GetrewardPoints());
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        private async void RecruitPageButtonTapped(object sender, EventArgs args)
        {
            var page = new RecruitsPage();
            await Navigation.PushAsync(page);
        }
        private async void ComradesButtonTapped(object sender, EventArgs args)
        {
            var page = new ComradesPage();
            await Navigation.PushAsync(page);
        }

        private async void EarningsButtonTapped(object sender, EventArgs args)
        {
            var page = new EarningsPage();
            await Navigation.PushAsync(page);
        }

        private async void CallBacksButtonTapped(object sender, EventArgs args)
        {
            var page = new CallBacksPage();
            await Navigation.PushAsync(page);
        }
        private async void WeaponButtonTapped(object sender, EventArgs args)
        {
            var page = new WeaponsPage();
            await Navigation.PushAsync(page);
        }
        private async void CharityButtonTapped(object sender, EventArgs args)
        {
            var page = new CharityPage();
            await Navigation.PushAsync(page);
        }
        private async void TargetsPageButtonTapped(object sender, EventArgs args)
        {
            var page = new TargetsPage();
            await Navigation.PushAsync(page);
        }
        private async void CheckConnection()
        {
            try
            {
                // Check internet connection if available and update local data
                var networkConnection = DependencyService.Get<IConnectionChecker>();
                networkConnection.CheckNetworkConnection();
                if (networkConnection.IsConnected)
                {
                    // Update and sync all data from server to client application
                }
                else
                {
                    await DisplayAlert("Low Power!", "No internet connection detected.", "OK");
                }
            }
            catch (Exception e)
            {
                await DisplayAlert(string.Empty, "No internet connection detected.", "OK");
            }
        }
    }
}
