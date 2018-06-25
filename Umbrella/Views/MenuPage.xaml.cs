using System;
using Umbrella.Controls;
using Umbrella.DAL;
using Umbrella.Enums;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class MenuPage : StillTabbedPage
    {
        public MenuPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");

            var current = DataAccess.RewardLevelRepository.Current;
            if (current == RewardLevelValue.LevelOne)
            {
                RewardLevelTab.Icon = "reward_lvl_1_tab_icon";
            }
            else if (current == RewardLevelValue.LevelTwo)
            {
                RewardLevelTab.Icon = "reward_lvl_2_tab_icon";
            }
            else if (current == RewardLevelValue.LevelThree)
            {
                RewardLevelTab.Icon = "reward_lvl_3_tab_icon";
            }
            else if (current == RewardLevelValue.LevelFour)
            {
                RewardLevelTab.Icon = "reward_lvl_4_tab_icon";
            }
            else if (current == RewardLevelValue.LevelFive)
            {
                RewardLevelTab.Icon = "reward_lvl_5_tab_icon";
            }
        }

        private async void TopupButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new TopupPage());
        }

        private async void SettingsButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}
