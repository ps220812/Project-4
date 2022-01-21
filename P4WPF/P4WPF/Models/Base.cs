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

    }
}


