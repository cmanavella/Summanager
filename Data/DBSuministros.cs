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
        /// <summary>
        /// Obtiene una Lista de todos los Suministros desde la Base de Datos.
        /// </summary>
        /// <returns></returns>
        public static List<Suministro> GetSuministro()
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
                            var suministro = new Suministro();

                            suministro.Codigo = Convert.ToInt64(reader["Codigo"].ToString());
                            suministro.Nombre = reader["Nombre"].ToString();
                            suministro.Tipo = DBTiposSuministros.GetTipo(Convert.ToInt32(reader["IdTipoSuministro"].ToString()));
                            suministro.Modelos = DBModelosImpresoras.GetModelo(Convert.ToInt64(reader["Codigo"].ToString()));

                            retorno.Add(suministro);
                        }
                    }
                }
            }

            return retorno;
        }

        /// <summary>
        /// Obtiene un Suministro desde la Base de Datos a partir de su Código.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static Suministro GetSuministro(Int64 codigo)
        {
            Suministro retorno = null;

            using (var con = DBContext.GetInstance())
            {
                var query = "SELECT * FROM Suministros WHERE Codigo=" + codigo;

                using (var command = new SQLiteCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            retorno = new Suministro();
                            retorno.Codigo = Convert.ToInt64(reader["Codigo"].ToString());
                            retorno.Nombre = reader["Nombre"].ToString();
                            retorno.Tipo = DBTiposSuministros.GetTipo(Convert.ToInt32(reader["IdTipoSuministro"].ToString()));
                            retorno.Modelos = DBModelosImpresoras.GetModelo(Convert.ToInt64(reader["Codigo"].ToString()));
                        }
                    }
                }
            }

            return retorno;
        }
    }
}
