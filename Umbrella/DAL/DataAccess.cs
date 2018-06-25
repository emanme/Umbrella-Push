using System;
using System.Diagnostics;
using Umbrella.Repository;

namespace Umbrella.DAL
{
    public static class DataAccess
    {
        public static SyncInfoRepository SyncInfoRepository;
        public static RewardLevelRepository RewardLevelRepository;

        static DataAccess()
        {
            try
            {
                SyncInfoRepository = new SyncInfoRepository();
                RewardLevelRepository = new RewardLevelRepository();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
