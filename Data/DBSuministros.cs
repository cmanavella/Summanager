using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Data
{
    public class DBSuministros
    {
        public static List<Suministro> GetSuministros()
        {
            var retorno = new List<Suministro>();

            using (var con = DBContext.GetInstance())
            {
                var query = "SELECT * FROM Suministros";

                using (var command = new SQLiteCommand(query, con))
                {
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retorno.Add(new Suministro(Convert.ToInt64(reader["Codigo"].ToString()), reader["Nombre"].ToString()));
                        }
                    }
                }
            }

            return retorno;
        }
    }
}
