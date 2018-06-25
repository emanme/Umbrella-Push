
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Umbrella.Models;

namespace Umbrella.Data
{
    public class MedalDatabase
    {
        readonly SQLiteAsyncConnection database;
        public MedalDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Medal>().Wait();
        }
        public Task ResetLeads()
        {
            return database.DropTableAsync<Medal>();
        }
        public Task<List<Medal>> GetItemsAsync()
        {
            return database.Table<Medal>().ToListAsync();
        }

        public Task<int> SaveMedalsAsync(List<Medal> leads)
        {
            database.DropTableAsync<Medal>().Wait();
            database.CreateTableAsync<Medal>().Wait();

            return database.InsertAllAsync(leads);
        }
        public Task<int> SaveItemAsync(Medal item)
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

        public Task<List<Medal>> GetItemsByCategoryAsync()
        {

            return database.QueryAsync<Medal>($"SELECT * FROM [Medal]");


        }
    }
}
