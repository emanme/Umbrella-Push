using System;
using System.Threading.Tasks;
using Umbrella.DataSync;
using Umbrella.Enums;
using Umbrella.Interfaces;
using Umbrella.Models;
using Umbrella.Services;
using Xamarin.Forms;

namespace Umbrella.Repository
{
    public class RewardLevelRepository : DataSynchronizationBase<RewardLevelItem>
    {
        public RewardLevelValue Current { get; set; }

        public override Task<SynchronizationItems<RewardLevelItem>> GetSyncItemsAsync(DateTime syncDate)
        {
            return null;
        }

        public async Task GetCurrentRewardLevel()
        {
            var service = new RewardLevelsService();
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            Current = (RewardLevelValue) (await service.GetRewardLevel(credential.User.Email));
        }
    }
}
