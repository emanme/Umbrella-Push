using System;
using Umbrella.Utilities;
using Umbrella.Views;
using Xamarin.Forms;

namespace Umbrella.Controls
{
    public partial class FooterView : ContentView
    {
        public FooterView()
        {
            InitializeComponent();
            
            if(Global.GetMessageCount() == 0)
            {
                BadgeMessage.Opacity = 0;
            }
            if (Global.GetrewardPoints() == 1)
            {
                RankTab.Icon = "rank1";
            }
            else if (Global.GetrewardPoints() == 2)
            {
                RankTab.Icon = "rank2";
            }
            else if (Global.GetrewardPoints() == 3)
            {
                RankTab.Icon = "rank3";
            }
            else if (Global.GetrewardPoints() == 4)
            {
                RankTab.Icon = "rank4";
            }
            else if (Global.GetrewardPoints() == 5)
            {
                RankTab.Icon = "rank5";
            }
            else if(Global.GetrewardPoints() == 0){
                RankTab.Icon = "rank1";
            }

        }
       
        public string BadgeCountMessage
        {
            get
            {
                return BadgeMessage.Text;
            }
            set
            {
                BadgeMessage.Text = value;
            }
        }
        public double BadgeVisibility
        {
            get
            {
                return BadgeMessage.Opacity;
            }
            set
            {
                BadgeMessage.Opacity = value;
            }
        }
       
        public void ActiveMedalPage(bool active)
        {
            if (active)
            {
                MedalsTab.Icon = "medal_footer_green";
                MedalsTab.LabelColor = Color.FromHex("#435742");
            }
            else
            {
                MedalsTab.Icon = "menu_medal";
                MedalsTab.LabelColor = Color.Gray;
            }
        }
        public void ActiveCalendar(bool active)
        {
            if (active)
            {
                CalendarTab.Icon = "calendar_footer_green";
                CalendarTab.LabelColor = Color.FromHex("#435742");
            }
            else
            {
                CalendarTab.Icon = "menu_calendar";
                CalendarTab.LabelColor = Color.Gray;
            }
        }
        public void ActiveCallback(bool active)
        {
            if (active)
            {
                CallBacksTab.Icon = "phone_footer_green";
                CallBacksTab.LabelColor = Color.FromHex("#435742");
            }
            else
            {
                CallBacksTab.Icon = "menu_callbacks";
                CallBacksTab.LabelColor = Color.Gray;
            }
        }
        public void ActiveMessages(bool active)
        {
            if (active)
            {
                MessagesTab.Icon = "messages_footer_green";
                MessagesTab.LabelColor = Color.FromHex("#435742");
            }
            else
            {
                MessagesTab.Icon = "menu_messages";
                MessagesTab.LabelColor = Color.Gray;
            }
        }
      
        public void ActiveRewardLevel(bool active, int currentRewardLevel)
        {
           // var current = Global.GetrewardPoints();
            if (active)
            {
                if (currentRewardLevel == 1)
                {
                    RankTab.Icon = "rank1_footer_green";
                }
                else if (currentRewardLevel == 2)
                {
                    RankTab.Icon = "rank2_footer_green";
                }
                else if (currentRewardLevel == 3)
                {
                    RankTab.Icon = "rank3_footer_green";
                }
                else if (currentRewardLevel == 4)
                {
                    RankTab.Icon = "rank4_footer_green";
                }
                else if (currentRewardLevel == 5)
                {
                    RankTab.Icon = "rank5_footer_green";
                }
                else if(currentRewardLevel == 0){
                    RankTab.Icon = "rank1_footer_green";
                }
                RankTab.LabelColor = Color.FromHex("#435742");
            }
            else
            {
                if (currentRewardLevel == 1)
                {
                    RankTab.Icon = "rank1";
                }
                else if (currentRewardLevel == 2)
                {
                    RankTab.Icon = "rank2";
                }
                else if (currentRewardLevel == 3)
                {
                    RankTab.Icon = "rank3";
                }
                else if (currentRewardLevel == 4)
                {
                    RankTab.Icon = "rank4";
                }
                else if (currentRewardLevel == 5)
                {
                    RankTab.Icon = "rank5";
                }
                else if (currentRewardLevel == 0)
                {
                    RankTab.Icon = "rank1";
                }
                RankTab.LabelColor = Color.Gray;
            }
        }
        public void SetRewardLevelIcon(int currentRewardLevel)
        {
            if (currentRewardLevel == 1)
            {
                RankTab.Icon = "rank1";
            }
            else if (currentRewardLevel == 2)
            {
                RankTab.Icon = "rank2";
            }
            else if (currentRewardLevel == 3)
            {
                RankTab.Icon = "rank3";
            }
            else if (currentRewardLevel == 4)
            {
                RankTab.Icon = "rank4";
            }
            else if (currentRewardLevel == 5)
            {
                RankTab.Icon = "rank5";
            }
            else{
                RankTab.Icon = "rank1";
            }
        }
        private async void RewardLevelButtonTapped(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PushAsync(new RewardLevelPage());
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Navigate Reward Excep " + ex.Message);
            }
        }

        private async void MessagesButtonTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MessagesPage());
        }

        private async void LeadsButtonTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new LeadsPage());
        }

        private async void CalendarButtonTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CalendarEventsPage());
        }

        private async void CallBacksButtonTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CallBacksPage());
        }

        private async void MedalsButtonTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MedalsPage());
        }
    }
}
