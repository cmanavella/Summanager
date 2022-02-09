using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SQLite;

namespace Data
{
    public class DBTiposSuministros
    {
        public static List<TipoSuministro> GetTipos()
        {
            var retorno = new List<TipoSuministro>();

            using (var con = DBContext.GetInstance())
            {
                var query = "SELECT * FROM Tipos_Suministros";

                using (var command = new SQLiteCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tipo = new TipoSuministro();
                            tipo.Id = Convert.ToInt32(reader["Id"].ToString());
                            tipo.Nombre = reader["Nombre"].ToString();

                            retorno.Add(tipo);
                        }
                    }
                }
            }

            return retorno;
        }

        public static TipoSuministro GetTipos(int id)
        {
            var retorno = new TipoSuministro();

            using (var con = DBContext.GetInstance())
            {
                var query = "SELECT * FROM Tipos_Suministros WHERE Id=" + id;

                using (var command = new SQLiteCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            retorno.Id = Convert.ToInt32(reader["Id"].ToString()); 
                            retorno.Nombre = reader["Nombre"].ToString();
                        }
                    }
                }
            }

            return retorno;
        }
    }
}
