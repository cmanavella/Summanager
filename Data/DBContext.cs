using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace Data
{
    public class DBContext
    {
        //String de conexión.
        private static string connectionString = "Data Source=" + Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\data.sqlite;";

        /// <summary>
        /// Devuelve una instancia de la conexión a la Base de Datos ya abierta.
        /// </summary>
        /// <returns>SQLiteConnection</returns>
        public static SQLiteConnection GetInstance()
        {
            //Creo la variable de Base de Datos con el string de conexión.
            var db = new SQLiteConnection(connectionString);

            //Abro la Base de Datos.
            db.Open();

            //Devuelvo la Base de Datos.
            return db;
        }
    }
}
