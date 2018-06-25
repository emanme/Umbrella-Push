using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System;
using System.Linq;
using Umbrella.Models;

namespace Umbrella.Data
{
    public class LeadsDataBase
    {
        readonly SQLiteAsyncConnection database;
        public LeadsDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Lead>().Wait();
            
        }
        public Task ResetLeads()
        {
            return  database.DropTableAsync<Lead>();
        }
        public Task<List<Lead>> GetItemsAsync()
        {
            return database.Table<Lead>().ToListAsync();
        }
        
        public Task<int> SaveLeadsAsync(List<Lead> leads)
        {
            database.DropTableAsync<Lead>().Wait();
            database.CreateTableAsync<Lead>().Wait();
            return database.InsertAllAsync(leads);
        }
        public Task<int> SaveItemAsync(Lead item)
        {
            if (item.EnquiryId != "0")
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);

            }
        }

        public Task<List<Lead>> GetItemsByCategoryAsync()
       {
           
                return database.QueryAsync<Lead>($"SELECT * FROM [Lead]");
          
        
        }
    }
}
