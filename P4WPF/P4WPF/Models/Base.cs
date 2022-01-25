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

        public Users ReadRole( Users users)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                MySqlCommand sql = _connection.CreateCommand();
                sql.CommandText = @" 
                        SELECT u.id, u.name, u.password, r.id AS 'role_id' , r.name AS 'role_name' 
                        FROM users u
                        INNER JOIN user_roles ur ON ur.user_id = u.id
                        INNER JOIN roles r ON ur.role_id = r.id
                         WHERE u.Name=@name";
                sql.Parameters.AddWithValue("@name", users.Name);
    
                MySqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    if (BCrypt.Net.BCrypt.Verify( users.Password, (string)reader["password"]))
                    {
                        Users login = new Users();
                        login.Name = (string)reader["name"];
                        login.Password = (string)reader["password"];
                        login.ID = (ulong)reader["id"];
                        login.Role_ID = (ulong)reader["role_id"]; 
                        login.Role_Name = (string)reader["role_name"];
                        return login;

                    }


                }
                
                
            }
            catch (Exception ex)
            {
                // iets doen want fout
                return null;
            }
            finally
            {
                _connection.Close();
            }
            return null;
        }
        public List<Orders> GetAllOrders()
        {
            List<Orders> result = new List<Orders>();
            try
            {
                _connection.Open();
                MySqlCommand sql = _connection.CreateCommand();
                sql.CommandText = "SELECT *  FROM orders";
                MySqlDataReader reader = sql.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                foreach (DataRow row in table.Rows)
                {
                    Orders orders = new Orders();
                    orders.Status_ID = (int)row["status_id"];
                    orders.Pizza_ID = (int)row["pizza_id"];
                    orders.User_ID = (int)row["user_id"];
                    result.Add(orders);
                }

            }
            catch (Exception e)
            {

                Console.Write(e.Message);
                return null;
            }

            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return result;
        }
        //public bool SaveKlant()
        //{
        //    bool result = true;
        //    try
        //    {
        //        if (_connection.State == ConnectionState.Closed)
        //        {
        //            _connection.Open();
        //        }
        //        MySqlCommand sql = _connection.CreateCommand();
        //        sql.CommandText =
        //            @"INSERT INTO 
        //                ()
        //                VALUES
        //                ();";


        //        sql.Parameters.AddWithValue("", );
        //        sql.Parameters.AddWithValue("", );
        //        sql.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("******");
        //        Console.WriteLine(e.Message);
        //        result = false;
        //    }

        //    finally
        //    {
        //        if (_connection.State == ConnectionState.Open)
        //        {
        //            _connection.Close();
        //        }
        //    }
        //    return result;
        //}
        //public void DeleteFavCountry()
        //{
        //    _connection.Open();
        //    MySqlCommand cmd = _connection.CreateCommand();
        //    if ( > 0)
        //    {
        //        cmd.CommandText = "DELETE FROM  Where  = ";
        //    }

        //    cmd.Parameters.AddWithValue("", );
        //    cmd.ExecuteNonQuery();
        //    _connection.Close();
        //}

    }
}


