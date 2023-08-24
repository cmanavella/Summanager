using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Security.Cryptography;
using CustomExceptions;

namespace Data
{
    public class DBUsers
    {
        ///// <summary>
        ///// Loguea a un Usuario en la Base de Datos si coinciden su Niick y Password.
        ///// </summary>
        ///// <param name="nick">Nombre de Usuario</param>
        ///// <param name="password">Contraseña</param>
        //public static void LogIn(string nick, string password)
        //{
        //    password = _getMD5(password);
        //    bool userRead = false;

        //    using (var con = DBContext.GetInstance())
        //    {
        //        string query = "SELECT * FROM Usuarios WHERE Nick = '" + nick + "' AND Password = '" + password + "'";

        //        using(var command = new SQLiteCommand(query, con))
        //        {
        //            using(var reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    User.Id = Convert.ToInt32(reader["Id"].ToString());
        //                    User.Nombre = reader["Nombre"].ToString();
        //                    User.Nick = reader["Nick"].ToString();
        //                    User.Password = reader["Password"].ToString();
        //                    userRead = true;
        //                }
        //                else
        //                {
        //                    User.Id = 0;
        //                    User.Nombre = String.Empty;
        //                    User.Nick = String.Empty;
        //                    User.Password = String.Empty;
        //                    User.IsLogged = false;
        //                }
        //            }

        //            if (userRead)
        //            {
        //                command.CommandText = "UPDATE Usuarios SET IsLogged = 1";
        //                command.ExecuteNonQuery();

        //                User.IsLogged = true;
        //            }

        //            if (!User.IsLogged) throw new LogInException();
        //        }
        //    }
        //}

        ///// <summary>
        ///// Busca en la Base de Datos un Usuario Logueado.
        ///// </summary>
        //public static void FindLogin()
        //{
        //    using (var con = DBContext.GetInstance())
        //    {
        //        string query = "SELECT * FROM Usuarios WHERE IsLogged = 1";

        //        using (var command = new SQLiteCommand(query, con))
        //        {
        //            using (var reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    User.Id = Convert.ToInt32(reader["Id"].ToString());
        //                    User.Nombre = reader["Nombre"].ToString();
        //                    User.Nick = reader["Nick"].ToString();
        //                    User.Password = reader["Password"].ToString();
        //                    User.IsLogged = true;
        //                }
        //                else
        //                {
        //                    User.Id = 0;
        //                    User.Nombre = String.Empty;
        //                    User.Nick = String.Empty;
        //                    User.Password = String.Empty;
        //                    User.IsLogged = false;
        //                }
        //            }
        //        }
        //    }
        //}

        //public static void LogOut()
        //{
        //    if (User.IsLogged)
        //    {
        //        using (var con = DBContext.GetInstance())
        //        {
        //            string query = "UPDATE Usuarios SET IsLogged = 0 WHERE IsLogged = 1";

        //            using (var command = new SQLiteCommand(query, con))
        //            {
        //                command.ExecuteNonQuery();
                        
        //                User.Id = 0;
        //                User.Nombre = String.Empty;
        //                User.Nick = String.Empty;
        //                User.Password = String.Empty;
        //                User.IsLogged = false;
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Devuelve un Hash MD5 de un String pasado por parámetro.
        ///// </summary>
        ///// <param name="value">String a convertir.</param>
        ///// <returns>Un Hash MD5 de un String pasado por parámetro.</returns>
        //private static string _getMD5(string value)
        //{
        //    using (var md5Hash = MD5.Create())
        //    {
        //        var sourceBytes = Encoding.UTF8.GetBytes(value);

        //        var hashBytes = md5Hash.ComputeHash(sourceBytes);

        //        value = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        //    }

        //    return value;
        //}
    }
}
