using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class NotificationsPage : ContentPage
    {
        public NotificationsPage()
        {
            InitializeComponent();
        }

        private void NotificationsItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            NotificationsListView.SelectedItem = null;
        }
    }
}
