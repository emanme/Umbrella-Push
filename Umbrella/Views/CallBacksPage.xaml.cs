using Plugin.Badge;
using System;
using System.Linq;
using Umbrella.Models;
using Umbrella.Utilities;
using Xamarin.Forms;


namespace Umbrella.Views
{
    public partial class CallBacksPage : ContentPage
    {
        public Lead Leads { get; set; }
        public CallBacksPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            HandleReceivedMessages();
            CallbackFooter.SetRewardLevelIcon(Global.GetrewardPoints());

        }
        async void GoCallTime(object sender, EventArgs args)
        {
            var page = new CallTimeSchedulePage();
            await Navigation.PushAsync(page);
        }
        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessages>(this, "TickedMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    CallbackFooter.BadgeVisibility = 1;
                    var notifList = Global.GetAllTopic();
                    var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();
                    CallbackFooter.BadgeCountMessage = currentMessageCount.ToString();
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
                CallbackFooter.BadgeVisibility = 0;
            }
            else
            {
                CallbackFooter.BadgeVisibility = 1;
                CallbackFooter.BadgeCountMessage = currentMessageCount.ToString();
            }
            CallbackFooter.ActiveCallback(true);
            CallbackFooter.SetRewardLevelIcon(Global.GetrewardPoints());
        }
        private void LoadLeadsAsync()
        {
            //  App.LeadsViewModel.RefreshLeadsAsync();
            this.BindingContext = App.LeadsViewModel;
        }
        private async void CallBacksItemTapped(object sender, ItemTappedEventArgs e)
        {
            var callBack = e.Item as 
                            Lead;
            var page = new CallBacksItemPage(callBack);
            await Navigation.PushAsync(page);
        }
        private async void LeadsItemTapped(object sender, ItemTappedEventArgs e)
        {
            var lead = e.Item as Lead;
            var page = new LeadsItemPage(lead);
            await Navigation.PushAsync(page);
        }
        private async void ChangeOpeningHoursClicked(object sender, EventArgs args)
        {
            var page = new AppointmentsPage();
            await Navigation.PushAsync(page);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CallbackFooter.ActiveCallback(false);
            if (CallBacksListView.SelectedItem == null)
            {
                return;
            }
            CallBacksListView.SelectedItem = null;
        }
    }

}
