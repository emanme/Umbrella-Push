using Plugin.Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbrella.Enums;
using Umbrella.Helpers;
using Umbrella.Models;
using Umbrella.Utilities;
using Umbrella.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class MessagesPage : ContentPage
    {
        private MessagesViewModel _messagesViewModel;

        public MessagesPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");

            ShowUmbrellaMessages();
            HandleReceivedMessages();
        }
        private async void OpenMessageModal(object sender, EventArgs e){

            await Navigation.PushModalAsync(new SpendPointsPage(new Message()));

        }
        private void BusinessGrowthExecutiveButtonTapped(object sender, EventArgs args)
        {
            ShowBusinessGrowthExecutive();
        }
        private void UmbrellaMessagesButtonTapped(object sender, EventArgs args)
        {
            ShowUmbrellaMessages();
        }
        private void OtherPartnersButtonTapped(object sender, EventArgs args)
        {
            ShowOtherPartners();
        }
        private async void MessagesItemTapped(object sender, ItemTappedEventArgs e)
        {
            var message = e.Item as Message;
            message.IsUnread = false;
            var page = new MessageItemPage(message);
            await Navigation.PushAsync(page);
        }
        private async void TopItemTapped(object sender, ItemTappedEventArgs e)
        {
            var list = Global.GetTopUnreadTest();
            if(!list.FirstOrDefault().Read){
                var message = e.Item as Message;
                message.IsUnread = false;
                var page = new SpendPointsPage(message);
                await Navigation.PushAsync(page);
            }
            else{
                ((ListView)sender).SelectedItem = null;
            }
           
              
        }

        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessages>(this, "TickedMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    MessagesFooter.BadgeVisibility = 1;
                    var notifList = Global.GetAllTopic();
                    var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();
                    MessagesFooter.BadgeCountMessage = currentMessageCount.ToString();
                });
            });
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
            TopSecretTabPage.ItemsSource = Global.GetTopUnreadTest();
            TopSecretTabPage.SelectedItem = null;
            MessagesFooter.BadgeCountMessage = "0";
            MessagesFooter.SetRewardLevelIcon(Global.GetrewardPoints());
            if (Global.GetAllTopic().Any())
            {
                Global.SetAllTopic(RemoveAllMessageNotif());

                Global.SetNotifBadge(Global.GetAllTopic().Where(e => e.Value == "new_message").Count());
                CrossBadge.Current.SetBadge(Global.GetNotifCount());
                Global.SetMessageCount(0);
            }
            else
            {
                var list = RemoveAllMessageNotif();
                Global.SetNotifBadge(Global.GetNotifCount() - list.Where(e => e.Value == "new_message").Count());
                CrossBadge.Current.SetBadge(Global.GetNotifCount());
                Global.SetMessageCount(0);
            }

            var notifList = Global.GetAllTopic();
            var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();

            if (currentMessageCount <= 0)
            {
                MessagesFooter.BadgeVisibility = 0;
            }
            else
            {
                MessagesFooter.BadgeVisibility = 1;
                MessagesFooter.BadgeCountMessage = currentMessageCount.ToString();
            }
            MessagesFooter.ActiveMessages(true);
            MessagesFooter.SetRewardLevelIcon(Global.GetrewardPoints());
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagesFooter.ActiveMessages(false);
            if (MessagesListView.SelectedItem == null)
            {
                return;
            }
            MessagesListView.SelectedItem = null;
            if (TopSecretTabPage.SelectedItem == null)
            {
                return;
            }
            TopSecretTabPage.SelectedItem = null;
        }
        private Dictionary<int, string> RemoveAllMessageNotif()
        {
            var notifList = Global.GetAllTopic();
            var toRemove = notifList.Where(pair => pair.Value == "new_message")
                      .Select(pair => pair.Key)
                      .ToList();

            foreach (var item in toRemove)
            {
                notifList.Remove(item);
            }

            return notifList;
        }
        private void ShowBusinessGrowthExecutive()
        {
            CustomTabButtonManager.SelectTab(BusinessGrowthExecutiveTab);
            CustomTabButtonManager.DeselectTab(UmbrellaMessagesTab);
            CustomTabButtonManager.DeselectTab(OtherPartnersTab);
            BusinessGrowthExecutiveTab.Icon = "mission_green";
            UmbrellaMessagesTab.Icon = "general_white";
            OtherPartnersTab.Icon = "top_secret_white";
            MessagesListView.IsVisible = false;
            MissionsTabPage.IsVisible = true;
            TopSecretTabPage.IsVisible = false;

            //MessagesListView.ItemsSource = _messagesViewModel.Messages.Where(x => x.Type == MessageType.BusinessGrowthExecutive);
        }
        private void ShowUmbrellaMessages()
        {
            CustomTabButtonManager.DeselectTab(BusinessGrowthExecutiveTab);
            CustomTabButtonManager.SelectTab(UmbrellaMessagesTab);
            CustomTabButtonManager.DeselectTab(OtherPartnersTab);
            BusinessGrowthExecutiveTab.Icon = "mission_white";
            UmbrellaMessagesTab.Icon = "general_green";
            OtherPartnersTab.Icon = "top_secret_white";
            MessagesListView.IsVisible = true;
            MissionsTabPage.IsVisible = false;
            TopSecretTabPage.IsVisible = false;
            //MessagesListView.ItemsSource = _messagesViewModel.Messages.Where(x => x.Type == MessageType.UmbrellaMessages);
        }
        private void ShowOtherPartners()
        {
            CustomTabButtonManager.DeselectTab(BusinessGrowthExecutiveTab);
            CustomTabButtonManager.DeselectTab(UmbrellaMessagesTab);
            CustomTabButtonManager.SelectTab(OtherPartnersTab);
            BusinessGrowthExecutiveTab.Icon = "mission_white";
            UmbrellaMessagesTab.Icon = "general_white";
            OtherPartnersTab.Icon = "top_secret_green";
            MessagesListView.IsVisible = false;
            MissionsTabPage.IsVisible = false;
            TopSecretTabPage.IsVisible = true;
            //MessagesListView.ItemsSource = _messagesViewModel.Messages.Where(x => x.Type == MessageType.OtherPartners);
        }
    }
}
