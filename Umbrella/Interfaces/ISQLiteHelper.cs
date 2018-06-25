using SQLite;

namespace Umbrella.Interfaces
{
    public interface ISQLiteHelper
    {
        SQLiteAsyncConnection GetConnectionAsync();
    }
}
