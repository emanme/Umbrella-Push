using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.Models;
using Umbrella.Services;
using Umbrella.Utilities;

namespace Umbrella.ViewModels
{
    public class RewardLevelsViewModel : INotifyPropertyChanged
    {
        private List<RewardLevel> _rewardLevels;
        private Rank _rank;

        public List<RewardLevel> RewardLevels
        {
            get { return _rewardLevels; }
            set
            {
                if (_rewardLevels != value)
                {
                    _rewardLevels = value;
                    NotifyPropertyChanged("RewardLevels");
                }
            }
        }

        public Rank Rank
        {
            get { return _rank; }
            set
            {
                if (_rank != value)
                {
                    _rank = value;
                    NotifyPropertyChanged("Rank");
                }
            }
        }

        public RewardLevelsViewModel()
        {
            var service = new RewardLevelsService();
            _rewardLevels = service.GetRewardLevels();
            // _rank = service.GetReward();
            _rank = new Rank()
            {
                Number = Global.GetrewardPoints(),
                Title = Global.GetRankTitle()
                             
            };
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
