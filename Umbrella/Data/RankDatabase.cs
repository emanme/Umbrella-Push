using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Umbrella.Models;

namespace Umbrella.Data
{
    public class RankDatabase
    {
        readonly SQLiteAsyncConnection database;
        public RankDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Rank>().Wait();
        }
        public Task ResetLeads()
        {
            return database.DropTableAsync<Rank>();
        }
        public Task<List<Rank>> GetItemsAsync()
        {
            return database.Table<Rank>().ToListAsync();
        }

        public Task<int> SaveRanksAsync(List<Rank> item)
        {
            database.DropTableAsync<Rank>().Wait();
            database.CreateTableAsync<Rank>().Wait();

            return database.InsertAllAsync(item);
        }
        public Task<int> SaveItemAsync(Rank item)
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
        public Task<int> SaveRanksAsync(Rank item)
        {
            database.DropTableAsync<Rank>().Wait();
            database.CreateTableAsync<Rank>().Wait();
            return database.InsertAsync(item);
        }
        public Task<List<Rank>> GetItemsByCategoryAsync()
        {

            return database.QueryAsync<Rank>($"SELECT * FROM [Rank]");


        }
    }

}
