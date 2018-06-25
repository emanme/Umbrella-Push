using System;
using Umbrella.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class MessageItemPage : ContentPage
    {
        private Message _message;

        public MessageItemPage(Message message)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");

            _message = message;
            BindingContext = message;
        }

        private void DownloadAttachmentClicked(object sender, EventArgs e)
        {
            // TODO
        }

        private async void ReplyNowClicked(object sender, EventArgs e)
        {
            var page = new MessageSendPage(_message);
            await Navigation.PushAsync(page);
        }

        private async void NewMessageClicked(object sender, EventArgs e)
        {
            var page = new MessageSendPage();
            await Navigation.PushAsync(page);
        }
    }
}
