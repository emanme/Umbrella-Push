using System.Collections.Generic;
using System.ComponentModel;
using Umbrella.Models;
using Umbrella.Services;

namespace Umbrella.ViewModels
{
    public class ReferralsViewModel : INotifyPropertyChanged
    {
        private List<Referral> _referrals;

        public List<Referral> Referrals
        {
            get { return _referrals; }
            set
            {
                if (_referrals != value)
                {
                    _referrals = value;
                    NotifyPropertyChanged("Referrals");
                }
            }
        }

        public ReferralsViewModel()
        {
            var service = new ReferralsService();
            _referrals = service.GetReferrals();
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
