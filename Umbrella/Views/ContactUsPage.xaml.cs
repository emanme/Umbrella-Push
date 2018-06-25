using Plugin.Connectivity;
using System;
using System.Net.Http;
using System.Text;
using Umbrella.Constants;
using Umbrella.Helpers;
using Umbrella.Interfaces;
using Umbrella.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class ContactUsPage : ContentPage
    {
        private BasicAccountServices _basicAccntService;
        private string[] SelectionArray = { "Business Growth Executive", "Technical Support",
            "Sales Team", "Accounts Department", "Complaints Department", "Other" };

        public ContactUsPage()
        {
            InitializeComponent();
            contactButton.Clicked += new SingleClick(SendMessageClicked).Click;
            contactButton.IsEnabled = CrossConnectivity.Current.IsConnected;

            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                contactButton.IsEnabled = args.IsConnected ? true : false;
            };

            _basicAccntService = new BasicAccountServices();
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
            if (Editor.Text == "Enter your question here")
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
                Editor.Text = "Enter your question here";
                Editor.TextColor = (Color) Application.Current.Resources["SecondaryTextColor"];
            }
        }

        private async void SendMessageClicked(object sender, EventArgs e)
        {
            // TODO
            if(string.IsNullOrEmpty(Dropdown.Label) || string.IsNullOrEmpty(Editor.Text) || Dropdown.Label == "Select..." || Editor.Text == "Enter your question here")
            {
                await DisplayAlert("Information", "Please fill up all the entry", "OK");
            }
            else
            {
                var page = new ContactUsPage();
                var credentials = DependencyService.Get<ICredentialRetriever>().GetCredential();
                var isSuccess = await _basicAccntService.SyncEnquiryTypeOntraport(ConvertEnquiryToId(Dropdown.Label), Editor.Text, credentials.User.Email);
                if (isSuccess)
                {
                    await DisplayAlert("Message Sent!", "We will be in touch soon.", "OK");
                    await Navigation.PushAsync(page);
                }
                else
                {
                    await DisplayAlert("Message Sending Failed!", "Message Sending Failed", "OK");
                }
            }
        }
        private int ConvertEnquiryToId(string enquiry)
        {
            switch (enquiry)
            {
                case "Other":
                    return 1035;
                case "Complaints Department":
                    return 1036;
                case "Accounts Department":
                    return 1037;
                case "Sales Team":
                    return 1038;
                case "Technical Support":
                    return 1039;
                case "Business Growth Executive":
                    return 1040;
                default:
                    return 0;
            }
        }

    }
}
