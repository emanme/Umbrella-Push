using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Umbrella.Services;
using Newtonsoft.Json.Linq;
using Umbrella.Controls;
using Umbrella.Utilities;
using System.Threading.Tasks;
using Umbrella.RestClient;
using Umbrella.Models;
using Umbrella.Constants;
using Umbrella.Interfaces;

namespace Umbrella.Views  
                  
{
    public partial class LoyaltyCardPage : ContentPage
    {
        private UserClientService _userClientService;
        public LoyaltyCardPage()
        {
            InitializeComponent();

            _userClientService = new UserClientService();
           // UpdateData();


        }
        protected override void OnAppearing()
        {
            LoadLoyaltyPointAsync();
            base.OnAppearing();

        }

        private void LoadLoyaltyPointAsync( )
        {
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            var loyalty = Global.GetLoyalty();// await Helpers.APIHelper.GetLoyaltyAsync();
            if(loyalty==null){
                loyalty = new Loyalty();
            }
           // ViewModels. LeadUpdate(loyalty);
          //  System.Diagnostics.Debug.WriteLine("loyalty " + loyalty.Name);
        }

        private void SpendUmbrellaPointsClicked(object sender, EventArgs args)
        {

        }
        
        private async Task PopulateLoyaltyPointAsync()
        {
            // var g = new Global();

            var ls = new LoginJson();
            //  Task.Run(() => _authenticationService.AuthenticateUser(username, password));
             ls = await Task.Run(() => _userClientService.GetLoyatyData(Global.GetUserId()));

            //  bar.imgbarcode = "business_growth_executive_red.png";
            // var renderer = Platform.CreateRenderer(TopBarPage.SelectedPage);
            //  Image e = Umbrella.Controls.BarcodeImage;
            // bar.setBarcode("business_growth_executive_red.png");
            // var obj = JObject.Parse(rest.Content);
            System.Diagnostics.Debug.WriteLine("Back barcode " + ls.barcode);
            System.Diagnostics.Debug.WriteLine("Back points " + ls.points);
            Global.SetLoyaltyPoints(ls.points); 
            Global.SetBarCodeString(ls.barcode); 
            System.Diagnostics.Debug.WriteLine("Global barcode " + Global.GetBarCodeString());
            System.Diagnostics.Debug.WriteLine("Global points " + Global.GetLoyaltyPoints());
             
              

           // await lblLoyaltyPoints.Text = ls.points;
           imgbarcode.Source =Global.GetBarCodeString();
            System.Diagnostics.Debug.WriteLine("lblLoyaltyPoints " + lblLoyaltyPoints.Text);
            System.Diagnostics.Debug.WriteLine("imgbarcode.Source " + imgbarcode.Source);
           //imgbarcode.source = "";
           //imgbarcode.//imgbarcode.
           //            Global.SetBarCodeString( "business_growth_executive_red.png");
           // BarcodeImage.*
        }


    }
}
