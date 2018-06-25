using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Umbrella.Services;
using Umbrella.ViewModels;
using System.Linq;

namespace Umbrella.Views
{
    public partial class EarningsPage : ContentPage
    {
        private int _skipEnlisted = 0;
        private int _nextClickEnlisted = 0;
        public EarningsPage()
        {
            InitializeComponent();
            Populate();
            NavigationPage.SetBackButtonTitle(this, "");
        }

        private void EarningsItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            EarningsListView.SelectedItem = null;
        }
        private void NextButtonEnlistedClicked(object sender, EventArgs e)
        {
            _nextClickEnlisted = _nextClickEnlisted + 1;
            var viewmodel = (EarningsViewModel)this.BindingContext;
            var count = viewmodel.EnlistedListStaticList.Count;
            _skipEnlisted = _skipEnlisted + 10;
            var nextlist = viewmodel.EnlistedListStaticList.Skip(_skipEnlisted);
            viewmodel.Earnings = nextlist.ToList();
        }
        private void PreviousButtonEnlistedClicked(object sender, EventArgs e)
        {
            var viewmodel = (EarningsViewModel)this.BindingContext;
            var count = viewmodel.Earnings.Count;
            _skipEnlisted = _skipEnlisted - 10;
            if (_nextClickEnlisted == 1)
            {
                var prevList = viewmodel.EnlistedListStaticList.Take(10);
                viewmodel.Earnings = prevList.ToList();
            }
            else
            {
                var prevTake = 10 * _nextClickEnlisted;
                var prevList = viewmodel.EnlistedListStaticList.Take(prevTake);
                prevList = prevList.Skip(10);
                viewmodel.Earnings = prevList.ToList();
            }
            _nextClickEnlisted = _nextClickEnlisted - 1;
        }

        private async void ReferAndEarnNowClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WeaponsPage());   
        }
        private async void DownloadFundsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DownloadFundsPage());
        }
        private void Populate()
        {
            try
            {
                
                TotalEarn.Text = EarningsService.GetTotalEarnings();
            }
            catch(Exception x)
            {}               
        }
        
    }
}
