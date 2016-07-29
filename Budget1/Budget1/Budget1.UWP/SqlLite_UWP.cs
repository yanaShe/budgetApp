using Budget1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Windows.Storage;
using Budget1.UWP;
using System.IO;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace Budget1.UWP
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            //This is the right implenentation:
            var sqliteFilename = "Expanses.db";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            //var path = "/Assets/Expanses.db"; // temporarily set our path to a local file
            return conn;
        }
    }
}
