using System.Collections.Generic;
using System.ComponentModel;
using Umbrella.Models;
using Umbrella.Services;

namespace Umbrella.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private List<SettingsItem> _settingsItems;

        public List<SettingsItem> SettingsItems
        {
            get { return _settingsItems; }
            set
            {
                if (_settingsItems != value)
                {
                    _settingsItems = value;
                    NotifyPropertyChanged("SettingsItems");
                }
            }
        }

        public SettingsViewModel()
        {
            var service = new SettingsService();
            _settingsItems = service.GetSettingsItems();
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
