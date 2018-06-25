using System.Collections.Generic;
using System.ComponentModel;
using Umbrella.Models;
using Umbrella.Services;

namespace Umbrella.ViewModels
{
    public class NotificationsViewModel : INotifyPropertyChanged
    {
        private List<NotificationsItem> _notificationsItems;

        public List<NotificationsItem> NotificationsItems
        {
            get { return _notificationsItems; }
            set
            {
                if (_notificationsItems != value)
                {
                    _notificationsItems = value;
                    NotifyPropertyChanged("NotificationsItems");
                }
            }
        }

        public NotificationsViewModel()
        {
            var service = new NotificationsService();
            _notificationsItems = service.GetNotificationsItems();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
