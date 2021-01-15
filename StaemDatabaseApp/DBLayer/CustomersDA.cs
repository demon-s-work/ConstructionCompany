using MySql.Data.MySqlClient;
using StaemDatabaseApp.Helper;
using StaemDatabaseApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.DBLayer
{
    public static class CustomersDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Customer> RetrieveAllCustomers()
        {
            string query = "SELECT * FROM staem.customers;";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Customer> allCustomers = new List<Customer>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string name = dr["Customer_name"].ToString();
                    string surname = dr["Customer_surname"].ToString();
                    string priceMultiplier = dr["Customer_price_multiplier"].ToString();
                    string gamesBought = dr["Customer_games_bought"].ToString();
                    allCustomers.Add(new Customer(id, name, surname, priceMultiplier, gamesBought));
                }
            }
            return allCustomers;
        }

        public static Customer retrieveCustomerByID(int customerID)
        {
            string query = "SELECT * FROM staem.customers WHERE ID = (@ID) limit 1;";
            cmd = DBHelper.RunQuery(query, customerID);
            Customer customer = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string name = dr["Customer_name"].ToString();
                    string surname = dr["Customer_surname"].ToString();
                    string priceMultiplier = dr["Customer_price_multiplier"].ToString();
                    string gamesBought = dr["Customer_games_bought"].ToString();
                    customer = new Customer(id, name, surname, priceMultiplier, gamesBought);
                }
            }
            return customer;
        }

    }
}
