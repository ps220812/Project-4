using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace P4WPF.Models
{
    public class Base
    {
        MySqlConnection _connection = new MySqlConnection("Server=localhost;Database=project4;Uid=root;Pwd=;");


        public bool ReadRole( Users users)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                MySqlCommand sql = _connection.CreateCommand();
                sql.CommandText = @" SELECT COUNT(1) FROM users WHERE Name=@name AND Password=@password";
                sql.Parameters.AddWithValue("@name", users.Name);
                sql.Parameters.AddWithValue("@password", users.Password);
                long count = Convert.ToInt32(sql.ExecuteScalar());
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // iets doen want fout
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }
        //            List<Klanten> result = new List<Klanten>();
        //    try
        //    {
        //        _conn.Open();
        //        SqlCommand sql = _conn.CreateCommand();
        //        sql.CommandText = "SELECT *  FROM dbo.tblGuest";
        //        SqlDataReader reader = sql.ExecuteReader();
        //        DataTable table = new DataTable();
        //        table.Load(reader);
        //        foreach (DataRow row in table.Rows)
        //        {
        //            Klanten klant = new Klanten();
        //            klant.Codeg = (int)row["codeG"];
        //            klant.voornaam = (string)row["Voornaam"];
        //            klant.achternaam = (string)row["Achternaam"];
        //            result.Add(klant);
        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        Console.Write(e.Message);
        //        return null;
        //    }
        //    finally
        //    {
        //        if (_conn.State == ConnectionState.Open)
        //        {
        //            _conn.Close();
        //        }
        //    }

        //    return result;
        //}


    }
    
}
