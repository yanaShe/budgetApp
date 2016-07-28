using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Budget1.Droid;
using Budget1.Data;

[assembly: Dependency(typeof(SQLite_Android))]

namespace Budget1.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
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