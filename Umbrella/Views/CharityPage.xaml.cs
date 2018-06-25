using System;
using Umbrella.Helpers;
using Umbrella.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class CharityPage : ContentPage
    {
        public CharityPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");

            ShowMicroFinance();
        }

        private void MicroFinanceButtonTapped(object sender, EventArgs args)
        {
            ShowMicroFinance();
        }

        private void CleanWaterButtonTapped(object sender, EventArgs args)
        {
            ShowCleanWater();
        }

        private void YourCharityButtonTapped(object sender, EventArgs args)
        {
            ShowYourCharity();
        }

        private async void CharityItemTapped(object sender, ItemTappedEventArgs e)
        {
            var charity = e.Item as Charity;
            var page = new CharityItemPage(charity);
            await Navigation.PushAsync(page);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (CharityListView.SelectedItem == null)
            {
                return;
            }
            CharityListView.SelectedItem = null;
        }

        private void ShowMicroFinance()
        {
            TabButtonManager.SelectTab(MicroFinanceTab);
            TabButtonManager.DeselectTab(CleanWaterTab);
            TabButtonManager.DeselectTab(YourCharityTab);
            MicroFinanceTab.Icon = "micro_finance_green_new";
            CleanWaterTab.Icon = "clean_water_new";
            YourCharityTab.Icon = "your_charity_new";
            CharityListView.IsVisible = true;
            YourCharityPage.IsVisible = false;
        }

        private void ShowCleanWater()
        {
            TabButtonManager.DeselectTab(MicroFinanceTab);
            TabButtonManager.SelectTab(CleanWaterTab);
            TabButtonManager.DeselectTab(YourCharityTab);
            MicroFinanceTab.Icon = "micro_finance_new";
            CleanWaterTab.Icon = "clean_water_green_new";
            YourCharityTab.Icon = "your_charity_new";
            CharityListView.IsVisible = true;
            YourCharityPage.IsVisible = false;
        }

        private void ShowYourCharity()
        {
            TabButtonManager.DeselectTab(MicroFinanceTab);
            TabButtonManager.DeselectTab(CleanWaterTab);
            TabButtonManager.SelectTab(YourCharityTab);
            MicroFinanceTab.Icon = "micro_finance_new";
            CleanWaterTab.Icon = "clean_water_new";
            YourCharityTab.Icon = "your_charity_green_new";
            CharityListView.IsVisible = false;
            YourCharityPage.IsVisible = true;
        }
    }
}
