using System;
using System.Linq;
using Umbrella.Interfaces;
using Umbrella.Models;
using Umbrella.Utilities;
using Xamarin.Forms;

namespace Umbrella.Views
{
    public partial class LoyaltyPage : ContentPage
    {
        public LoyaltyPage()
        {
            InitializeComponent();
            HandleReceivedMessages();
            NavigationPage.SetBackButtonTitle(this, "");
            LoyaltyCardFooter.SetRewardLevelIcon(Global.GetrewardPoints());
            var ver = DependencyService.Get<IDeviceChecker>().GetDeviceVersion();
            System.Diagnostics.Debug.WriteLine("ver" + ver);
            if (ver == 5)
            {
                rotateLayout.Margin = new Thickness(20, 10, 10, 10);
                rotateLayout.HeightRequest = 700;
                spendPointsLayout.Padding = new Thickness(20, 0, 20, 10);
            }
            else if (ver == 6)
            {
                rotateLayout.Margin = new Thickness(40, 50, 10, 10);
                rotateLayout.HeightRequest = 1000;
                spendPointsLayout.Padding = new Thickness(20, 30, 20, 10);
            }
            else if (ver == 61)
            {
                rotateLayout.Margin = new Thickness(20, 70, 10, 10);
                spendPointsLayout.Padding = new Thickness(20,70,20,0);
            }
        }
        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessages>(this, "TickedMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    LoyaltyCardFooter.BadgeVisibility = 1;
                    var notifList = Global.GetAllTopic();
                    var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();
                    LoyaltyCardFooter.BadgeCountMessage = currentMessageCount.ToString();
                });
            });
        }
        private void SpendUmbrellaPointsClicked(object sender, EventArgs args)
        {
            Device.OpenUri(new Uri("https://www.umbrellasupport.co.uk/spend-loyalty-card-points/"));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadLoyaltyPointAsync();
            var notifList = Global.GetAllTopic();
            var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();

            if (currentMessageCount <= 0)
            {
                LoyaltyCardFooter.BadgeVisibility = 0;
            }
            else
            {
                LoyaltyCardFooter.BadgeVisibility = 1;
                LoyaltyCardFooter.BadgeCountMessage = currentMessageCount.ToString();
            }
            LoyaltyCardFooter.SetRewardLevelIcon(Global.GetrewardPoints());
        }
        protected override void OnDisappearing(){
            base.OnAppearing();
           
        }
        private void LoadLoyaltyPointAsync()
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var loyalty = Global.GetLoyalty();
            if (loyalty == null)
            {
                loyalty = new Loyalty();
            }
            lblLoyaltyPoints.Text = loyalty.Points;
            lblPartnerID.Text = loyalty.PartnerId;
            lblPackage.Text = loyalty.PackageLevel;
            fullnameText.Text = loyalty.Fullname;
            if (loyalty.Barcode == "")
            {
                loyalty.Barcode = "0 77456 049283";
            }
            //imgbarcode.Source = string.IsNullOrEmpty(loyalty.barcode_url) ? "barcode_image.png" : loyalty.barcode_url;
            imgbarcode.Source = loyalty.BarcodeUrl;
            lblbarcode.Text = loyalty.Barcode;
        }

    }
}
