using System.Collections.Generic;
using System.ComponentModel;
using Umbrella.Models;
using Umbrella.Services;

namespace Umbrella.ViewModels
{
    public class AppointmentsModel : INotifyPropertyChanged
    {       

        public AppointmentsModel()
        {
            var service = new CharitiesService();           
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
