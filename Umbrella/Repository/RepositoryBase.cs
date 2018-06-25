using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Umbrella.Interfaces;
using Xamarin.Forms;

namespace Umbrella.Repository
{
    public class RepositoryBase<T> where T : new()
    {
        protected SQLiteAsyncConnection Connection;

        protected AsyncTableQuery<T> Table
        {
            get
            {
                return Connection.Table<T>();
            }
        }

        public RepositoryBase()
        {
            Connection = DependencyService.Get<ISQLiteHelper>().GetConnectionAsync();
            Connection.CreateTableAsync<T>().Wait();
        }

        public virtual Task<List<T>> GetAllAsync()
        {
            return this.Table.ToListAsync();
        }

        public virtual Task<T> GetAsync(object id)
        {
            return Connection.GetAsync<T>(id);
        }

        public virtual Task<int> InsertAsync(T item)
        {
            return Connection.InsertAsync(item);
        }

        public virtual Task<int> UpdateAsync(T item)
        {
            return Connection.UpdateAsync(item);
        }

        public virtual Task<int> DeleteAsync(T item)
        {
            return Connection.DeleteAsync(item);
        }

        public virtual async Task ClearAsync()
        {
            await Connection.DropTableAsync<T>();
            await Connection.CreateTableAsync<T>();
        }
    }
}
