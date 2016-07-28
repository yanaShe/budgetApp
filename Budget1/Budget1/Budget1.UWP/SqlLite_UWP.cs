using Budget1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Windows.Storage;
using Budget1.UWP;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace Budget1.UWP
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            //This is the right implenentation:
            //				var sqliteFilename = "Expanse.db";
            //				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
            //				string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
            //				var path = Path.Combine(libraryPath, sqliteFilename);
            var path = "Expanse.db"; // temporarily set our path to a local file

            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}
