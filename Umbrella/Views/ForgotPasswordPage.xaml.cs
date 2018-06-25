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
    public partial class ForgotPasswordPage : ContentPage
    {
        private BasicAccountServices _basicAccntService;
        public ForgotPasswordPage()
        {
            InitializeComponent();
            submitButton.Clicked += new SingleClick(SubmitClicked).Click;
            _basicAccntService = new BasicAccountServices();
            submitButton.IsEnableButton = CrossConnectivity.Current.IsConnected;

            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                submitButton.IsEnableButton = args.IsConnected ? true : false;
            };

        }

        private async void SubmitClicked(object sender, EventArgs e)
        {
            // TODO
            if (!string.IsNullOrEmpty(EmailEntry.Text))
            {
                var contactId = await DependencyService.Get<IOntraportContactIdRetriever>().GetOntraportContactId(EmailEntry.Text);
                if (string.IsNullOrEmpty(contactId))
                {
                    await _basicAccntService.CreateUserOntraport(EmailEntry.Text);
                    var contactnewId = await DependencyService.Get<IOntraportContactIdRetriever>().GetOntraportContactId(EmailEntry.Text);
                    var isSuccess = await _basicAccntService.ForgetPasswordService(contactnewId);
                    if (isSuccess)
                    {
                        await DisplayAlert("Success!", "Please check your email for your password.", "OK");
                        EmailEntry.Text = "";
                        await Navigation.PopToRootAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error!", "Forgot Password Failed", "OK");
                    }
                }
                else
                {
                    var isSuccess = await _basicAccntService.ForgetPasswordService(contactId);
                    if (isSuccess)
                    {
                        await DisplayAlert("Success!", "Please check your email for your password.", "OK");
                        EmailEntry.Text = "";
                        await Navigation.PopToRootAsync();

                    }
                    else
                    {
                        await DisplayAlert("Error!", "Forgot Password Failed", "OK");

                    }
                }

            }
            else if (string.IsNullOrEmpty(EmailEntry.Text) || EmailEntry.TextColor == Color.Red)
            {
                await DisplayAlert("Invalid data", "Email is invalid.", "OK");
            }
        }
    }
}