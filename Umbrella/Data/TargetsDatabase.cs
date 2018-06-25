using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Umbrella.Models;

namespace Umbrella.Data
{
    public class TargetsDatabase
    {
        readonly SQLiteAsyncConnection database;
        public TargetsDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Target>().Wait();
        }
        public Task ResetLeads()
        {
            return database.DropTableAsync<Target>();
        }
        public Task<List<Target>> GetItemsAsync()
        {
            return database.Table<Target>().ToListAsync();
        }

        public Task<int> SaveTargetsAsync(List<Target> leads)
        {
            database.DropTableAsync<Target>().Wait();
            database.CreateTableAsync<Target>().Wait();

            return database.InsertAllAsync(leads);
        }
        public Task<int> SaveItemAsync(Target item)
        {
            if (item.Id != "0")
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);

            }
        }

        public Task<List<Target>> GetItemsByCategoryAsync()
        {

            return database.QueryAsync<Target>($"SELECT * FROM [Target]");


        }
    }
}
