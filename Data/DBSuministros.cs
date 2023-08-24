using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DBSuministros
    {
        ///// <summary>
        ///// Agrega un Suministro a la Base de Datos.
        ///// </summary>
        ///// <param name="suministro"></param>
        //public static void Add(Suministro suministro)
        //{
        //    using(var con = DBContext.GetInstance())
        //    {
        //        using(var transaction = con.BeginTransaction())
        //        {
        //            string query = "INSERT INTO Suministros (Codigo, Nombre, IdTipoSuministro) VALUES (" +
        //                suministro.Codigo.ToString() + ", '" + suministro.Nombre + "', " + suministro.Tipo.Id.ToString() + ")";

        //            try
        //            {
        //                using (var command = new SQLiteCommand(query, con))
        //                {
        //                    command.ExecuteNonQuery();

        //                    foreach(Modelo modelo in suministro.Modelos)
        //                    {
        //                        query = "INSERT INTO Suministros_X_Modelos (CodigoSuministro, IdModelo) VALUES (" +
        //                            suministro.Codigo.ToString() + ", " + modelo.Id + ")";

        //                        command.CommandText = query;
        //                        command.ExecuteNonQuery();
        //                    }

        //                    transaction.Commit();
        //                }
        //            }catch(Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw ex;
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Obtiene una Lista de todos los Suministros desde la Base de Datos.
        ///// </summary>
        ///// <returns></returns>
        //public static List<Suministro> GetSuministro()
        //{
        //    var retorno = new List<Suministro>();

        //    using (var con = DBContext.GetInstance())
        //    {
        //        var query = "SELECT * FROM Suministros";

        //        using (var command = new SQLiteCommand(query, con))
        //        {
        //            using(var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var suministro = new Suministro();

        //                    suministro.Codigo = Convert.ToInt64(reader["Codigo"].ToString());
        //                    suministro.Nombre = reader["Nombre"].ToString();
        //                    suministro.Tipo = DBTiposSuministros.GetTipo(Convert.ToInt32(reader["IdTipoSuministro"].ToString()));
        //                    suministro.Modelos = DBModelosImpresoras.GetModelo(Convert.ToInt64(reader["Codigo"].ToString()));

        //                    retorno.Add(suministro);
        //                }
        //            }
        //        }
        //    }

        //    return retorno;
        //}

        ///// <summary>
        ///// Obtiene una Lista de Suministros desde la Base de Datos a partir de su Nombre.
        ///// </summary>
        ///// <param name="nombre"></param>
        ///// <returns></returns>
        //public static List<Suministro> GetSuministro(string nombre)
        //{
        //    nombre = nombre.ToUpper();
        //    var retorno = new List<Suministro>();

        //    using (var con = DBContext.GetInstance())
        //    {
        //        var query = "SELECT * FROM Suministros WHERE Nombre LIKE '%" + nombre + "%'";

        //        using (var command = new SQLiteCommand(query, con))
        //        {
        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var suministro = new Suministro();

        //                    suministro.Codigo = Convert.ToInt64(reader["Codigo"].ToString());
        //                    suministro.Nombre = reader["Nombre"].ToString();
        //                    suministro.Tipo = DBTiposSuministros.GetTipo(Convert.ToInt32(reader["IdTipoSuministro"].ToString()));
        //                    suministro.Modelos = DBModelosImpresoras.GetModelo(Convert.ToInt64(reader["Codigo"].ToString()));

        //                    retorno.Add(suministro);
        //                }
        //            }
        //        }
        //    }

        //    if (retorno.Count == 0) retorno = null;
        //    return retorno;
        //}

        ///// <summary>
        ///// Obtiene una Lista de Suministros desde la Base de Datos a partir del nombre del Modelo de Impresora con el que es compatible.
        ///// </summary>
        ///// <param name="nombre"></param>
        ///// <returns></returns>
        //public static List<Suministro> GetSuministroByModelo(string nombre)
        //{
        //    var retorno = new List<Suministro>();

        //    using (var con = DBContext.GetInstance())
        //    {
        //        var query = "SELECT Suministros.Codigo, Suministros.Nombre, Suministros.IdTipoSuministro FROM Suministros INNER JOIN " +
        //            "Suministros_X_Modelos ON Suministros.Codigo = Suministros_X_Modelos.CodigoSuministro INNER JOIN Modelos_Impresoras ON " +
        //            "Suministros_X_Modelos.IdModelo = Modelos_Impresoras.Id WHERE Modelos_Impresoras.Nombre LIKE '%" + nombre + "%' GROUP BY Suministros.Codigo";

        //        using (var command = new SQLiteCommand(query, con))
        //        {
        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var suministro = new Suministro();

        //                    suministro.Codigo = Convert.ToInt64(reader["Codigo"].ToString());
        //                    suministro.Nombre = reader["Nombre"].ToString();
        //                    suministro.Tipo = DBTiposSuministros.GetTipo(Convert.ToInt32(reader["IdTipoSuministro"].ToString()));
        //                    suministro.Modelos = DBModelosImpresoras.GetModelo(Convert.ToInt64(reader["Codigo"].ToString()));

        //                    retorno.Add(suministro);
        //                }
        //            }
        //        }
        //    }

        //    if (retorno.Count == 0) retorno = null;
        //    return retorno;
        //}

        ///// <summary>
        ///// Obtiene un Suministro desde la Base de Datos a partir de su Código.
        ///// </summary>
        ///// <param name="codigo"></param>
        ///// <returns></returns>
        //public static Suministro GetSuministro(Int64 codigo)
        //{
        //    Suministro retorno = null;

        //    using (var con = DBContext.GetInstance())
        //    {
        //        var query = "SELECT * FROM Suministros WHERE Codigo=" + codigo;

        //        using (var command = new SQLiteCommand(query, con))
        //        {
        //            using (var reader = command.ExecuteReader())
        //            {
        //                retorno = new Suministro();
        //                if (reader.Read())
        //                {
        //                    retorno.Codigo = Convert.ToInt64(reader["Codigo"].ToString());
        //                    retorno.Nombre = reader["Nombre"].ToString();
        //                    retorno.Tipo = DBTiposSuministros.GetTipo(Convert.ToInt32(reader["IdTipoSuministro"].ToString()));
        //                    retorno.Modelos = DBModelosImpresoras.GetModelo(Convert.ToInt64(reader["Codigo"].ToString()));
        //                }
        //                else
        //                {
        //                    retorno = null;
        //                }
        //            }
        //        }
        //    }

        //    return retorno;
        //}
    }
}
