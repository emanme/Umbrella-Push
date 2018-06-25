using System;
using System.IO;
using SQLite;
using Umbrella.Droid.Dependencies;
using Umbrella.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteHelper))]
namespace Umbrella.Droid.Dependencies
{
    public class SQLiteHelper : ISQLiteHelper
    {
        public SQLiteAsyncConnection GetConnectionAsync()
        {
            var fileName = "umbrella.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            var connection = new SQLiteAsyncConnection(path);
            return connection;
        }
    }
}
