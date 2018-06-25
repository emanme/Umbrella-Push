using Plugin.Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Helpers;
using Umbrella.Models;
using Umbrella.Utilities;
using Umbrella.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class ComradesPage : ContentPage
    {
        private int _skipEnlisted = 0;
        private int _nextClickEnlisted = 0;
        private int _skipEnlisting = 0;
        private int _nextClickEnlisting = 0;
        public ComradesPage()
        {
            InitializeComponent();
            ComradesFooter.SetRewardLevelIcon(Global.GetrewardPoints());
            ShowEnlistingTab();
            HandleReceivedMessages();
            NavigationPage.SetBackButtonTitle(this, "");
        }
        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessages>(this, "TickedMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    ComradesFooter.BadgeVisibility = 1;
                    var notifList = Global.GetAllTopic();
                    var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();
                    ComradesFooter.BadgeCountMessage = currentMessageCount.ToString();
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
                ComradesFooter.BadgeVisibility = 0;
            }
            else
            {
                ComradesFooter.BadgeVisibility = 1;
                ComradesFooter.BadgeCountMessage = currentMessageCount.ToString();
            }
        }
        private void EnlistingTabTapped(object sender, EventArgs args)
        {
            ShowEnlistingTab();
        }
        private void EnlistedTabTapped(object sender, EventArgs args)
        {
            ShowEnlistedTab();
        }
        private async void LocationTabTapped(object sender, EventArgs args)
        {
            var page = new MapLocationPage("Comrades");
            Navigation.InsertPageBefore(page, Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
            await Navigation.PopAsync();
        }
        private void ShowEnlistingTab()
        {
            TabCustomButtonManager.SelectTab(EnlistingTab);
            TabCustomButtonManager.DeselectTab(EnlistedTab);
            TabCustomButtonManager.DeselectTab(LocationsTab);
            EnlistingTab.Icon = "target_icon_green";
            EnlistedTab.Icon = "army5_gray";
            LocationsTab.Icon = "location_gray";

            EnlistingListView.IsVisible = true;
            EnlistedListView.IsVisible = false;
        }
        private void ShowEnlistedTab()
        {
            TabCustomButtonManager.DeselectTab(EnlistingTab);
            TabCustomButtonManager.SelectTab(EnlistedTab);
            TabCustomButtonManager.DeselectTab(LocationsTab);
            EnlistingTab.Icon = "target_icon_gray";
            EnlistedTab.Icon = "army5_green";
            LocationsTab.Icon = "location_gray";

            EnlistingListView.IsVisible = false;
            EnlistedListView.IsVisible = true;
        }
        private void NextButtonEnlistedClicked(object sender, EventArgs e)
        {
            _nextClickEnlisted = _nextClickEnlisted + 1;
            var viewmodel = (ComradesViewModel)this.BindingContext;
            var count = viewmodel.EnlistedListStaticList.Count;
            _skipEnlisted = _skipEnlisted + 10;
            var nextlist = viewmodel.EnlistedListStaticList.Skip(_skipEnlisted);
            viewmodel.EnlistedList = nextlist.ToList();
        }
        private void PreviousButtonEnlistedClicked(object sender, EventArgs e)
        {
            var viewmodel = (ComradesViewModel)this.BindingContext;
            var count = viewmodel.EnlistedList.Count;
            _skipEnlisted = _skipEnlisted - 10;
            if (_nextClickEnlisted == 1)
            {
                var prevList = viewmodel.EnlistedListStaticList.Take(10);
                viewmodel.EnlistedList = prevList.ToList();
            }
            else
            {
                var prevTake = 10 * _nextClickEnlisted;
                var prevList = viewmodel.EnlistedListStaticList.Take(prevTake);
                prevList = prevList.Skip(10);
                viewmodel.EnlistedList = prevList.ToList();
            }
            _nextClickEnlisted = _nextClickEnlisted - 1;
        }
        private void NextButtonEnlistingClicked(object sender, EventArgs e)
        {
            try
            {
                _nextClickEnlisting = _nextClickEnlisting + 1;
                var viewmodel = (ComradesViewModel)this.BindingContext;
                var count = viewmodel.EnlistingListStaticList.Count;
                _skipEnlisting = _skipEnlisting + 10;
                var nextlist = viewmodel.EnlistingListStaticList.Skip(_skipEnlisting);
                viewmodel.EnlistingList = nextlist.ToList();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("errormesg " + ex.Message);
            }
        }
        private void PreviousButtonEnlistingClicked(object sender, EventArgs e)
        {
            var viewmodel = (ComradesViewModel)this.BindingContext;
            var count = viewmodel.EnlistingList.Count;
            _skipEnlisting = _skipEnlisting - 10;
            if (_nextClickEnlisting == 1)
            {
                var prevList = viewmodel.EnlistingListStaticList.Take(10);
                viewmodel.EnlistingList = prevList.ToList();
            }
            else
            {
                var prevTake = 10 * _nextClickEnlisting;
                var prevList = viewmodel.EnlistingListStaticList.Take(prevTake);
                prevList = prevList.Skip(10);
                viewmodel.EnlistingList = prevList.ToList();
            }
            _nextClickEnlisting = _nextClickEnlisting - 1;
        }
    }
}
