using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Umbrella.Models;

namespace Umbrella.Data
{
    public class LoyaltyDatabase
    {
        readonly SQLiteAsyncConnection database;
        public LoyaltyDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Loyalty>().Wait();
        }
       
        public Task<List<Loyalty>> GetItemsAsync()
        {
            return database.Table<Loyalty>().ToListAsync();
        }

        public Task<int> SaveLoyaltyListAsync(List<Loyalty> item)
        {
            database.DropTableAsync<Loyalty>().Wait();
            database.CreateTableAsync<Loyalty>().Wait();

            return database.InsertAllAsync(item);
        }

        public Task<int> SaveLoyaltysAsync(Loyalty item)
        {
            database.DropTableAsync<Loyalty>().Wait();
            database.CreateTableAsync<Loyalty>().Wait();
            return database.InsertAsync(item);
        }
        public Task<List<Loyalty>> GetItemsByCategoryAsync()
        {

            return database.QueryAsync<Loyalty>($"SELECT * FROM [Loyalty]");


        }
    }
}
