using Plugin.Connectivity;
using System;
using Umbrella.Helpers;
using Umbrella.Interfaces;
using Umbrella.Models;
using Umbrella.Services;
using Umbrella.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class ReferAndEarnPage : ContentPage
    {
        private string[] SelectionArray = { "Friend", "Colleague", "Family Member", "Someone Just Met", "Other" };
        private ReferralsService _referralService;
       
        public ReferAndEarnPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            _referralService = new ReferralsService();
            ReferButton.IsEnableButton = CrossConnectivity.Current.IsConnected;

            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                ReferButton.IsEnableButton = args.IsConnected ? true : false;
            };
                
            ReferButton.Clicked += new SingleClick(ReferNowClicked).Click;
            ShowReferAndEarn();
        }
        private void ReferAndEarnButtonTapped(object sender, EventArgs args)
        {
            ShowReferAndEarn();
        }
        private void PreviousReferralsButtonTapped(object sender, EventArgs args)
        {
            ShowPreviousReferrals();
        }
        private async void DropdownTapped(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet(Dropdown.Label, "Cancel", null, SelectionArray);
            if (!action.Equals("Cancel"))
            {
                Dropdown.Label = action;
                Dropdown.LabelColor = (Color) Application.Current.Resources["PrimaryTextColor"];
            }
        }
        private void EditorFocused(object sender, EventArgs e)
        {
            Editor.Focus();
            if (Editor.Text == "What you said so far")
            {
                Editor.Text = "";
                Editor.TextColor = (Color) Application.Current.Resources["PrimaryTextColor"];
            }
        }
        private void EditorUnfocused(object sender, EventArgs e)
        {
            Editor.Unfocus();
            if (Editor.Text == "")
            {
                Editor.Text = "What you said so far";
                Editor.TextColor = (Color) Application.Current.Resources["SecondaryTextColor"];
            }
        }
        private async void ReferralsItemTapped(object sender, ItemTappedEventArgs e)
        {
            var referral = e.Item as Referral;
            var page = new ReferralItemPage(referral);
            await Navigation.PushAsync(page);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ReferFooter.SetRewardLevelIcon(Global.GetrewardPoints());
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ReferAndEarnTab.BackgroundColor = Color.Default;
            if (ReferralsListView.SelectedItem == null)
            {
                return;
            }
            ReferralsListView.SelectedItem = null;
        }

        private async void ReferNowClicked(object sender, EventArgs e)
        {
            var page = new ReferAndEarnPage();
            if (EmailEntry.TextColor == Color.Red)
            {
                await DisplayAlert("Invalid Data", "Invalid Email Format", "OK");
            }
            else if(string.IsNullOrEmpty(FirstnameEntry.Text) || string.IsNullOrEmpty(LastnameEntry.Text) || string.IsNullOrEmpty(BusinessNameEntry.Text) || string.IsNullOrEmpty(EmailEntry.Text) ||
                string.IsNullOrEmpty(PhoneNumberEntry.Text) || string.IsNullOrEmpty(MobileNumberEntry.Text) || string.IsNullOrEmpty(Editor.Text) || string.IsNullOrEmpty(Dropdown.Label)
                || Editor.Text == "What you said so far" || Dropdown.Label == "Select...")
            {
                await DisplayAlert("Submission Failed", "Please fill up all the entry", "OK");
            }
            else
            {
                var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
                var contact_id = await DependencyService.Get<IOntraportContactIdRetriever>().GetOntraportContactId(credential.User.Email);
                var isSucess = await _referralService.SubmitOntraportContactApi(new OntraportContact()
                              {
                                Firstname = FirstnameEntry.Text,
                                Lastname = LastnameEntry.Text,
                                Company = BusinessNameEntry.Text,
                                Email = EmailEntry.Text,
                                OfficePhone = PhoneNumberEntry.Text,
                                CellPhone = MobileNumberEntry.Text,
                                Message = Editor.Text,
                                PhoneUsed = Device.RuntimePlatform == Device.Android ? 519 : 518,
                                Relationship = ConvertRelationshipToId(Dropdown.Label),
                                AccountUsed = contact_id,
                              });
                if (isSucess) {
                    await DisplayAlert("Success", "Submission Complete!", "OK");
                    await Navigation.PushAsync(page);
                }
                else
                {
                    await DisplayAlert("Failed", "Submission Failed!", "OK");
                }
            }
        }
        private void ShowReferAndEarn()
        {
            TabButtonManager.SelectTab(ReferAndEarnTab);
            TabButtonManager.DeselectTab(PreviousReferralsTab);
            ReferAndEarnTab.Icon = "refer_and_earn_red";
            PreviousReferralsTab.Icon = "previous_referrals";

            ReferAndEarnLayout.IsVisible = true;
            ReferralsListView.IsVisible = false;
        }
        private void ShowPreviousReferrals()
        {
            TabButtonManager.DeselectTab(ReferAndEarnTab);
            TabButtonManager.SelectTab(PreviousReferralsTab);
            ReferAndEarnTab.Icon = "refer_and_earn";
            PreviousReferralsTab.Icon = "previous_referrals_red";

            ReferAndEarnLayout.IsVisible = false;
            ReferralsListView.IsVisible = true;
        }
        private int ConvertRelationshipToId(string relationship)
        {
            switch (relationship)
            {
                case "Other":
                    return 1023;
                case "Family Member":
                    return 1024;
                case "Friend":
                    return 1025;
                case "Someone Just Met":
                    return 1026;
                case "Colleague":
                    return 1027;
                default:
                    return 0;
            }
        }
    }
}
