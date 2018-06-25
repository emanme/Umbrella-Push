using Plugin.Badge;
using System;
using System.Linq;
using Umbrella.Helpers;
using Umbrella.Models;
using Umbrella.Utilities;
using Umbrella.ViewModels;
using Xamarin.Forms;
using Umbrella.Services;
using System.Collections.Generic;

namespace Umbrella.Views
{
    public partial class RecruitsPage : ContentPage
    {
        private int _skipRecruited = 0;
        private int _nextClickRecruited = 0;
        private int _skipRecruiting = 0;
        private int _nextClickRecruiting = 0;
        private RecruitService _recruitService;
        public RecruitsPage()
        {
            InitializeComponent();
            HandleReceivedMessages();
            _recruitService = new RecruitService();
            NavigationPage.SetBackButtonTitle(this, "");
            ShowRecruitingTab();
            Global.SetRecNum(0);
            RecruitsFooter.SetRewardLevelIcon(Global.GetrewardPoints());
        }
        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessages>(this, "TickedMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    RecruitsFooter.BadgeVisibility = 1;
                    var notifList = Global.GetAllTopic();
                    var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();
                    RecruitsFooter.BadgeCountMessage = currentMessageCount.ToString();
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
                RecruitsFooter.BadgeVisibility = 0;
            }
            else
            {
                RecruitsFooter.BadgeVisibility = 1;
                RecruitsFooter.BadgeCountMessage = currentMessageCount.ToString();
            }
            RecruitsFooter.SetRewardLevelIcon(Global.GetrewardPoints());
        }
        private void RecruitingTabTapped(object sender, EventArgs args)
        {
            ShowRecruitingTab();
        }
        private void RecruitedTabTapped(object sender, EventArgs args)
        {
            ShowRecruitedTab();
        }
        private async void LocationTabTapped(object sender, EventArgs args)
        {
            var page = new MapLocationPage("Recruits");
            Navigation.InsertPageBefore(page, Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
            await Navigation.PopAsync();
        }
        private void NextButtonRecruitedClicked(object sender, EventArgs e)
        {
            _nextClickRecruited = _nextClickRecruited + 1;
            var viewmodel = (RecruitViewModel)this.BindingContext;
            var count = viewmodel.RecruitedListStaticList.Count;
            _skipRecruited = _skipRecruited + 10;
            var nextlist = viewmodel.RecruitedListStaticList.Skip(_skipRecruited);
            viewmodel.RecruitedList = nextlist.ToList();
        }
        private void PreviousButtonRecruitedClicked(object sender, EventArgs e)
        {
            var viewmodel = (RecruitViewModel)this.BindingContext;
            var count = viewmodel.RecruitedList.Count;
            _skipRecruited = _skipRecruited - 10;
            if(_nextClickRecruited == 1)
            {
                var prevList = viewmodel.RecruitedListStaticList.Take(10);
                viewmodel.RecruitedList = prevList.ToList();
            }
            else
            {
                var prevTake = 10 * _nextClickRecruited;
                var prevList = viewmodel.RecruitedListStaticList.Take(prevTake);
                prevList = prevList.Skip(10);
                viewmodel.RecruitedList = prevList.ToList();
            }
            _nextClickRecruited = _nextClickRecruited - 1;
        }
        private void NextButtonRecruitingClicked(object sender, EventArgs e)
        {
            _nextClickRecruiting = _nextClickRecruiting + 1;
            var viewmodel = (RecruitViewModel)this.BindingContext;
            var count = viewmodel.RecruitingListStaticList.Count;
            _skipRecruiting = _skipRecruiting + 10;
            var nextlist = viewmodel.RecruitingListStaticList.Skip(_skipRecruiting);
            viewmodel.RecruitingList = nextlist.ToList();
        }
        private void PreviousButtonRecruitingClicked(object sender, EventArgs e)
        {
            var viewmodel = (RecruitViewModel)this.BindingContext;
            var count = viewmodel.RecruitingList.Count;
            _skipRecruiting = _skipRecruiting - 10;
            if (_nextClickRecruiting == 1)
            {
                var prevList = viewmodel.RecruitingListStaticList.Take(10);
                viewmodel.RecruitingList = prevList.ToList();
            }
            else
            {
                var prevTake = 10 * _nextClickRecruiting;
                var prevList = viewmodel.RecruitingListStaticList.Take(prevTake);
                prevList = prevList.Skip(10);
                viewmodel.RecruitingList = prevList.ToList();
            }
            _nextClickRecruiting = _nextClickRecruiting - 1;
        }
        private void ShowRecruitingTab()
        {
            TabCustomButtonManager.SelectTab(RecruitingTab);
            TabCustomButtonManager.DeselectTab(RecruitedTab);
            TabCustomButtonManager.DeselectTab(LocationsTab);
            RecruitingTab.Icon = "target_icon_green";
            RecruitedTab.Icon = "hand_shake_gray";
            LocationsTab.Icon = "location_gray";

            RecruitingListView.IsVisible = true;
            RecruitedListView.IsVisible = false;
        }
        private void ShowRecruitedTab()
        {
            var viewmodel = (RecruitViewModel)this.BindingContext;
            TabCustomButtonManager.DeselectTab(RecruitingTab);
            TabCustomButtonManager.SelectTab(RecruitedTab);
            TabCustomButtonManager.DeselectTab(LocationsTab);
            RecruitingTab.Icon = "target_icon_gray";
            RecruitedTab.Icon = "hand_shake_green";
            LocationsTab.Icon = "location_gray";

            RecruitingListView.IsVisible = false;
            RecruitedListView.IsVisible = true;
            Global.SetRecAddNum(1);
            if(Global.GetRecNum() == 1){
                viewmodel.RecruitedData();
            }
        }
    }
}
