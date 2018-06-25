using System;
using System.Collections.Generic;
using Umbrella.Interfaces;

namespace Umbrella.DataSync
{
    public class SynchronizationItems<T> where T : ISynchronizable
    {
        public IEnumerable<T> AddedItems { get; set; }

        public IEnumerable<T> EditedItems { get; set; }

        public IEnumerable<Guid> DeletedItemKeys { get; set; }

        public DateTime SyncDate { get; set; }
    }
}
