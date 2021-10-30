using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using xamarinApp.Data;
using xamarinApp.Droid.Data;
using SQLite;

using System.IO;

[assembly: Dependency(typeof(GetSQLiteConnnection))]
namespace xamarinApp.Droid.Data
{
    public class GetSQLiteConnnection : ISQLiteConnection
    {
        public GetSQLiteConnnection()
        {

        }
        public SQLite.SQLiteConnection GetSQLiteConnection()
        {
            var fileName = "UserDatabase.db3";
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, fileName);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}