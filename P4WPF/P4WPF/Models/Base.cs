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

        public Users ReadRole(Users users)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                MySqlCommand sql = _connection.CreateCommand();
                sql.CommandText = @" 
                        SELECT u.id, u.email, u.password, r.id AS 'role_id' , r.name AS 'role_name' 
                        FROM users u
                        INNER JOIN user_roles ur ON ur.user_id = u.id
                        INNER JOIN roles r ON ur.role_id = r.id
                         WHERE u.Email=@email";
                sql.Parameters.AddWithValue("@email", users.Email);

                MySqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {

                    if (BCrypt.Net.BCrypt.Verify(users.Password, (string)reader["password"]))
                    {
                        Users login = new Users();
                        login.Email = (string)reader["email"];
                        login.Password = (string)reader["password"];
                        login.ID = (ulong)reader["id"];
                        login.Role_ID = (ulong)reader["role_id"];
                        login.Role_Name = (string)reader["role_name"];
                        if (login.Role_ID >= 2)
                        {
                            return login;
                        }


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
        public Users ReadForM(Users users)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                MySqlCommand sql = _connection.CreateCommand();
                sql.CommandText = @" 
                        SELECT u.id, u.email, u.password, r.id AS 'role_id' , r.name AS 'role_name' 
                        FROM users u
                        INNER JOIN user_roles ur ON ur.user_id = u.id
                        INNER JOIN roles r ON ur.role_id = r.id
                         WHERE u.Email=@email";
                sql.Parameters.AddWithValue("@email", users.Email);

                MySqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {

                    if (BCrypt.Net.BCrypt.Verify(users.Password, (string)reader["password"]))
                    {
                        Users login = new Users();
                        login.Email = (string)reader["email"];
                        login.Password = (string)reader["password"];
                        login.ID = (ulong)reader["id"];
                        login.Role_ID = (ulong)reader["role_id"];
                        login.Role_Name = (string)reader["role_name"];
                        if (login.Role_ID >= 5)
                        {
                            return login;
                        }


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
                sql.CommandText =
                    @"SELECT o.id, o.status_id, o.pizza_id,  o.user_id, p.id AS ' pizza_id', p.pizza_name, os.id AS 'status_id', os.status
                    FROM orders o
                    INNER JOIN pizzas p ON p.id = o.pizza_id
                    INNER JOIN order_status os ON os.id = o.status_id";
                MySqlDataReader reader = sql.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                foreach (DataRow row in table.Rows)
                {
                    Orders Order = new Orders();
                    Order.ID = (ulong)row["id"];
                    Order.Status_ID = (ulong)row["status_id"];
                    Order.Pizza_ID = (ulong)row["pizza_id"];
                    Order.Status = (string)row["status"];
                    Order.Pizza_Name = (string)row["pizza_name"];
                    result.Add(Order);
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
        public bool UpdateOrderStatus(Orders orders)
        {
            bool result = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText =
                    @"UPDATE `orders` SET `status_id` = @status_id  WHERE `orders`.`id` = @id";


                command.Parameters.AddWithValue("@id", orders.ID);

                switch (orders.Status_ID)
                {
                    case 1:
                        command.Parameters.AddWithValue("@status_id", "2");
                        result = command.ExecuteNonQuery() >= 1;
                        break;
                    case 2:
                        command.Parameters.AddWithValue("@status_id", "3");
                        result = command.ExecuteNonQuery() >= 1;
                        break;
                    default:

                        break;
                }


            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return false;
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
        public List<Ingredient> GetAllingredients()
        {
            List<Ingredient> result = new List<Ingredient>();
            try
            {
                _connection.Open();
                MySqlCommand sql = _connection.CreateCommand();
                sql.CommandText =
                    @"SELECT i.id, i.quantity, i.unit_id, i.ingredient_id, i.price, ing.id AS 'ingredient_id', ing.ingredient, u.id AS 'unit_id',u.unit_name
                      FROM items i 
                      INNER JOIN ingredients ing ON ing.id = i.ingredient_id 
                      INNER JOIN units u ON u.id = i.unit_id";
                MySqlDataReader reader = sql.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                foreach (DataRow row in table.Rows)
                {
                    Ingredient Item = new Ingredient();
                    Item.ID = (ulong)row["id"];
                    Item.IngredientName = (string)row["ingredient"];
                    Item.IngredientID = (ulong)row["ingredient_id"];
                    Item.Unit = (ulong)row["unit_id"];
                    Item.Quantity = (int)row["quantity"];
                    Item.Price = (int)row["price"];
                    Item.Unit_Name = (string)row["unit_name"];
                    result.Add(Item);
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
        public bool SaveItem(Ingredient ingredients)
        {
            bool result = true;
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlCommand sql = _connection.CreateCommand();
                sql.CommandText =
                    @"INSERT INTO `items` (quantity, unit_id, ingredient_id, price) 
                      VALUES 
                      (@qauntity, @unit_id, @ingredient_id, @price);";


                sql.Parameters.AddWithValue("@quantity", ingredients.Quantity);
                sql.Parameters.AddWithValue("@ingredient_id", ingredients.IngredientID);
                sql.Parameters.AddWithValue("@unit_id", ingredients.Unit);
                sql.Parameters.AddWithValue("@price", ingredients.Price);

                sql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("***InsertIntoItems***");
                Console.WriteLine(e.Message);
                result = false;
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
        public void DeleteIngredients(Ingredient ingredients)
        {
            _connection.Open();
            MySqlCommand cmd = _connection.CreateCommand();
            if (ingredients.ID >= 0)
            {
                cmd.CommandText = "DELETE FROM items WHERE ID= @id";

            }

            cmd.Parameters.AddWithValue("@id", ingredients.ID);
            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        public bool UpdateItem(Ingredient ingredients)
        {
            bool result = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText =
                    @"UPDATE `` SET `id`=@id,`quantity`=@qauntity,`unit`=@unit,`ingredient`=@ingredient,`price`=@price WHERE `id` = @id";


                command.Parameters.AddWithValue("@id", ingredients.ID);
                command.Parameters.AddWithValue("@quantity", ingredients.Quantity);
                command.Parameters.AddWithValue("@unit", ingredients.Unit);
                command.Parameters.AddWithValue("@ingredient", ingredients.IngredientID);
                command.Parameters.AddWithValue("@price", ingredients.Price);
                result = command.ExecuteNonQuery() >= 1;


            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return false;
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
        public bool SaveIngredient(Ingredient ingredients)
        {
            bool result = true;
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlCommand sql = _connection.CreateCommand();
                sql.CommandText =
                    @"INSERT INTO `ingredients` (ingredient) 
                      VALUES 
                      (@ingredient);";


                sql.Parameters.AddWithValue("@ingredient", ingredients.IngredientName);


                sql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("***InsertIntoingredients***");
                Console.WriteLine(e.Message);
                result = false;
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

        public List<unit> GetUnit()
        {
            List<unit> result = new List<unit>();
            try
            {
                _connection.Open();
                MySqlCommand sql = _connection.CreateCommand();
                sql.CommandText =
                    @"SELECT u.unit_name, u.id 
                      FROM units u";
                MySqlDataReader reader = sql.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                foreach (DataRow row in table.Rows)
                {
                    unit Item = new unit();
                    Item.ID = (ulong)row["id"];
                    Item.Unit_Name = (string)row["unit_name"];
                    result.Add(Item);
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
        public void DeleteUnit(unit units)
        {
            _connection.Open();
            MySqlCommand cmd = _connection.CreateCommand();
            if (units.ID >= 0)
            {
                cmd.CommandText = "DELETE FROM units WHERE ID= @id";

            }

            cmd.Parameters.AddWithValue("@id", units.ID);
            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        public bool SaveUnit(unit units)
        {
            bool result = true;
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlCommand sql = _connection.CreateCommand();
                sql.CommandText =
                    @"INSERT INTO `units` (unit_name) 
                      VALUES 
                      (@unit_name);";


                sql.Parameters.AddWithValue("@unit_name", units.Unit_Name);


                sql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("***InsertIntoUnit***");
                Console.WriteLine(e.Message);
                result = false;
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

    }

}



