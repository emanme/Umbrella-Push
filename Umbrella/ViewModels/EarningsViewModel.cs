using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Umbrella.Models;
using Umbrella.Services;

namespace Umbrella.ViewModels
{
    public class EarningsViewModel : INotifyPropertyChanged
    {
        private List<Earning> _earnings;

        public List<Earning> Earnings
        {
            get { return _earnings; }
            set
            {
                if (_earnings != value)
                {
                    _earnings = value;
                    if (_enlistedStaticList.LastOrDefault().Name == _earnings.FirstOrDefault().Name)
                    {
                        _isEnableNextEnlisted = false;
                        NotifyPropertyChanged("IsEnableNextEnlisted");
                        _isEnablePreviousEnlisted = true;
                        NotifyPropertyChanged("IsEnablePreviousEnlisted");
                    }
                    else
                    {
                        _isEnableNextEnlisted = true;
                        NotifyPropertyChanged("IsEnableNextEnlisted");
                        _isEnablePreviousEnlisted = true;
                        NotifyPropertyChanged("IsEnablePreviousEnlisted");
                    }

                    if (_earnings.FirstOrDefault().Name == _enlistedStaticList.FirstOrDefault().Name)
                    {
                        _isEnablePreviousEnlisted = false;
                        NotifyPropertyChanged("IsEnablePreviousEnlisted");
                    }

                    NotifyPropertyChanged("Earnings");
                }
            }
        }
        private List<Earning> _enlistedStaticList;
        public List<Earning> EnlistedListStaticList
        {
            get { return _enlistedStaticList; }
            set
            {
                if (_enlistedStaticList != value)
                {
                    _enlistedStaticList = value;
                    NotifyPropertyChanged("EnlistedListStaticList");
                }
            }
        }
        private bool _isEnableNextEnlisted = true;
        public bool IsEnableNextEnlisted
        {
            get
            {
                return _isEnableNextEnlisted;
            }
            set
            {
                if (_isEnableNextEnlisted != value)
                {
                    _isEnableNextEnlisted = value;
                    NotifyPropertyChanged("IsEnableNextEnlisted");
                }
            }
        }
        private bool _isEnablePreviousEnlisted = false;
        public bool IsEnablePreviousEnlisted
        {
            get
            {
                return _isEnablePreviousEnlisted;
            }
            set
            {
                if (_isEnablePreviousEnlisted != value)
                {
                    _isEnablePreviousEnlisted = value;
                    NotifyPropertyChanged("IsEnablePreviousEnlisted");
                }
            }
        }
        private bool _isVisibleButton;
        public bool IsVisibleButton
        {
            get
            {
                return _isVisibleButton;
            }
            set
            {
                if (_isVisibleButton != value)
                {
                    _isVisibleButton = value;
                    NotifyPropertyChanged("IsVisibleButton");
                }
            }
        }
        public EarningsViewModel()
        {
            var service = new EarningsService();
           // _earnings = service.GetEarnings();
           // _enlistedStaticList = _earnings;
           // _earnings = _earnings.Take(10).ToList();
           // _isVisibleButton = _enlistedStaticList.Count >= 10 ? false : true;
           // _isEnableNextEnlisted = _enlistedStaticList.Count > 10 ? true : false;
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
