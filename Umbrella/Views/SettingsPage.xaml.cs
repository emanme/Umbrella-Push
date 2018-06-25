using System;
using Umbrella.Interfaces;
using Umbrella.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            App.Current.Resources["backgroundColor"] = Color.White;
            App.Current.Resources["backTextColor"] = Color.FromHex("#435742");
            NavigationPage.SetBackButtonTitle(this, "");
        }

        private async void SettingsItemTapped(object sender, ItemTappedEventArgs e)
        {
            var menu = e.Item as SettingsItem;

            if (menu.Target != null)
            {
                if (menu.Target.Name == "TermsAndConditionsPage")
                {
                    Device.OpenUri(new Uri("https://www.umbrellasupport.co.uk/mobile-app-terms/"));
                }
                else if (menu.Target.Name == "PrivacyPolicyPage")
                {
                    Device.OpenUri(new Uri(" https://www.umbrellasupport.co.uk/mobile-app-privacy/"));

                }
                else
                {
                    var page = (ContentPage)Activator.CreateInstance(menu.Target);
                    await Navigation.PushAsync(page);
                }
            }
            else
            {
                string action = "Logout";
                if (menu.Title.Equals(action))
                {
                    MessagingCenter.Send<string>(action, "RemoveUserData");
                    //await Navigation.PopModalAsync();
                    App.Current.MainPage = new LoginPage();
                    await DisplayAlert("Logout Success!", "You have successfully signed out your account.", "OK");
                }
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (SettingsListView.SelectedItem == null)
            {
                return;
            }
            SettingsListView.SelectedItem = null;
        }
    }
}
