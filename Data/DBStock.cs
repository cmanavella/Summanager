using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public class DBStock
    {
        /// <summary>
        /// Devuelve una Lista de Stock de todos los Suministros de la Base de Datos.
        /// </summary>
        /// <returns>Una Lista de Stock de todos los Suministros de la Base de Datos o NULL si no encuentra nada.</returns>
        public static List<Stock> GetStock()
        {
            List<Stock> retorno = new List<Stock>();

            using (var con = DBContext.GetInstance())
            {
                var query = "SELECT * FROM Stock";

                using (var command = new SQLiteCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var stock = new Stock();

                            stock.Suministro = DBSuministros.GetSuministro(Convert.ToInt64(reader["Codigo"].ToString()));
                            stock.Alta = Convert.ToInt32(reader["Alta"].ToString());
                            stock.Baja = Convert.ToInt32(reader["Baja"].ToString());
                            stock.Fallado = Convert.ToInt32(reader["Fallado"].ToString());

                            retorno.Add(stock);
                        }
                    }
                }
            }

            //Si no encuentro ningún stock, devuelvo null.
            if (retorno.Count == 0) retorno = null;
            return retorno;
        }
    }
}
