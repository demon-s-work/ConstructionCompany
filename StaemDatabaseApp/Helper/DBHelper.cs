using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StaemDatabaseApp.Helper
{
    public static class DBHelper
    {
        private static MySqlConnection connection;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static void EstablishConnection()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "127.0.0.1";
                builder.UserID = "root";
                builder.Password = "root";
                builder.Database = "staem";
                builder.SslMode = MySqlSslMode.Required;
                connection = new MySqlConnection(builder.ToString());
                connection.Open();
                MessageBox.Show("Database connection successfull", "Connection", MessageBoxButton.OK);
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.", "Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username or password, try again.", "Authorization", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;

                }
            }
        }

        public static bool ConnectToDatabase(string login, string password)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.UserID = login;
            builder.Password = password;
            builder.Database = "staem";
            builder.SslMode = MySqlSslMode.None;
            connection = new MySqlConnection(builder.ToString());

            try
            {
                connection.Open();

                // Jezeli brak wyjątku -> dane logowania dobre
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1045:
                        MessageBox.Show("Cannot connect to server.", "Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case 0:
                        MessageBox.Show("Invalid username or password, try again.", "Authorization", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    default:
                        MessageBox.Show("Unknown error." + "\n" + ex.Message, "Unknown", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static MySqlCommand RunQueryNoParameters(string query)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return cmd;
        }

        public static MySqlCommand RunQueryWithID(string query, int id)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return cmd;
        }

        public static MySqlCommand RunQuery(string query, string parameter, string value)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue(parameter, value);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return cmd;
        }

        public static MySqlCommand RunQueryWithParamList(string query, Dictionary<string, string> paramValuePair)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    foreach(var pvp in paramValuePair)
                    {
                        cmd.Parameters.AddWithValue(pvp.Key, pvp.Value);
                    }
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return cmd;
        }

        public static MySqlCommand RunQueryToUpdateGame(string query, string  name, string description, int quantity, double price, int status, int developer, int ID)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Game_name", name);
                    cmd.Parameters.AddWithValue("@Game_description", description);
                    cmd.Parameters.AddWithValue("@Game_quantity", quantity);
                    cmd.Parameters.AddWithValue("@Game_price", price);
                    cmd.Parameters.AddWithValue("@Status_id", status);
                    cmd.Parameters.AddWithValue("@Developer_id", developer);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return cmd;
        }
    }
}
