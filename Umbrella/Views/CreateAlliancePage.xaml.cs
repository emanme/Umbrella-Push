using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Umbrella.Helpers;
using Umbrella.Interfaces;
using Umbrella.Models;
using Umbrella.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
	public partial class CreateAlliancePage : ContentPage
	{
        private string[] SelectionArray = { "Friend", "Colleague", "Family Member", "Someone Just Met", "Other" };
        private string[] SelectionInterest = { "Umbrella Support (General)", "Live Call Answering", "Live 121 Web Chat",
            "Business Softphone", "Buying & Selling Leads" ,"BookPhoneCall.com","Managed Mail Service"};
        private ReferralsService _referralService;
        public CreateAlliancePage ()
		{
			InitializeComponent ();
            _referralService = new ReferralsService();
            ReferButton.IsEnableButton = CrossConnectivity.Current.IsConnected;
            var ver = DependencyService.Get<IDeviceChecker>().GetDeviceVersion();
            System.Diagnostics.Debug.WriteLine("ver" + ver);
            if (ver == 5)
            {
                dropLayout.WidthRequest = 78;
            }
            else if (ver == 6)
            {
                dropLayout.WidthRequest = 77.5;
            }
            else if (ver == 61)
            {
                dropLayout.WidthRequest = 77.5;
            }
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                ReferButton.IsEnableButton = args.IsConnected ? true : false;
            };

            ReferButton.Clicked += new SingleClick(ReferNowClicked).Click;
		}
        private async void DropdownTappedInterest(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet(DropdownInterest.Label, "Cancel", null, SelectionInterest);
            if (!action.Equals("Cancel"))
            {
                DropdownInterest.Label = action;
                DropdownInterest.LabelColor = (Color)Application.Current.Resources["PrimaryTextColor"];
            }
        }
        private async void DropdownTapped(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet(Dropdown.Label, "Cancel", null, SelectionArray);
            if (!action.Equals("Cancel"))
            {
                Dropdown.Label = action;
                Dropdown.LabelColor = (Color)Application.Current.Resources["PrimaryTextColor"];
            }
        }
        private void EditorFocused(object sender, EventArgs e)
        {
            Editor.Focus();
            if (Editor.Text == "What have you told them so far? Why do you think this organisation would be a great ally?")
            {
                Editor.Text = "";
                Editor.TextColor = (Color)Application.Current.Resources["PrimaryTextColor"];
            }
        }
        private void EditorUnfocused(object sender, EventArgs e)
        {
            Editor.Unfocus();
            if (Editor.Text == "")
            {
                Editor.Text = "What have you told them so far? Why do you think this organisation would be a great ally?";
                Editor.TextColor = (Color)Application.Current.Resources["SecondaryTextColor"];
            }
        }
        private async void ReferNowClicked(object sender, EventArgs e)
        {
            var page = new ComradesArmoryPage();
            if (EmailEntry.TextColor == Color.Red)
            {
                await DisplayAlert("Invalid Data", "Invalid Email Format", "OK");
            }
            else if (string.IsNullOrEmpty(FirstnameEntry.Text) || string.IsNullOrEmpty(LastnameEntry.Text) || string.IsNullOrEmpty(BusinessNameEntry.Text) || string.IsNullOrEmpty(EmailEntry.Text) ||
                string.IsNullOrEmpty(PhoneNumberEntry.Text) || string.IsNullOrEmpty(MobileNumberEntry.Text) || string.IsNullOrEmpty(Editor.Text) || string.IsNullOrEmpty(Dropdown.Label)
                     || Editor.Text == "What have you told them so far? Why do you think this organisation would be a great ally?" || Dropdown.Label == "Select...")
            {
                await DisplayAlert("Submission Failed", "Please fill up all the entry", "OK");
            }
            else
            {
                var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
                var contact_id = await DependencyService.Get<IOntraportContactIdRetriever>().GetOntraportContactId(credential.User.Email);
                var isSucess = await _referralService.SubmitOntraportContactApiArmy(new OntraportContactArmy()
                {
                    Firstname = FirstnameEntry.Text,
                    Lastname = LastnameEntry.Text,
                    Company = BusinessNameEntry.Text,
                    Email = EmailEntry.Text,
                    OfficePhone = PhoneNumberEntry.Text,
                    CellPhone = MobileNumberEntry.Text,
                    Message = Editor.Text,
                    LeadInfo = ConvertLeadToId(DropdownInterest.Label),
                    ReferralPage = "Allies Armory",
                    PhoneUsed = Device.RuntimePlatform == Device.Android ? 522 : 521,
                    Relationship = ConvertRelationshipToId(Dropdown.Label),
                    AccountUsed = contact_id,
                });
                if (isSucess)
                {
                    await DisplayAlert("Success", "Submission Complete!", "OK");
                    await Navigation.PushAsync(page);
                }
                else
                {
                    await DisplayAlert("Failed", "Submission Failed!", "OK");
                }
            }

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
        private int ConvertLeadToId(string relationship)
        {
            switch (relationship)
            {
                case "Umbrella Support (General)":
                    return 1048;
                case "Live Call Answering":
                    return 1049;
                case "Live 121 Web Chat":
                    return 1050;
                case "Business Softphone":
                    return 1051;
                case "Buying & Selling Leads":
                    return 1052;
                case "BookPhoneCall.com":
                    return 1053;
                case "Managed Mail Service":
                    return 1054;
                default:
                    return 0;
            }
        }
    }
}