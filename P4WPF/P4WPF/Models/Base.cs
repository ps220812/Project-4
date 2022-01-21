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
                sql.CommandText = @" SELECT * FROM users WHERE Name=@name";

    
                MySqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    if (BCrypt.Net.BCrypt.Verify( users.Password, (string)reader["password"]))
                    {
                        return true;
                    }

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
            return false;
        }
        public bool VerifyUser(Users users)
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
            MySqlCommand sql = _connection.CreateCommand();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@admin_id", adminId);
            cmd.Parameters.AddWithValue("@password", password);

            SqlDataReader dr = cmd.ExecuteReader();
            if (read.Read())
            {
                if (Convert.ToBoolean(read["id"]) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {

            }
        }


    }
    
}
