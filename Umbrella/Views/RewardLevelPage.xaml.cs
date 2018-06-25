using Plugin.Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbrella.Constants;
using Umbrella.Custom;
using Umbrella.DAL;
using Umbrella.Enums;
using Umbrella.Models;
using Umbrella.Utilities;
using Umbrella.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class RewardLevelPage : ContentPage
    {
        private int _currentRewardLevel;
        private Rank _currentRank;

        public RewardLevelPage()
        {
            try
            {
                InitializeComponent();
                NavigationPage.SetBackButtonTitle(this, "");

                BindingContext = new RewardLevelsViewModel();

                var viewModel = (BindingContext as RewardLevelsViewModel);
                var rewardLevelsList = viewModel.RewardLevels;
                _currentRank = viewModel.Rank == null ? new Rank() { Number = Global.GetrewardPoints(), Title = Global.GetRankTitle() } : viewModel.Rank;

                if (_currentRank.Number == 4 || _currentRank.Number == 3 || _currentRank.Number == 2){
                    whitePage.Padding = new Thickness(0, 0, 0, 25);
                }else{
                    whitePage.Padding = new Thickness(0, 0, 0, 15);
                }
                //_currentRewardLevel = (int)DataAccess.RewardLevelRepository.Current;
                //_currentRewardLevel = Global.GetrewardPoints();

                var getRewards = rewardLevelsList.SingleOrDefault(x => x.Level == _currentRank.Number);
                if (getRewards != null)
                {
                    var currentRewards = getRewards.Rewards.ToList();
                    var nextRewards = new List<string>();
                    if (_currentRank.Number < (int)RewardLevelValue.LevelFive)
                    {
                        var getnextRewards = rewardLevelsList.SingleOrDefault(x => x.Level == _currentRank.Number + 1);

                        if (getnextRewards != null)
                        {
                            nextRewards = getnextRewards.Rewards.ToList();
                        }
                        if (!RequirementsLayout.IsVisible)
                        {
                            RequirementsLayout.IsVisible = true;
                        }
                        if (!MoreButton.IsVisible)
                        {
                            MoreButton.IsVisible = true;
                        }
                    }
                    else
                    {
                        RequirementsLayout.IsVisible = false;
                        MoreButton.IsVisible = false;
                    }

                    for (int i = 0; i < currentRewards.Count; i++)
                    {
                        var item = currentRewards[i];
                        var check = i;
                        var checkLabel = new FontAwesomeLabel
                        {
                            Text = FontIcon.CHECK,
                            FontFamily = "FontAwesome",
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start,
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Start,
                            TextColor = (Color)Application.Current.Resources["MainGreenColor"],
                            FontSize = (double)Application.Current.Resources["LabelFontSize"]
                        };
                        var itemLabel = new Label
                        {
                            Text = item,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start,
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Start,
                            FontSize = (double)Application.Current.Resources["TextFontSize"],
                            TextColor = Color.Black
                        };
                        var currentRewardsLayout = new Grid();
                        currentRewardsLayout.Padding = new Thickness(3);
                        currentRewardsLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                        currentRewardsLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                        currentRewardsLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                        if(currentRewards.Count > 4){
                            if (check > 2)
                            {
                                currentRewardsLayout.Children.Add(checkLabel, 0, 0);
                                currentRewardsLayout.Children.Add(itemLabel, 1, 0);
                                CurrentRewardsList.Children.Add(currentRewardsLayout);
                            }
                            else
                            {
                                currentRewardsLayout.Children.Add(checkLabel, 0, 0);
                                currentRewardsLayout.Children.Add(itemLabel, 1, 0);
                                CurrentExcessRewardsList.Children.Add(currentRewardsLayout);
                            }
                        }
                        else{
                            currentRewardsLayout.Children.Add(checkLabel, 0, 0);
                            currentRewardsLayout.Children.Add(itemLabel, 1, 0);
                            CurrentRewardsList.Children.Add(currentRewardsLayout);
                        }
                    }

                    for (int i = 0; i < nextRewards.Count; i++)
                    {
                        var item = nextRewards[i];
                        var check = i;
                        var checkLabel = new FontAwesomeLabel
                        {
                            Text = FontIcon.CHECK,
                            FontFamily = "FontAwesome",
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start,
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Start,
                            TextColor = (Color)Application.Current.Resources["MainGreenColor"],
                            FontSize = (double)Application.Current.Resources["LabelFontSize"]
                        };
                        var itemLabel = new Label
                        {
                            Text = item,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start,
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Start,
                            FontSize = (double)Application.Current.Resources["TextFontSize"],
                            TextColor = Color.Black
                        };
                        var nextRewardsLayout = new Grid();
                        nextRewardsLayout.Padding = new Thickness(3);
                        nextRewardsLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                        nextRewardsLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                        nextRewardsLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                        if(nextRewards.Count > 4){
                            if (check > 2)
                            {
                                nextRewardsLayout.Children.Add(checkLabel, 0, 0);
                                nextRewardsLayout.Children.Add(itemLabel, 1, 0);
                                NextRewardsList.Children.Add(nextRewardsLayout);
                            }
                            else
                            {
                                nextRewardsLayout.Children.Add(checkLabel, 0, 0);
                                nextRewardsLayout.Children.Add(itemLabel, 1, 0);
                                NextExcessRewardsList.Children.Add(nextRewardsLayout);
                            }
                        }
                        else{
                            nextRewardsLayout.Children.Add(checkLabel, 0, 0);
                            nextRewardsLayout.Children.Add(itemLabel, 1, 0);
                            NextRewardsList.Children.Add(nextRewardsLayout);
                        }
                     
                    }

                    CurrentLevelLabel.Text = $"AS A {_currentRank.Title.ToUpper()} YOU RECEIVE";
                    CurrentLevelImage.Source = $"war{_currentRank.Number}";

                    NextLevelLabel.Text = $"BECOME A {GetNextRank(_currentRank.Number)} AND RECEIVE";
                    NextLevelImage.Source = $"ar{_currentRank.Number + 1}";

                    //    MoreButton.Text = $"MORE ON LEVEL {_currentRewardLevel + 1}";
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error RewardLevelPage:" + e.ToString());
            }
            HandleReceivedMessages();
        }

        private async void OnBackButtonTapped(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        private string GetNextRank(int currentRank)
        {
            string nextRank = string.Empty;

            if (currentRank == (int)RanksEnum.Private)
                nextRank = "CORPORAL";

            if (currentRank == (int)RanksEnum.Corporal)
                nextRank = "OFFICER";

            if (currentRank == (int)RanksEnum.Officer)
                nextRank = "SERGEANT";

            if (currentRank == (int)RanksEnum.Sergeant)
                nextRank = "LIEUTENANT";

            return nextRank;
        }
        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessages>(this, "TickedMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    RewardLevelFooter.BadgeVisibility = 1;
                    var notifList = Global.GetAllTopic();
                    var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();
                    RewardLevelFooter.BadgeCountMessage = currentMessageCount.ToString();
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
                RewardLevelFooter.BadgeVisibility = 0;
            }
            else
            {
                RewardLevelFooter.BadgeVisibility = 1;
                RewardLevelFooter.BadgeCountMessage = currentMessageCount.ToString();
            }
            RewardLevelFooter.ActiveRewardLevel(true, _currentRank.Number);
            //RewardLevelFooter.SetRewardLevelIcon(_currentRank.Number);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            RewardLevelFooter.ActiveRewardLevel(false, _currentRank.Number);
        }

        private async void MoreClicked(object sender, EventArgs args)
        {
            var page = new RewardLevelItemPage(_currentRank.Number + 1);
            await Navigation.PushAsync(page);
        }
    }
}
