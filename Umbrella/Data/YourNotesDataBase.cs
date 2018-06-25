using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System;
using System.Linq;
using Umbrella.Models;

namespace Umbrella.Data
{
    public class YourNotesDataBase
    {
        readonly SQLiteAsyncConnection database;
        public YourNotesDataBase(string dbPath)
        {
           // database = new SQLiteAsyncConnection(dbPath);

            //database.DropTableAsync<Notes>().Wait();

           // System.Diagnostics.Debug.WriteLine("database.DropTableAsync<Y> ");
           // database.CreateTableAsync<Notes>().Wait();

        }
        public Task ResetNotes()
        {
            return database.DropTableAsync<Notes>();
        }
        public Task<List<Notes>> GetItemsAsync()
        {
            return database.Table<Notes>().ToListAsync();
        }

        public Task<int> SaveNotesAsync(List<Notes> notes)
        {

            return database.InsertAllAsync(notes);
        }
        public Task<int> SaveItemAsync(Notes item)
        {
            if (item.id != "0")
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);

            }
        }

        public Task<List<Notes>> GetItemsByCategoryAsync()
        {

            return database.QueryAsync<Notes>($"SELECT * FROM [Notes]");


        }
    }
}
