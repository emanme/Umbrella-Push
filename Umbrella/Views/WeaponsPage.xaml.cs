using Plugin.Badge;
using System;
using System.Linq;
using Umbrella.Models;
using Umbrella.Utilities;
using Xamarin.Forms;

namespace Umbrella.Views
{
    public partial class WeaponsPage : ContentPage
    {
        public WeaponsPage()
        {
            InitializeComponent();
            HandleReceivedMessages();
            App.Current.Resources["backgroundColor"] = Color.White;
            App.Current.Resources["backTextColor"] = Color.FromHex("#435742");
            NavigationPage.SetBackButtonTitle(this, "");
            WeaponFooter.SetRewardLevelIcon(Global.GetrewardPoints());
        }
        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessages>(this, "TickedMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    WeaponFooter.BadgeVisibility = 1;
                    var notifList = Global.GetAllTopic();
                    var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();
                    WeaponFooter.BadgeCountMessage = currentMessageCount.ToString();
                });
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var notifList = Global.GetAllTopic();
            var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();

            if (currentMessageCount <= 0)
            {
                WeaponFooter.BadgeVisibility = 0;
            }
            else
            {
                WeaponFooter.BadgeVisibility = 1;
                WeaponFooter.BadgeCountMessage = currentMessageCount.ToString();
            }
            WeaponFooter.SetRewardLevelIcon(Global.GetrewardPoints());
        }

        async void OnRecruitsArmoryTapped(object sender, EventArgs args)
        {
            var page = new RecruitsArmoryPage();
            await Navigation.PushAsync(page);
        }

        async void OnComradesArmoryTapped(object sender, EventArgs args)
        {
            var page = new ComradesArmoryPage();
            await Navigation.PushAsync(page);
        }
        async void GoStepProgress(object sender, EventArgs args)
        {
            var page = new StepProgressPage();
            await Navigation.PushAsync(page);
        }
       
        async void OnCreateAllianceTapped(object sender, EventArgs args)
        {
            var page = new CreateAlliancePage();
            await Navigation.PushAsync(page);
        }

        private async void OnBackButtonTapped(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}