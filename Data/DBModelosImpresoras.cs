using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SQLite;

namespace Data
{
    public class DBModelosImpresoras
    {
        public static List<Modelo> GetModelos()
        {
            var retorno = new List<Modelo>();

            using (var con = DBContext.GetInstance())
            {
                var query = "SELECT * FROM Modelos_Impresoras";

                using (var command = new SQLiteCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var modelo = new Modelo();

                            modelo.Id = Convert.ToInt32(reader["Id"].ToString());
                            modelo.Nombre = reader["Nombre"].ToString();

                            retorno.Add(modelo);
                        }
                    }
                }
            }

            return retorno;
        }
        
        public static List<Modelo> GetModelos(Int64 codigoSuministro)
        {
            var retorno = new List<Modelo>();

            using (var con = DBContext.GetInstance())
            {
                var query = "SELECT Suministros_X_Modelos.IdModelo AS 'Id', Modelos_Impresoras.Nombre AS 'Nombre' FROM " +
                    "Suministros_X_Modelos INNER JOIN Modelos_Impresoras on Suministros_X_Modelos.IdModelo = Modelos_Impresoras.Id " +
                    "WHERE Suministros_X_Modelos.CodigoSuministro = " + codigoSuministro;

                using (var command = new SQLiteCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var modelo = new Modelo();

                            modelo.Id = Convert.ToInt32(reader["Id"].ToString());
                            modelo.Nombre = reader["Nombre"].ToString();

                            retorno.Add(modelo);
                        }
                    }
                }
            }

            return retorno;
        }
    }
}
