using System;
using System.Linq;
using Umbrella.Constants;
using Umbrella.Custom;
using Umbrella.Enums;
using Umbrella.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class RewardLevelItemPage : ContentPage
    {
        private int _rankLevel;
        public RewardLevelItemPage(int rankLevel)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            _rankLevel = rankLevel;
            ShowLevelDetails(rankLevel);
        }

        private void BackClicked(object sender, EventArgs args)
        {
            if (_rankLevel == (int) RewardLevelValue.LevelOne)
            {
                _rankLevel = 6;
            }
            ShowLevelDetails(_rankLevel -= 1);
        }

        private void NextClicked(object sender, EventArgs args)
        {
            if (_rankLevel == (int) RewardLevelValue.LevelFive)
            {
                _rankLevel = 0;
            }
            
            ShowLevelDetails(_rankLevel += 1);
        }

        private void ShowLevelDetails(int level)
        {
            //var current = new StackLayout();
            //current.HorizontalOptions = LayoutOptions.Start;
            //current.Orientation = StackOrientation.Vertical;
            //whitePage.Children.Add(current);

            CurrentGrid.Children.Clear();
            RewardsList.Children.Clear();
            RequirementsList.Children.Clear();


            var rewardLevels = (BindingContext as RewardLevelsViewModel).RewardLevels;
            var rewards = rewardLevels.SingleOrDefault(x => x.Level == level).Rewards;
            var requirements = rewardLevels.SingleOrDefault(x => x.Level == level).Requirements;

            if (level == 4 || level == 3 || level == 2)
            {
                whitePage.Padding = new Thickness(0, 0, 0, 25);
            }
            else
            {
                whitePage.Padding = new Thickness(0, 0, 0, 0);
            }

            for (int i = 0; i < rewards.Count; i++)
            {
                var item = rewards[i];
                var check = i;
                var checkLabel = new FontAwesomeLabel
                {
                    Text = FontIcon.CHECK,
                    FontFamily = "FontAwesome",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                    TextColor = (Color) Application.Current.Resources["MainGreenColor"],
                    FontSize = (double) Application.Current.Resources["LabelFontSize"]
                };
                var itemLabel = new Label
                {
                    Text = item,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                    FontSize = (double) Application.Current.Resources["TextFontSize"],
                    TextColor = Color.Black
                };
                var currentRewardsLayout = new Grid();
                currentRewardsLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                currentRewardsLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                currentRewardsLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                if (rewards.Count > 4)
                {
                    if (check > 2)
                    {
                        currentRewardsLayout.Padding = new Thickness(3);
                        currentRewardsLayout.Children.Add(checkLabel, 0, 0);
                        currentRewardsLayout.Children.Add(itemLabel, 1, 0);
                        RewardsList.Children.Add(currentRewardsLayout);
                    }
                    else
                    {
                        currentRewardsLayout.Padding = new Thickness(15,3,15,0);
                        currentRewardsLayout.Children.Add(checkLabel, 0, 0);
                        currentRewardsLayout.Children.Add(itemLabel, 1, 0);
                        try
                        {
                            CurrentGrid.Children.Add(currentRewardsLayout);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("ex" + ex.InnerException + " " + ex.Message);
                        }
                    }
                }
                else
                {
                    currentRewardsLayout.Children.Add(checkLabel, 0, 0);
                    currentRewardsLayout.Children.Add(itemLabel, 1, 0);
                    RewardsList.Children.Add(currentRewardsLayout);
                }
             
            }

            for (int i = 0; i < requirements.Count; i++)
            {
                var item = requirements[i];
                var circleLabel = new FontAwesomeLabel
                {
                    Text = FontIcon.CIRCLE,
                    FontFamily = "FontAwesome",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                    TextColor = (Color) Application.Current.Resources["MainBlackColor"],
                    FontSize = (double) Application.Current.Resources["BulletIconFontSize"]
                };
                var itemLabel = new Label
                {
                    Text = item,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                    FontSize = (double) Application.Current.Resources["TextFontSize"],
                    TextColor = Color.Black
                };
                var requirementsLayout = new Grid();
                requirementsLayout.Padding = new Thickness(3);
                requirementsLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                requirementsLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                requirementsLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                requirementsLayout.Children.Add(circleLabel, 0, 0);
                requirementsLayout.Children.Add(itemLabel, 1, 0);
                RequirementsList.Children.Add(requirementsLayout);
            }

            CurrentLevelLabel.Text = $"LEVEL {level} REWARDS";
            this.Title = CurrentLevelLabel.Text;
            CurrentLevelImage.Source = $"ar{level}";

            if (level == (int) RewardLevelValue.LevelOne)
            {
                BackButton.Text = "LEVEL 5";
            }
            else
            {
                BackButton.Text = $"LEVEL {level - 1}";
            }

            if (level == (int) RewardLevelValue.LevelFive)
            {
                NextButton.Text = "LEVEL 1";
            }
            else
            {
                NextButton.Text = $"LEVEL {level + 1}";
            }
            if(level == 5){
                System.Diagnostics.Debug.WriteLine(" level" + level);
              //  _nextButtonIsVisible = false;
              //  NextButton.IsEnableButton = false;
            }

        }
    }
}
