using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace Data
{
    public class DBContext
    {
        private static string connectionString = "Data Source=" + Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\data.sqlite;Version=3;";
        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(connectionString);

            db.Open();

            return db;
        }
    }
}
