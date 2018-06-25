using System.ComponentModel;
//using Plugin.FirebasePushNotification;
namespace Umbrella.Models
{
    public class NotificationsItem : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string ToogleFor { get; set; }
        public string Description { get; set; }

        private bool isToggled;
        public bool IsToggled
        {
            get { return isToggled; }
            set
            {
                if (isToggled != value)
                {
                    isToggled = value;
                    NotifyPropertyChanged("IsToggled", ToogleFor);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName, string ToogleFor)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                if (isToggled)
                {
                   // CrossFirebasePushNotification.Current.Subscribe(ToogleFor);
                    System.Diagnostics.Debug.WriteLine(" Subscribed " + ToogleFor);
                }
                else
                {
                  //  CrossFirebasePushNotification.Current.Unsubscribe(ToogleFor);
                    System.Diagnostics.Debug.WriteLine(" Unsubscribe " + ToogleFor);
                }

            }
        }
    }
}
