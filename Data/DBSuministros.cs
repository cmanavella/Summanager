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
                            suministro.Tipo = DBTiposSuministros.GetTipos(Convert.ToInt32(reader["IdTipoSuministro"].ToString()));
                            suministro.Modelos = DBModelosImpresoras.GetModelos(Convert.ToInt64(reader["Codigo"].ToString()));

                            retorno.Add(suministro);
                        }
                    }
                }
            }

            return retorno;
        }
    }
}
