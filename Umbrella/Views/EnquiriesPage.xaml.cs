using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class EnquiriesPage : ContentPage
    {
        public EnquiriesPage()
        {
            InitializeComponent();
        }

        private void LeadsButtonTapped(object sender, EventArgs args)
        {
            //  Navigation.PopAsync(); 
           // Navigation.PushModalAsync();
            var page = new LeadsPage();
            Navigation.PushAsync(page);
        }

        private void CallBacksButtonTapped(object sender, EventArgs args)
        {
          
            var page = new CallBacksPage();
            Navigation.PushAsync(page);
        }

        private void CustomerServicesButtonTapped(object sender, EventArgs args)
        {
            var page = new CustomersPage();
            Navigation.PushAsync(page);
        }

        private void OtherButtonTapped(object sender, EventArgs args)
        {
            var page = new OtherPage();
            Navigation.PushAsync(page);
        }

        private void SuppliersButtonTapped(object sender, EventArgs args)
        {
            var page = new SuppliersPage();
            Navigation.PushAsync(page);
        }

        private void StaffButtonTapped(object sender, EventArgs args)
        {
            var page = new StaffPage();
            Navigation.PushAsync(page);
        }
    }
}
