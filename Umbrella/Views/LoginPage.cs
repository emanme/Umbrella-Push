using System;
using System.Threading.Tasks;
using Umbrella.DAL;
using Umbrella.Enums;
using Umbrella.Interfaces;
using Umbrella.Models;
using Umbrella.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using Umbrella.Utilities;
using Umbrella.ViewModels;
using Plugin.Connectivity;
using System.Collections.Generic;
using System.Linq;

namespace Umbrella.Views
{
    public partial class LoginPage : ContentPage
    {
        private AuthenticationService _authenticationService;

        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");

            _authenticationService = new AuthenticationService();

         CheckCredential();
        }

        private async void LoginClicked(object sender, EventArgs e)
        {
            
           
            StartBusyIndicator();
            
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

        

            var result= await Task.Run(() => _authenticationService.AuthenticateUser(username, password));
          
          
            
            if (result.Status == AuthenticationStatus.CredentialsRequired)
            {
                StopBusyIndicator();
                await DisplayAlert("Oops!", "Please enter your username and password.", "OK");
            }
            else if (result.Status == AuthenticationStatus.ServerError)
            {
                StopBusyIndicator();
                await DisplayAlert("Oops!", "Problem with the server, please try again later.", "OK");
            }

            else if (result.Status == AuthenticationStatus.AuthenticationFailed)
            {
                StopBusyIndicator();
                await DisplayAlert("Login Failed!", "Unable to login, either username or password is incorrect.", "OK");
            }
            else
            {

                SaveUserData(result.User, password);
                StopBusyIndicator();
                var page = new HomePage();
                LoadLeadsAsync();
                await Navigation.PushModalAsync(new NavigationPage(page));
            }
        }

        private async void ForgotPasswordTapped(object sender, EventArgs e)
        {
            try{
                var page = new ForgotPasswordPage();
                await Navigation.PushAsync(page);
            }
            catch(Exception ex){
                System.Diagnostics.Debug.WriteLine("exception " + ex.Message + " " + ex.InnerException);
            }
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

        private async void CheckCredential()
        {
            try
            {
            //StartBusyIndicator();
            // Login user automatically if a credential is already saved
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            //var user =  DependencyService.Get<ICredentialRetriever>().GetCredential().User;
 
                if (credential != null)
                {
                    var page = new HomePage();
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        LoadLeadsAsync();
                        if(string.IsNullOrEmpty(Global.GetLoyalty().BarcodeUrl)){
                            var loyalty = new List<Loyalty>();
                            loyalty = await App.LoyaltyDatabase.GetItemsAsync();
                            Global.SetLoyalty(loyalty.FirstOrDefault());
                        }
                        if (string.IsNullOrEmpty(Global.GetRankTitle()) || Global.GetrewardPoints() == 0)
                        {
                            var rank = new List<Rank>();
                            rank = await App.RankDatabase.GetItemsAsync();
                            Global.SetRankTitle(rank.FirstOrDefault().Title);
                            Global.SetrewardPoints(rank.FirstOrDefault().Number);
                        }
                        if(Global.GetMedalList().Count() == 0){
                            var medals = new List<Medal>();
                            medals = await App.MedalDatabase.GetItemsAsync();
                            Global.SetMedalList(medals);
                        }
                    }
                    else{

                        var rank = new List<Rank>();
                        rank = await App.RankDatabase.GetItemsAsync();
                        Global.SetRankTitle(rank.FirstOrDefault().Title);
                        Global.SetrewardPoints(rank.FirstOrDefault().Number);
                        var loyalty = new List<Loyalty>();
                        loyalty = await App.LoyaltyDatabase.GetItemsAsync();
                        Global.SetLoyalty(loyalty.FirstOrDefault());
                        var medals = new List<Medal>();
                        medals = await App.MedalDatabase.GetItemsAsync();
                        Global.SetMedalList(medals);
                    }
                    await Navigation.PushModalAsync(new NavigationPage(page));

                }
            }
            catch (Exception e)
            {

            }
           // StopBusyIndicator();
        }
        private void LoadLeadsAsync()
        {
            App.LeadsViewModel = new LeadsViewModel();
            App.LeadsViewModel.setData();
           // this.BindingContext = App.LeadsViewModel;


        }
        private void SaveUserData(User user, string password)
        {
            
            Credential credential = new Credential()
            {
                User = user,
                Password = password,
                UserID = user.Id.ToString(),
            };
            //Global.Setusername(user.Username);
            //Global.Setpassword(password);


            MessagingCenter.Send<Credential>(credential, "SaveUserData");
        }

        private async Task InitializeAppData()
        {
            await DataAccess.RewardLevelRepository.GetCurrentRewardLevel();
        }
    }
}
