using System;
using System.IO;
using SQLite;
using Umbrella.Interfaces;
using Umbrella.iOS.Dependencies;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteHelper))]
namespace Umbrella.iOS.Dependencies
{
    public class SQLiteHelper : ISQLiteHelper
    {
        public SQLiteAsyncConnection GetConnectionAsync()
        {
            var fileName = "umbrella.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library", "Databases");

            if (!Directory.Exists(libraryPath))
            {
                Directory.CreateDirectory(libraryPath);
            }

            var path = Path.Combine(libraryPath, fileName);
            var connection = new SQLiteAsyncConnection(path);
            return connection;
        }
    }
}
