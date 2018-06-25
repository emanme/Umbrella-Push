using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.Constants;
using Umbrella.DAL;
using Umbrella.Interfaces;
using Umbrella.Models;
using Umbrella.Repository;
using Xamarin.Forms;

namespace Umbrella.DataSync
{
    public abstract class DataSynchronizationBase<T> : RepositoryBase<T> where T : ISynchronizable, new()
    {
        public static readonly int SynchronizationIntervalMinutes = 0;

        private bool _isSynchronizing;

        public abstract Task<SynchronizationItems<T>> GetSyncItemsAsync(DateTime syncDate);

        public DataSynchronizationBase()
        {
        }

        public override async Task<List<T>> GetAllAsync()
        {
            await CheckSynchronizationAsync();
            return await base.GetAllAsync();
        }

        protected async Task CheckSynchronizationAsync()
        {
            if (_isSynchronizing)
            {
                return;
            }
            _isSynchronizing = true;
            var syncInfo = await GetSyncInfoAsync();
            if ((DateTime.UtcNow - syncInfo.LastSynchronization).TotalMinutes >= SynchronizationIntervalMinutes)
            {
                await SynchronizeAsync();
            }
            _isSynchronizing = false;
        }

        private async Task SynchronizeAsync()
        {
            var networkConnection = DependencyService.Get<IConnectionChecker>();
            networkConnection.CheckNetworkConnection();
            if (networkConnection.IsConnected)
            {
                var syncInfo = await GetSyncInfoAsync();
                SynchronizationItems<T> syncItems = null;

                try
                {
                    DateTime syncDate;
                    if (AppSettings.IsHardRefresh)
                    {
                        syncDate = new DateTime(2014, 1, 1);
                        AppSettings.IsHardRefresh = false;
                    }
                    else
                    {
                        syncDate = syncInfo.LastSynchronization;
                    }
                    syncItems = await GetSyncItemsAsync(syncDate);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }

                if (syncItems == null)
                {
                    return;
                }

                var items = syncItems.AddedItems;
                if (syncItems.EditedItems != null)
                {
                    items.Union(syncItems.EditedItems);
                }

                foreach (var i in items)
                {
                    if (await Connection.GetAsync<T>(i.Id) == null)
                    {
                        await Connection.InsertAsync(i);
                    }
                    else
                    {
                        await Connection.UpdateAsync(i);
                    }
                }

                if (syncItems.DeletedItemKeys != null)
                {
                    foreach (var i in syncItems.DeletedItemKeys)
                    {
                        var item = await Connection.GetAsync<T>(i);
                        if (item != null)
                        {
                            await Connection.DeleteAsync(item);
                        }
                    }
                }

                syncInfo.LastSynchronization = DateTime.UtcNow;
                await Connection.UpdateAsync(syncInfo);
            }
        }

        #region Synchronization Information Management
        private SyncInformation _syncInfo;

        private async Task<SyncInformation> GetSyncInfoAsync()
        {
            var tableName = typeof(T).FullName;
            if (_syncInfo == null)
            {
                _syncInfo = await Connection.Table<SyncInformation>()
                    .Where(i => i.TableName == typeof(T).FullName)
                    .FirstOrDefaultAsync();
                if (_syncInfo == null)
                {
                    _syncInfo = new SyncInformation()
                    {
                        TableName = typeof(T).FullName,
                        LastSynchronization = new DateTime(2014, 1, 1)
                    };
                    await DataAccess.SyncInfoRepository.InsertAsync(_syncInfo);
                }
            }
            return _syncInfo;
        }
        #endregion
    }
}
