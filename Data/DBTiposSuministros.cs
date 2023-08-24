using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public class DBTiposSuministros
    {
        ///// <summary>
        ///// Obtiene una Lista de todos los Tipos de Suministro desde la Base de Datos.
        ///// </summary>
        ///// <returns></returns>
        //public static List<TipoSuministro> GetTipo()
        //{
        //    var retorno = new List<TipoSuministro>();

        //    using (var con = DBContext.GetInstance())
        //    {
        //        var query = "SELECT * FROM Tipos_Suministros";

        //        using (var command = new SQLiteCommand(query, con))
        //        {
        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var tipo = new TipoSuministro();
        //                    tipo.Id = Convert.ToInt32(reader["Id"].ToString());
        //                    tipo.Nombre = reader["Nombre"].ToString();

        //                    retorno.Add(tipo);
        //                }
        //            }
        //        }
        //    }

        //    return retorno;
        //}

        ///// <summary>
        ///// Obtiene un Tipo de Suministro desde la Base de Datos a partir de su Id.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public static TipoSuministro GetTipo(int id)
        //{
        //    var retorno = new TipoSuministro();

        //    using (var con = DBContext.GetInstance())
        //    {
        //        var query = "SELECT * FROM Tipos_Suministros WHERE Id=" + id;

        //        using (var command = new SQLiteCommand(query, con))
        //        {
        //            using (var reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    retorno.Id = Convert.ToInt32(reader["Id"].ToString()); 
        //                    retorno.Nombre = reader["Nombre"].ToString();
        //                }
        //            }
        //        }
        //    }

        //    return retorno;
        //}
    }
}
