using Plugin.Badge;
using System.Linq;
using Umbrella.Models;
using Umbrella.Services;
using Umbrella.Utilities;
using Umbrella.ViewModels;
using Xamarin.Forms;
using Umbrella.Helpers;
using System;

namespace Umbrella.Views
{
    public partial class TargetsPage : ContentPage
    {
        private TargetsService _targetService;
        public TargetsPage()
        {
            InitializeComponent();
            HandleReceivedMessages();
            NavigationPage.SetBackButtonTitle(this, "");
            ShowUpcoming();
            _targetService = new TargetsService();
            TargetFooter.SetRewardLevelIcon(Global.GetrewardPoints());
        }
        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessages>(this, "TickedMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    TargetFooter.BadgeVisibility = 1;
                    var notifList = Global.GetAllTopic();
                    var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();
                    TargetFooter.BadgeCountMessage = currentMessageCount.ToString();
                });
            });
        }
        private void ShowUpcomingTapped(object sender, EventArgs args)
        {
            ShowUpcoming();
        }
        private void ShowPreviousTapped(object sender, EventArgs args)
        {
            ShowPrevious();
        }
        private void ShowUpcoming()
        {
            SegmentedTabManager.SelectTab(UpcomingTab);
            SegmentedTabManager.DeselectTab(PreviousTab);

            CurrentLayout.IsVisible = true;
            PreviousLayout.IsVisible = false;
        }
        private void ShowPrevious()
        {
            SegmentedTabManager.SelectTab(PreviousTab);
            SegmentedTabManager.DeselectTab(UpcomingTab);
            CurrentLayout.IsVisible = false;
            PreviousLayout.IsVisible = true;

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var notifList = Global.GetAllTopic();
            var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();

            if (currentMessageCount <= 0)
            {
                TargetFooter.BadgeVisibility = 0;
            }
            else
            {
                TargetFooter.BadgeVisibility = 1;
                TargetFooter.BadgeCountMessage = currentMessageCount.ToString();
            }
            TargetFooter.SetRewardLevelIcon(Global.GetrewardPoints());
            var viewModel = (TargetsViewModel)this.BindingContext;
            await viewModel.SetupList();
        }
    }
}
