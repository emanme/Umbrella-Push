using System;
using Umbrella.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class CharityItemPage : ContentPage
    {
        private Charity _charity;

        public CharityItemPage(Charity charity)
        {
            InitializeComponent();

            _charity = charity;
            BindingContext = charity;

            HeadlineLabel.Text = $"{charity.Name} donated £{charity.Donation}";
        }

        private void LocationClicked(object sender, EventArgs e)
        {
            // TODO
        }

        private void FieldPartnerClicked(object sender, EventArgs e)
        {
            // TODO
        }

        private void DiaryClicked(object sender, EventArgs e)
        {
            // TODO
        }

        private void RepaymentsClicked(object sender, EventArgs e)
        {
            // TODO
        }

        private void BackClicked(object sender, EventArgs e)
        {
            // TODO
        }

        private void NextClicked(object sender, EventArgs e)
        {
            // TODO
        }
    }
}
