using System;
using System.Threading.Tasks;
using Umbrella.Enums;
using Umbrella.Helpers;
using Umbrella.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class LeadsItemPage : ContentPage
    {
        private Lead _lead;

        public LeadsItemPage(Lead lead)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");

            _lead = lead;
            BindingContext = lead;
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

        private async void YourNotesClicked(object sender, EventArgs e)
        {
            var page = new YourNotes();
            await Navigation.PushAsync(page);
        }

        private async void AgentsNotesClicked(object sender, EventArgs e)
        {
            var page = new AgentsNotes();
            await Navigation.PushAsync(page);
        }

        private async void MarkAsConvertedClicked(object sender, EventArgs e)
        {
            StartBusyIndicator();
            APIHelper2 a = new APIHelper2();
            var type = LeadsActionType.MarkAsConverted;
            var result = await Task.Run(() => a.ActionsButton(type, _lead.ContactId));
            StopBusyIndicator();
            DisplayAlert("Success",result,"Ok");
        }

        private async void SellEnquiryClicked(object sender, EventArgs e)
        {
            StartBusyIndicator();
            APIHelper2 a = new APIHelper2();
            var type = LeadsActionType.SellEnquiry;
            var result = await Task.Run(() => a.ActionsButton(type, _lead.ContactId));
            StopBusyIndicator();
            DisplayAlert("Success", result, "Ok");
        }

        private async void UnconvertibleClicked(object sender, EventArgs e)
        {
            StartBusyIndicator();
            APIHelper2 a = new APIHelper2();
            var type = LeadsActionType.Unconvertible;
            var result = await Task.Run(() => a.ActionsButton(type, _lead.ContactId));
            StopBusyIndicator();
            DisplayAlert("Success", result, "Ok");
        }

        private   async void BookCallBackClicked(object sender, EventArgs e)
        {
            var page = new CallBacksSchedulePage(_lead);
            await Navigation.PushAsync(page);
        }

        private async void AssignTaskClicked(object sender, EventArgs e)
        {
            var page = new AssignTaskPage();
            await Navigation.PushAsync(page);
        }

        private void AddNotesClicked(object sender, EventArgs e)
        {
            // TODO
        }
        private void  StartBusyIndicator()
        {
            BusyIndicator.IsVisible = true;
            Indicator.IsBusy = true;
              
        }

        private void StopBusyIndicator()
        {
            BusyIndicator.IsVisible = false;
            Indicator.IsBusy = false;
        }     

    }
}
