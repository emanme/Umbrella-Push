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
    public class ComradesViewModel : INotifyPropertyChanged
    {
        private ComradesService _comradesService;
        private List<ComradesData> _enlistedList;
        public List<ComradesData> EnlistedList
        {
            get { return _enlistedList; }
            set
            {
                if (_enlistedList != value)
                {
                    _enlistedList = value;
                    if (_enlistedStaticList.LastOrDefault().Re_Id == _enlistedList.FirstOrDefault().Re_Id)
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

                    if (_enlistedList.FirstOrDefault().Re_Id == _enlistedStaticList.FirstOrDefault().Re_Id)
                    {
                        _isEnablePreviousEnlisted = false;
                        NotifyPropertyChanged("IsEnablePreviousEnlisted");
                    }

                    NotifyPropertyChanged("EnlistedList");
                }
            }
        }
        private List<ComradesData> _enlistingList;
        public List<ComradesData> EnlistingList
        {
            get { return _enlistingList; }
            set
            {
                if (_enlistingList != value)
                {
                    _enlistingList = value;
                    if (_enlistingStaticList.LastOrDefault().Re_Id == _enlistingList.FirstOrDefault().Re_Id)
                    {
                        _isEnableNextEnlisting = false;
                        NotifyPropertyChanged("IsEnableNextEnlisting");
                        _isEnablePreviousEnlisting = true;
                        NotifyPropertyChanged("IsEnablePreviousEnlisting");
                    }
                    else
                    {
                        _isEnableNextEnlisting = true;
                        NotifyPropertyChanged("IsEnableNextEnlisting");
                        _isEnablePreviousEnlisting = true;
                        NotifyPropertyChanged("IsEnablePreviousEnlisting");
                    }

                    if (_enlistingList.FirstOrDefault().Re_Id == _enlistingStaticList.FirstOrDefault().Re_Id)
                    {
                        _isEnablePreviousEnlisting = false;
                        NotifyPropertyChanged("IsEnablePreviousEnlisting");
                    }

                    NotifyPropertyChanged("EnlistingList");
                }
            }
        }
        private List<ComradesData> _enlistingStaticList;
        public List<ComradesData> EnlistingListStaticList
        {
            get { return _enlistingStaticList; }
            set
            {
                if (_enlistingStaticList != value)
                {
                    _enlistingStaticList = value;
                    NotifyPropertyChanged("EnlistingListStaticList");
                }
            }
        }
        private List<ComradesData> _enlistedStaticList;
        public List<ComradesData> EnlistedListStaticList
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
        private bool _isEnableNextEnlisting= true;
        public bool IsEnableNextEnlisting
        {
            get
            {
                return _isEnableNextEnlisting;
            }
            set
            {
                if (_isEnableNextEnlisting != value)
                {
                    _isEnableNextEnlisting = value;
                    NotifyPropertyChanged("IsEnableNextEnlisting");
                }
            }
        }
        private bool _isEnablePreviousEnlisting = false;
        public bool IsEnablePreviousEnlisting
        {
            get
            {
                return _isEnablePreviousEnlisting;
            }
            set
            {
                if (_isEnablePreviousEnlisting != value)
                {
                    _isEnablePreviousEnlisting = value;
                    NotifyPropertyChanged("IsEnablePreviousEnlisting");
                }
            }
        }
        private bool _isVisiblePreviousEnlisted = true;
        public bool IsVisiblePreviousEnlisted
        {
            get
            {
                return _isVisiblePreviousEnlisted;
            }
            set
            {
                if (_isVisiblePreviousEnlisted != value)
                {
                    _isVisiblePreviousEnlisted = value;
                    NotifyPropertyChanged("IsVisiblePreviousEnlisted");
                }
            }
        }
        private bool _isVisibleNextEnlisted = true;
        public bool IsVisibleNextEnlisted
        {
            get
            {
                return _isVisibleNextEnlisted;
            }
            set
            {
                if (_isVisibleNextEnlisted != value)
                {
                    _isVisibleNextEnlisted = value;
                    NotifyPropertyChanged("IsVisibleNextEnlisted");
                }
            }
        }
        private bool _isVisiblePreviousEnlisting = true;
        public bool IsVisiblePreviousEnlisting
        {
            get
            {
                return _isVisiblePreviousEnlisting;
            }
            set
            {
                if (_isVisiblePreviousEnlisting != value)
                {
                    _isVisiblePreviousEnlisting = value;
                    NotifyPropertyChanged("IsVisiblePreviousEnlisting");
                }
            }
        }
        private bool _isVisibleNextEnlisting = true;
        public bool IsVisibleNextEnlisting
        {
            get
            {
                return _isVisibleNextEnlisting;
            }
            set
            {
                if (_isVisibleNextEnlisting != value)
                {
                    _isVisibleNextEnlisting = value;
                    NotifyPropertyChanged("IsVisibleNextEnlisting");
                }
            }
        }
        public ComradesViewModel()
        {
            _comradesService = new ComradesService();
            _enlistedList = _comradesService.GetComradeDataSoldApi();
            //button
            _isVisibleNextEnlisted = _enlistedList.Count > 10 ? true : false;
            _isVisiblePreviousEnlisted = _enlistedList.Count > 10 ? true : false;

            _enlistedStaticList = _enlistedList;
            _enlistedList = _enlistedList.Take(10).ToList();
            _isEnableNextEnlisted = _enlistedStaticList.Count > 10 ? true : false;
            //enlisting
            _enlistingList = _comradesService.GetComradeDataApi();
            //button
            _isVisibleNextEnlisting = _enlistingList.Count > 10 ? true : false;
            _isVisiblePreviousEnlisting = _enlistingList.Count > 10 ? true : false;

            _enlistingStaticList = _enlistingList;
            _enlistingList = _enlistingList.Take(10).ToList();
            _isEnableNextEnlisting = _enlistingStaticList.Count > 10 ? true : false;
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
