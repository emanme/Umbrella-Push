using Plugin.Connectivity;
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
    public class MedalsViewModel : INotifyPropertyChanged
    {
        private MedalsService _medalService;
        private List<Medal> _medalList;
        public List<Medal> MedalsList
        {
            get
            {
                return _medalList;
            }
            set
            {
                if (_medalList != value)
                {
                    _medalList = value;
                    NotifyPropertyChanged("MedalsList");
                }
            }
        }
        public MedalsViewModel()
        {
            _medalService = new MedalsService();
            _medalList = Global.GetMedalList();
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
