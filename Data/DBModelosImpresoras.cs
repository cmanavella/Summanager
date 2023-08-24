using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public class DBModelosImpresoras
    {
        ///// <summary>
        ///// Obtiene una Lista de todos los Modelos de Impresoras desde la Base de Datos.
        ///// </summary>
        ///// <returns></returns>
        //public static List<Modelo> GetModelo()
        //{
        //    var retorno = new List<Modelo>();

        //    using (var con = DBContext.GetInstance())
        //    {
        //        var query = "SELECT * FROM Modelos_Impresoras";

        //        using (var command = new SQLiteCommand(query, con))
        //        {
        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var modelo = new Modelo();

        //                    modelo.Id = Convert.ToInt32(reader["Id"].ToString());
        //                    modelo.Nombre = reader["Nombre"].ToString();

        //                    retorno.Add(modelo);
        //                }
        //            }
        //        }
        //    }

        //    return retorno;
        //}

        ///// <summary>
        ///// Obtiene una Lista de los Modelos de Impresoras relacionados con un Suministro en particular desde la Base de Datos .
        ///// </summary>
        ///// <param name="codigoSuministro"></param>
        ///// <returns></returns>
        //public static List<Modelo> GetModelo(Int64 codigoSuministro)
        //{
        //    var retorno = new List<Modelo>();

        //    using (var con = DBContext.GetInstance())
        //    {
        //        var query = "SELECT Suministros_X_Modelos.IdModelo AS 'Id', Modelos_Impresoras.Nombre AS 'Nombre' FROM " +
        //            "Suministros_X_Modelos INNER JOIN Modelos_Impresoras on Suministros_X_Modelos.IdModelo = Modelos_Impresoras.Id " +
        //            "WHERE Suministros_X_Modelos.CodigoSuministro = " + codigoSuministro;

        //        using (var command = new SQLiteCommand(query, con))
        //        {
        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var modelo = new Modelo();

        //                    modelo.Id = Convert.ToInt32(reader["Id"].ToString());
        //                    modelo.Nombre = reader["Nombre"].ToString();

        //                    retorno.Add(modelo);
        //                }
        //            }
        //        }
        //    }

        //    return retorno;
        //}
    }
}
