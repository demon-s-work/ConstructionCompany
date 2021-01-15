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
                    case 0:
                        MessageBox.Show("Cannot connect to server.", "Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username or password, try again.", "Authorization", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static MySqlCommand RunQuery(string query)
        {
            try
            {

                Console.WriteLine("===connection null?");
                Console.WriteLine(connection == null);
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
    }
}
