using Xamarin.Forms;
using Umbrella.Models;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class ReferralItemPage : ContentPage
    {
        public ReferralItemPage(Referral referral)
        {
            InitializeComponent();

            BindingContext = referral;
        }
    }
}
