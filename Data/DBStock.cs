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

                            stock.Suministro = DBSuministros.GetSuministro(Convert.ToInt64(reader["Codigo_Suministro"].ToString()));
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

        /// <summary>
        /// Actualiza uno o varios Stock en la Base de Datos, de acuerdo al Estado que se quiere actualizar.
        /// </summary>
        /// <param name="stocks">Una Lista de Stocks a actualizar.</param>
        /// <param name="estado">La cantidad que se quiere actualizar, es decir cantidad de alta, de baja o de fallado.</param>
        public static void AddStock(List<Stock> stocks, Stock.ESTADO estado)
        {
            using (var con = DBContext.GetInstance())
            {
                //Como es una Lista de Stock los que voy a actualizar, hago una Transaction en caso que suceda algo no impacte en la BD.
                using (var transaction = con.BeginTransaction())
                {
                    //Hago un Try, ya que a partir de ahora pueden ocurrir errores.
                    try
                    {
                        using (var command = new SQLiteCommand(con))
                        {
                            //Creo una Query con un String vacío
                            var query = string.Empty;

                            //Recorro la Lista de Stock para hacer lo siguiente: Por cada Stock pasado me fijo que exista en la Base de Datos.
                            //Si existe actualizo sus valores, sino creo un nuevo registro en la misma.
                            foreach (Stock stock in stocks)
                            {
                                //Para crear el Query primero me tengo que fijar que cantidad de Stock quiero almacenar (Alta, Baja o Fallado).
                                switch (estado)
                                {
                                    case Stock.ESTADO.ALTA:
                                        //Si es la cantidad Alta la que quiero modificar, consulto si el Stock existe en la Base de Datos.
                                        if (!_existeStock(stock.Suministro.Codigo))
                                        {
                                            //Si no existe, creo la Query con un SQL de Adición, donde solo paso como valor numérico la Cantidad de Alta.
                                            //Las demás cantidades las paso en 0.
                                            query = "INSERT INTO Stock (Codigo_Suministro, Alta, Baja, Fallado) VALUES(" + stock.Suministro.Codigo +
                                                ", " + stock.Alta + ", 0, 0)";
                                        }
                                        else
                                        {
                                            //Si existe, creo la Query con un SQL de Actualización, donde solo paso como valor numérico la Cantidad de Alta.
                                            //Las demás cantidades las paso en 0. Además sumo la Cantidad de Alta almacenada en la Base de Datos a la pasada
                                            //por parámetro.
                                            query = "UPDATE Stock SET Alta = " + (_getCantidadAlta(stock.Suministro.Codigo) + stock.Alta) + 
                                                " WHERE Codigo_Suministro = " + stock.Suministro.Codigo;
                                        }
                                        break; //Salgo del Case.
                                }

                                //Paso la Query al Command y luego la ejecuto.
                                command.CommandText = query;
                                command.ExecuteNonQuery();
                            }

                            //Una vez que he ejecutado todas las Query y llegué a este punto, confirmo la Transacción así se impacta en la Base de Datos.
                            transaction.Commit();
                        }
                    }catch(Exception ex)
                    {
                        //Si hubo un error cancelo la Transaction para que no se impacte nada en la Base de Datos.
                        transaction.Rollback();
                        //Envío la Excepción para que en el FrontEnd pueda ser capturada.
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Devuelve la Cantidad de Alta de un Stock específico en base a su Código
        /// </summary>
        /// <param name="codigo">Código del Stock donde se requiere buscar la Cantidad de Alta.</param>
        /// <returns></returns>
        private static int _getCantidadAlta(Int64 codigo)
        {
            int retorno = 0;

            using (var con = DBContext.GetInstance())
            {
                var query = "SELECT Alta FROM Stock WHERE Codigo_Suministro = " + codigo;

                using (var command = new SQLiteCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read()) retorno = Convert.ToInt32(reader["Alta"].ToString());
                    }
                }
            }

            return retorno;
        }

        /// <summary>
        /// Devuelve True si existe un Stock específico almacenado ya en la Base de Datos. Caso contrario, devuelve False.
        /// </summary>
        /// <param name="codigo">Código del Stock a buscar.</param>
        /// <returns>True si se encuentra el Stock en la Base de Datos. False si no lo encuentra.</returns>
        private static bool _existeStock(Int64 codigo)
        {
            bool retorno = false;

            using (var con = DBContext.GetInstance())
            {
                var query = "SELECT Codigo_Suministro FROM Stock WHERE Codigo_Suministro = " + codigo;

                using (var command = new SQLiteCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        retorno = reader.Read();
                    }
                }
            }

            return retorno;
        }
    }
}
