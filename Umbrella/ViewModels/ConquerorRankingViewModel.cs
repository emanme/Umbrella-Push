using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Models;
using Umbrella.Services;
using Umbrella.Utilities;

namespace Umbrella.ViewModels
{
    public class ConquerorRankingViewModel : INotifyPropertyChanged
    {
        private ConquerorRankingService _conquerorService;
        private List<TopResources> _mostResources;
        private List<TopRecruits> _mostNewRecruits;
        private List<TopComrades> _mostNewComrades;

        public List<TopResources> MostResourcesList
        {
            get
            {
                return _mostResources;
            }
            set
            {
                if (_mostResources != value)
                {
                    _mostResources = value;
                    NotifyPropertyChanged("MostResourcesList");
                }
            }
        }
        public List<TopRecruits> MostNewRecruitsList
        {
            get
            {
                return _mostNewRecruits;
            }
            set
            {
                if (_mostNewRecruits != value)
                {
                    _mostNewRecruits = value;
                    NotifyPropertyChanged("MostNewRecruitsList");
                }
            }
        }
        public List<TopComrades> MostNewComradesList
        {
            get
            {
                return _mostNewComrades;
            }
            set
            {
                if (_mostNewComrades != value)
                {
                    _mostNewComrades = value;
                    NotifyPropertyChanged("MostNewComradesList");
                }
            }
        }


        public ConquerorRankingViewModel()
        {
            _conquerorService = new ConquerorRankingService();
          
            _mostNewRecruits = Global.GetTopRec();
            foreach (var item in _mostNewRecruits.Where(c => c.Index == 0))
            {
                item.Index = _mostNewRecruits.IndexOf(item) + 1;
            }
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
