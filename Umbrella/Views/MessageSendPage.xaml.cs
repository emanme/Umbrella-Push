using System;
using Umbrella.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class MessageSendPage : ContentPage
    {
        private string[] SelectionArray = { "Business Growth Executive", "Technical Support",
            "Sales Support", "Accounts Department", "Complaints Department", "Other" };

        public MessageSendPage()
        {
            InitializeComponent();
            Title = "New Message";

            ToLabel.IsVisible = false;
            SubjectLabel.IsVisible = false;
        }

        public MessageSendPage(Message message)
        {
            InitializeComponent();
            Title = "Reply Message";

            BindingContext = message;
            Dropdown.IsVisible = false;
            SubjectLabel.Text = $"Reply: {message.Subject}";
            SubjectEntry.IsVisible = false;
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
            if (Editor.Text == "Write here...")
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
                Editor.Text = "Write here...";
                Editor.TextColor = (Color) Application.Current.Resources["SecondaryTextColor"];
            }
        }

        private async void SendNowClicked(object sender, System.EventArgs e)
        {
            var page = new MessageSendPage();
            await Navigation.PushAsync(page);
        }
    }
}
