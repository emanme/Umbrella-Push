using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Models;
using Umbrella.Services;

namespace Umbrella.ViewModels
{
    public class TargetsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TargetsService _targetService;
        private List<Target> _currentTargets;
        private List<Target> _previousTargets;
        public List<Target> CurrentTargets
        {
            get { return _currentTargets; }
            set
            {
                if (_currentTargets != value)
                {
                    _currentTargets = value;
                    NotifyPropertyChanged("CurrentTargets");
                }
            }
        }
        public List<Target> PreviousTargets
        {
            get { return _previousTargets; }
            set
            {
                if (_previousTargets != value)
                {
                    _previousTargets = value;
                    NotifyPropertyChanged("PreviousTargets");
                }
            }
        }
        public TargetsViewModel()
        {
            _targetService = new TargetsService();
            if (CrossConnectivity.Current.IsConnected)
            {
                var allTargets = _targetService.GetTargetsTrial();
                _currentTargets = allTargets.Where(e => e.TargetDate.Year >= DateTime.Now.Year && e.TargetDate.Month >= DateTime.Now.Month).Select(e => e).ToList();
                NotifyPropertyChanged("CurrentTargets");
                _previousTargets = allTargets.Where(e => e.TargetDate.Year <= DateTime.Now.Year && e.TargetDate.Month < DateTime.Now.Month).Select(e => e).ToList();
                NotifyPropertyChanged("PreviousTargets");
            }

        }
        public async Task SetupList()
        {
            var allTargets = await App.TargetsDatabase.GetItemsAsync();
            _currentTargets = allTargets.Where(e => e.TargetDate.Year >= DateTime.Now.Year && e.TargetDate.Month >= DateTime.Now.Month).Select(e => e).ToList();
            NotifyPropertyChanged("CurrentTargets");
            _previousTargets = allTargets.Where(e => e.TargetDate.Year <= DateTime.Now.Year && e.TargetDate.Month < DateTime.Now.Month).Select(e => e).ToList();
            NotifyPropertyChanged("PreviousTargets");

        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
