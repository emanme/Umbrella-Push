using Plugin.Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Helpers;
using Umbrella.Models;
using Umbrella.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Umbrella.ViewModels;
using Umbrella.Services;

namespace Umbrella.Views
{
    public partial class ConquerorRankingPage : ContentPage
    {
        public ConquerorRankingPage()
        {
            InitializeComponent();
            ShowMostNewRecruitsTab();
            HandleReceivedMessages();
            NavigationPage.SetBackButtonTitle(this, "");
            ShowTopPerformers();
            Global.SetTopComNum(0);
            Global.SetTopResoNum(0);
        }
        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessages>(this, "TickedMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    ConquerorRankingFooter.BadgeVisibility = 1;
                    var notifList = Global.GetAllTopic();
                    var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();
                    ConquerorRankingFooter.BadgeCountMessage = currentMessageCount.ToString();
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
                ConquerorRankingFooter.BadgeVisibility = 0;
            }
            else
            {
                ConquerorRankingFooter.BadgeVisibility = 1;
                ConquerorRankingFooter.BadgeCountMessage = currentMessageCount.ToString();
            }
        }
        private void ShowTopPerformersTapped(object sender, EventArgs args)
        {
            ShowTopPerformers();
        }
        private async void ShowLocationTapped(object sender, EventArgs args)
        {
            var page = new MapLocationPage();
            await Navigation.PushAsync(page);
        }
        private async void MostResourcesTabTapped(object sender, EventArgs args)
        {
            Global.SetTopResoAddNum(1);
            if(Global.GetTopResoNum() == 1){
                StartBusyIndicator();
                await Task.Delay(300);
            }
            ShowMostResourcesTab();
        }
        private void MostNewRecruitsTabTapped(object sender, EventArgs args)
        {
            ShowMostNewRecruitsTab();
        }
        private async void MostNewComradesTabTapped(object sender, EventArgs args)
        {
            Global.SetTopComAddNum(1);
            if (Global.GetTopComNum() == 1)
            {
                StartBusyIndicator();
                await Task.Delay(300);
            }
            ShowMostNewComradesTab();
        }
        private void ShowTopPerformers()
        {
            SegmentedTabManager.SelectTab(TopPerformersTab);
            SegmentedTabManager.DeselectTab(LocationTab);
            MostNewRecruitsListView.IsVisible = true;

        }
        private void  StartBusyIndicator()
        {
            BusyIndicator.IsVisible = true;
            Indicator.IsBusy = true;
              
        }

        private void StopBusyIndicator()
        {
            BusyIndicator.IsVisible = false;
            Indicator.IsBusy = false;
        }     
        private void ShowMostResourcesTab()
        {
            var service = new ConquerorRankingService();
            if(Global.GetTopResoNum() == 1){
                var resourcesList = service.GetTopResources();
                foreach (var item in resourcesList.Where(c => c.Index == 0))
                {
                    item.Index = resourcesList.IndexOf(item) + 1;
                }
                mostResourceL.ItemsSource = resourcesList;
            }
            CustomTabButtonManager.SelectTab(MostResourcesTab);
            CustomTabButtonManager.DeselectTab(MostNewComradesTab);
            CustomTabButtonManager.DeselectTab(MostNewRecruitTab);
            MostResourcesTab.Icon = "pound_sign";
            MostNewComradesTab.Icon = "army_5t_black";
            MostNewRecruitTab.Icon = "guyt_black";
            StopBusyIndicator();
            MostResourcesListView.IsVisible = true;
            MostNewComradesListView.IsVisible = false;
            MostNewRecruitsListView.IsVisible = false;
        }
        private void ShowMostNewRecruitsTab()
        {
            CustomTabButtonManager.DeselectTab(MostResourcesTab);
            CustomTabButtonManager.SelectTab(MostNewRecruitTab);
            CustomTabButtonManager.DeselectTab(MostNewComradesTab);
            MostResourcesTab.Icon = "pound_sign_gray";
            MostNewComradesTab.Icon = "army_5t_black";
            MostNewRecruitTab.Icon = "guyt";

            MostResourcesListView.IsVisible = false;
            MostNewRecruitsListView.IsVisible = true;
            MostNewComradesListView.IsVisible = false;
        }
        private void ShowMostNewComradesTab()
        {
            var service = new ConquerorRankingService();
            if (Global.GetTopComNum() == 1)
            {
                var resourceslist = service.GetTopComrades();
                foreach (var item in resourceslist.Where(c => c.Index == 0))
                {
                    item.Index = resourceslist.IndexOf(item) + 1;
                }
                mostNewComradesL.ItemsSource = resourceslist;
            }
           
            CustomTabButtonManager.DeselectTab(MostResourcesTab);
            CustomTabButtonManager.SelectTab(MostNewComradesTab);
            CustomTabButtonManager.DeselectTab(MostNewRecruitTab);
            MostResourcesTab.Icon = "pound_sign_gray";
            MostNewComradesTab.Icon = "army_5t";
            MostNewRecruitTab.Icon = "guyt_black";
            StopBusyIndicator();
            MostResourcesListView.IsVisible = false;
            MostNewComradesListView.IsVisible = true;
            MostNewRecruitsListView.IsVisible = false;
        }
    }
}
