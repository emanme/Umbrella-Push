using System;
using System.Threading.Tasks;
using Umbrella.Models;

namespace Umbrella.Data
{
    public partial class LeadsManager
    {
        static LeadsManager defaultInstance = new LeadsManager();
       // MobileServiceClient client;
       // IMobileServiceTable<Favorite> favoritesTable;
       // MobileServiceClient client;
        public LeadsManager()
        {
        }
        public async Task SaveLeadAsync(Lead item)
        {
            try
            {
                if (item.EnquiryId == null)
                {
                  //  await leadsTable.InsertAsync(item);
                }
                else
                {
                //    await leadsTable.UpdateAsync(item);
                }
            }
            catch (Exception ex)
            {

            }


        }

        public static LeadsManager DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }
    }
}
