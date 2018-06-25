using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Umbrella.Models;
using Umbrella.Services;
using Xamarin.Forms;

namespace Umbrella.ViewModels
{
    public class RecruitViewModel : INotifyPropertyChanged
    {
        private RecruitService _recruitService;
        private List<RecruitData> _recruitedList;
        public List<RecruitData> RecruitedList
        {
            get { return _recruitedList; }
            set
            {
                if (_recruitedList != value)
                {
                    _recruitedList = value;
                    if(_recruitedStaticList.LastOrDefault().Re_Id == _recruitedList.FirstOrDefault().Re_Id)
                    {
                        _isEnableNextRecruited = false;
                        NotifyPropertyChanged("IsEnableNextRecruited");
                        _isEnablePreviousRecruited = true;
                        NotifyPropertyChanged("IsEnablePreviousRecruited");
                    }
                    else
                    {
                        _isEnableNextRecruited = true;
                        NotifyPropertyChanged("IsEnableNextRecruited");
                        _isEnablePreviousRecruited = true;
                        NotifyPropertyChanged("IsEnablePreviousRecruited");
                    }

                    if(_recruitedList.FirstOrDefault().Re_Id == _recruitedStaticList.FirstOrDefault().Re_Id)
                    {
                        _isEnablePreviousRecruited = false;
                        NotifyPropertyChanged("IsEnablePreviousRecruited");
                    }

                    NotifyPropertyChanged("RecruitedList");
                }
            }
        }
        private List<RecruitData> _recruitingList;
        public List<RecruitData> RecruitingList
        {
            get { return _recruitingList; }
            set
            {
                if (_recruitingList != value)
                {
                    _recruitingList = value;
                    if (_recruitingStaticList.LastOrDefault().Re_Id == _recruitingList.FirstOrDefault().Re_Id)
                    {
                        _isEnableNextRecruiting = false;
                        NotifyPropertyChanged("IsEnableNextRecruiting");
                        _isEnablePreviousRecruiting = true;
                        NotifyPropertyChanged("IsEnablePreviousRecruiting");
                    }
                    else
                    {
                        _isEnableNextRecruiting = true;
                        NotifyPropertyChanged("IsEnableNextRecruiting");
                        _isEnablePreviousRecruiting = true;
                        NotifyPropertyChanged("IsEnablePreviousRecruiting");
                    }

                    if (_recruitingList.FirstOrDefault().Re_Id == _recruitingStaticList.FirstOrDefault().Re_Id)
                    {
                        _isEnablePreviousRecruiting = false;
                        NotifyPropertyChanged("IsEnablePreviousRecruiting");
                    }

                    NotifyPropertyChanged("RecruitingList");
                }
            }
        }
        private List<RecruitData> _recruitingStaticList;
        public List<RecruitData> RecruitingListStaticList
        {
            get { return _recruitingStaticList; }
            set
            {
                if (_recruitingStaticList != value)
                {
                    _recruitingStaticList = value;
                    NotifyPropertyChanged("RecruitingListStaticList");
                }
            }
        }
        private List<RecruitData> _recruitedStaticList;
        public List<RecruitData> RecruitedListStaticList
        {
            get { return _recruitedStaticList; }
            set
            {
                if (_recruitedStaticList != value)
                {
                    _recruitedStaticList = value;
                    NotifyPropertyChanged("RecruitedListStaticList");
                }
            }
        }
        private bool _isEnableNextRecruited = true;
        public bool IsEnableNextRecruited
        {
            get
            {
                return _isEnableNextRecruited;
            }
            set
            {
                if (_isEnableNextRecruited != value)
                {
                    _isEnableNextRecruited = value;
                    NotifyPropertyChanged("IsEnableNextRecruited");
                }
            }
        }
        private bool _isEnablePreviousRecruited = false;
        public bool IsEnablePreviousRecruited
        {
            get
            {
                return _isEnablePreviousRecruited;
            }
            set
            {
                if (_isEnablePreviousRecruited != value)
                {
                    _isEnablePreviousRecruited = value;
                    NotifyPropertyChanged("IsEnablePreviousRecruited");
                }
            }
        }
        private bool _isEnableNextRecruiting = true;
        public bool IsEnableNextRecruiting
        {
            get
            {
                return _isEnableNextRecruiting;
            }
            set
            {
                if (_isEnableNextRecruiting != value)
                {
                    _isEnableNextRecruiting = value;
                    NotifyPropertyChanged("IsEnableNextRecruiting");
                }
            }
        }
        private bool _isEnablePreviousRecruiting = false;
        public bool IsEnablePreviousRecruiting
        {
            get
            {
                return _isEnablePreviousRecruiting;
            }
            set
            {
                if (_isEnablePreviousRecruiting != value)
                {
                    _isEnablePreviousRecruiting = value;
                    NotifyPropertyChanged("IsEnablePreviousRecruiting");
                }
            }
        }
        private bool _isVisiblePreviousRecruited = true;
        public bool IsVisiblePreviousRecruited
        {
            get
            {
                return _isVisiblePreviousRecruited;
            }
            set
            {
                if (_isVisiblePreviousRecruited != value)
                {
                    _isVisiblePreviousRecruited = value;
                    NotifyPropertyChanged("IsVisiblePreviousRecruited");
                }
            }
        }
        private bool _isVisibleNextRecruited = true;
        public bool IsVisibleNextRecruited
        {
            get
            {
                return _isVisibleNextRecruited;
            }
            set
            {
                if (_isVisibleNextRecruited != value)
                {
                    _isVisibleNextRecruited = value;
                    NotifyPropertyChanged("IsVisibleNextRecruited");
                }
            }
        }
        private bool _isVisiblePreviousRecruiting = true;
        public bool IsVisiblePreviousRecruiting
        {
            get
            {
                return _isVisiblePreviousRecruiting;
            }
            set
            {
                if (_isVisiblePreviousRecruiting != value)
                {
                    _isVisiblePreviousRecruiting = value;
                    NotifyPropertyChanged("IsVisiblePreviousRecruiting");
                }
            }
        }
        private bool _isVisibleNextRecruiting = true;
        public bool IsVisibleNextRecruiting
        {
            get
            {
                return _isVisibleNextRecruiting;
            }
            set
            {
                if (_isVisibleNextRecruiting != value)
                {
                    _isVisibleNextRecruiting = value;
                    NotifyPropertyChanged("IsVisibleNextRecruiting");
                }
            }
        }
        public ICommand NextListCommand { get; private set; }
        public RecruitViewModel()
        {
            _recruitService = new RecruitService();
           
            //recruiting
            _recruitingList = _recruitService.GetRecruitingDataApi();
            //button
            _isVisibleNextRecruiting = _recruitingList.Count > 10 ? true : false;
            _isVisiblePreviousRecruiting = _recruitingList.Count > 10 ? true : false;
            _recruitingStaticList = _recruitingList;
            _recruitingList = _recruitingList.Take(10).ToList();
            _isEnableNextRecruiting = _recruitingStaticList.Count > 10 ? true : false;
        }
        public void RecruitedData(){
             _recruitedList = _recruitService.GetRecruitingDataSoldApi();
            NotifyPropertyChanged("RecruitedList");
            //button
             _recruitedStaticList = _recruitedList;
             _recruitedList = _recruitedList.Take(10).ToList();
             NotifyPropertyChanged("RecruitedList");
             _isEnableNextRecruited = _recruitedStaticList.Count > 10 ? true : false;
            NotifyPropertyChanged("IsEnableNextRecruited");
            _isVisibleNextRecruited = _recruitedList.Count > 10 ? true : false;
            NotifyPropertyChanged("IsVisibleNextRecruited");
            _isVisiblePreviousRecruited = _recruitedList.Count > 10 ? true : false;
            NotifyPropertyChanged("IsVisiblePreviousRecruited");
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
