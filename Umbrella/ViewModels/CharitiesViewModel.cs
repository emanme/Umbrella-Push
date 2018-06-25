using System.Collections.Generic;
using System.ComponentModel;
using Umbrella.Models;
using Umbrella.Services;

namespace Umbrella.ViewModels
{
    public class CharitiesViewModel : INotifyPropertyChanged
    {
        private List<Charity> _charities;

        public List<Charity> Charities
        {
            get { return _charities; }
            set
            {
                if (_charities != value)
                {
                    _charities = value;
                    NotifyPropertyChanged("Charities");
                }
            }
        }

        public CharitiesViewModel()
        {
            var service = new CharitiesService();
            //_charities = service.GetCharities();
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
