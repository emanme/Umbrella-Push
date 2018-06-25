using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Umbrella.Converters;
using Umbrella.Helpers;
using Umbrella.Models;
using Umbrella.Utilities;
using Umbrella.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
 
        
namespace Umbrella.Views
{
    public partial class LeadsPage : ContentPage
    {
        public Lead Leads { get; set; }
        public LeadsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
         
            ShowLeads();
        }
        private void LeadsButtonTapped(object sender, EventArgs args)
        {
            ShowLeads();
        }
        protected override void OnAppearing()
        {
            // LoadLeadsAsync();
            base.OnAppearing();
            LeadsFooter.SetRewardLevelIcon(Global.GetrewardPoints());
        }
        private  void LoadLeadsAsync()
        {
            //App.LeadsViewModel.RefreshLeadsAsync();
            System.Diagnostics.Debug.WriteLine("LoadLeadsAsync Lead Page");
            this.BindingContext = App.LeadsViewModel;
        }
        private async void CustomersButtonTapped(object sender, EventArgs args)
        {
            // this.BindingContext
            App.LeadsViewModel.ShowCustomers();// App.CustomersViewModel.ShowCustomers("customers");

          //  this.BindingContext = App.CustomersViewModel;
            //removed since viewmodel should load customers in the list
            var page = new CustomersPage();
              await Navigation.PushAsync(page);
           // ShowCustomersBacks();
        }
        private async void EnquiriesButtonTapped(object sender, EventArgs args)
        {
            var page = new EnquiriesPage();
            await Navigation.PushAsync(page);
        }
        private async void LeadsItemTapped(object sender, ItemTappedEventArgs e)
        {
            var lead = e.Item as Lead;
            var page = new LeadsItemPage(lead);
            await Navigation.PushAsync(page);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (LeadsListView.SelectedItem == null)
            {
                return;
            }
            LeadsListView.SelectedItem = null;
        }
        private void ShowLeads()
        {
            TabButtonManager.SelectTab(LeadsTab);
            TabButtonManager.DeselectTab(CustomersTab);
            TabButtonManager.DeselectTab(EnquiriesTab);
            LeadsTab.Icon = "leads_red";
            CustomersTab.Icon = "customers";
            EnquiriesTab.Icon = "enquiries";

            LeadsListView.IsVisible = true;
        }
        private void ShowCustomersBacks()
        {
            TabButtonManager.DeselectTab(LeadsTab);
            TabButtonManager.SelectTab(CustomersTab);
            TabButtonManager.DeselectTab(EnquiriesTab);
            LeadsTab.Icon = "leads";
            CustomersTab.Icon = "customers_red";
            EnquiriesTab.Icon = "enquiries";
        }
        private void ShowEnquiries()
        {
            TabButtonManager.DeselectTab(LeadsTab);
            TabButtonManager.DeselectTab(CustomersTab);
            TabButtonManager.SelectTab(EnquiriesTab);
            LeadsTab.Icon = "leads";
            CustomersTab.Icon = "customers";
            EnquiriesTab.Icon = "enquiries_red";
        }
    }
   
}
