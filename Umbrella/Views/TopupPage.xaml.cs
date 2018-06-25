using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.Helpers;
using Umbrella.Interfaces;
using Umbrella.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class TopupPage : ContentPage
    {
        private string[] SelectionArray = { "￡25", "￡50", "￡75", "￡100", "￡150", "￡250"};
        private string[] CreditCardArray = new string[] { };
        private Credential _credential;
        private List<RetrievedCard> _listCard;
        public TopupPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            proceedButtonAddCard.Clicked += new SingleClick(ProceedClicked).Click;
            proceedButtonExistingCard.Clicked += new SingleClick(ProceedExistingClicked).Click;

            _credential = DependencyService.Get<ICredentialRetriever>().GetCredential();

            proceedButtonAddCard.IsEnableButton = CrossConnectivity.Current.IsConnected;
            proceedButtonExistingCard.IsEnableButton = CrossConnectivity.Current.IsConnected;
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                proceedButtonAddCard.IsEnableButton = args.IsConnected ? true : false;
                proceedButtonExistingCard.IsEnableButton = args.IsConnected ? true : false;
            };

        }
        protected override async void OnAppearing()
        {
            await ShowExistingCardPage();
            base.OnAppearing();
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
        private async void AmountExistingDropdownTapped(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet(DropdownCardAmount.Label, "Cancel", null, SelectionArray);
            if (!action.Equals("Cancel"))
            {
                DropdownCardAmount.Label = action;
                DropdownCardAmount.LabelColor = (Color)Application.Current.Resources["PrimaryTextColor"];
            }
        }
        private async void CreditCardDropdownTapped(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet(DropdownAddCard.Label, "Cancel", null, CreditCardArray);
            if (!action.Equals("Cancel"))
            {
                DropdownAddCard.Label = action;
                DropdownAddCard.LabelColor = (Color)Application.Current.Resources["PrimaryTextColor"];
            }
        }
        private void StartBusyIndicator()
        {
            BusyIndicator.IsVisible = true;
            Indicator.IsBusy = true;

        }

        private void StopBusyIndicator()
        {
            BusyIndicator.IsVisible = false;
            Indicator.IsBusy = false;
        }
        private void AddCardTabTapped(object sender, EventArgs args)
        {
            ShowAddCardPage();
        }
        private async void ExistingCardTabTapped(object sender, EventArgs args)
        {
            await ShowExistingCardPage();
        }
        private async Task ShowExistingCardPage()
        {
            TabButtonManager.DeselectTab(AddCardTab);
            TabButtonManager.SelectTab(ExistingCardTab);
            addCardTab.IsVisible = false;
            existingCardTab.IsVisible = true;

            if (CrossConnectivity.Current.IsConnected)
            {
                if (!CreditCardArray.Any())
                {
                    StartBusyIndicator();
                    var listCard = await DependencyService.Get<ITopupPaymentService>().GetAllCurrentCards(_credential.User.Email);
                    _listCard = listCard.Any() ? listCard : new List<RetrievedCard>();
                    CreditCardArray = _listCard.Any() ? listCard.Select(x => x.Name).ToArray() : new string[] { };
                    StopBusyIndicator();
                }
            }
            else
            {
                CreditCardArray = new string[] { "No Connection" };
            }
        }
        private void ShowAddCardPage()
        {
            TabButtonManager.SelectTab(AddCardTab);
            TabButtonManager.DeselectTab(ExistingCardTab);

            addCardTab.IsVisible = true;
            existingCardTab.IsVisible = false;
        }
        private async void ProceedExistingClicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(DropdownAddCard.Label) || DropdownAddCard.Label == "Select Existing Card")
            {
                await DisplayAlert("Prompt", "Please select a card", "OK");
            }
            else if(string.IsNullOrEmpty(DropdownCardAmount.Label) || DropdownCardAmount.Label == "Select...")
            {
                await DisplayAlert("Prompt", "Please choose an amount to Top up", "OK");
            }
            else
            {
                var page = new TopupPage();
                var amount = DropdownCardAmount.Label + "00";
                var retrievedCard = _listCard.Single(p => p.Name == DropdownAddCard.Label);
                StartBusyIndicator();
                //MessagingCenter.Send<Card>(card, "SaveCard");
                var success = await DependencyService.Get<ITopupPaymentService>().ProcessExistingCard(Int32.Parse(amount.Replace("￡", "")), _credential.User.Email, retrievedCard);
                if (success.Keys.First())
                {
                    StopBusyIndicator();
                    await DisplayAlert("Success", "Topup Success", "OK");
                    Navigation.InsertPageBefore(page, this);
                    await Navigation.PopAsync().ConfigureAwait(false);
                }
                else
                {
                    StopBusyIndicator();
                    await DisplayAlert("Error", success.Values.First(), "OK");
                }
            }
         

        }
        private async void ProceedClicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(NameInput.Text) || string.IsNullOrEmpty(ExpiryMonthInput.Text) || string.IsNullOrEmpty(ExpiryYearInput.Text) ||
                string.IsNullOrEmpty(CVCInput.Text) || string.IsNullOrEmpty(Dropdown.Label) || Dropdown.Label == "Select...")
            {
                await DisplayAlert("Prompt", "Please fill up all the entry", "OK");
            }
            else
            {
                var card = new Card()
                {
                    Name = NameInput.Text,
                    Number = NumberInput.Text,
                    ExpiryMonth = int.Parse(ExpiryMonthInput.Text),
                    ExpiryYear = int.Parse(ExpiryYearInput.Text),
                    CVC = CVCInput.Text,
                };
                var last4 = NumberInput.Text.Substring(NumberInput.Text.Length - 4);
                var page = new TopupPage();
                var amount = Dropdown.Label + "00";
                var isCardAlreadyExist = _listCard.Any(p => p.Last4 == last4 && p.Name == NameInput.Text);
                if (isCardAlreadyExist)
                {
                    await DisplayAlert("Error", "Card Already Exists", "OK");
                }
                else
                {
                    StartBusyIndicator();
                    //MessagingCenter.Send<Card>(card, "SaveCard");
                    var success = await DependencyService.Get<ITopupPaymentService>().ProcessCustomerCard(card, Int32.Parse(amount.Replace("￡", "")), _credential.User.Email);
                    if (success.Keys.First())
                    {
                        StopBusyIndicator();
                        await DisplayAlert("Success", "Topup Success", "OK");
                        await Navigation.PushAsync(page);
                    }
                    else
                    {
                        StopBusyIndicator();
                        await DisplayAlert("Error", success.Values.First(), "OK");
                    }
                }
            }
        }
    }
}
