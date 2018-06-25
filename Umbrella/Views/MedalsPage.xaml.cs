using Plugin.Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Models;
using Umbrella.Utilities;
using Umbrella.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class MedalsPage : ContentPage
    {
        public MedalsPage()
        {
            InitializeComponent();
            HandleReceivedMessages();
            NavigationPage.SetBackButtonTitle(this, "");
        }
        private async void MedalsTapped(object sender, ItemTappedEventArgs e)
        {
            var medal = e.Item as Medal;
            var page = new MedalsItemPage(medal);
            await Navigation.PushAsync(page);
        }
        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessages>(this, "TickedMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    MedalsFooter.BadgeVisibility = 1;
                    var notifList = Global.GetAllTopic();
                    var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();
                    MedalsFooter.BadgeCountMessage = currentMessageCount.ToString();
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
                MedalsFooter.BadgeVisibility = 0;
            }
            else
            {
                MedalsFooter.BadgeVisibility = 1;
                MedalsFooter.BadgeCountMessage = currentMessageCount.ToString();
            }
            MedalsFooter.ActiveMedalPage(true);
            MedalListView.IsVisible = true;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MedalsFooter.ActiveMedalPage(false);
            if (MedalListView.SelectedItem == null)
            {
                return;
            }
            MedalListView.SelectedItem = null;
            MedalListView.IsVisible = false;
        }
    }
}
