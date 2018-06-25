using System;
using SQLite;

namespace Umbrella.Models
{
    public class SyncInformation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string TableName { get; set; }

        public DateTime LastSynchronization { get; set; }
    }
}
