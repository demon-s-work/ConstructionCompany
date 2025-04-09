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
    public static class ClientsDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Client> RetrieveAllCustomers()
        {
            string query = "SELECT * FROM ConstructionCompany.Clients;";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Client> allClients = new List<Client>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ClientID"].ToString();
                    string fullName = dr["FullName"].ToString();
                    string phone = dr["Phone"].ToString();
                    string email = dr["Email"].ToString();
                    string address = dr["Address"].ToString();
                    allClients.Add(new Client(id, fullName, phone, email, address));
                }
            }
            return allClients;
        }

        public static Client RetrieveCustomerByID(int customerID)
        {
            string query = "SELECT * FROM ConstructionCompany.Clients WHERE ClientID = (@ID) limit 1;";
            cmd = DBHelper.RunQueryWithID(query, customerID);
            Client client = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ClientID"].ToString();
                    string fullName = dr["FullName"].ToString();
                    string phone = dr["Phone"].ToString();
                    string email = dr["Email"].ToString();
                    string address = dr["Address"].ToString();
                    client = new Client(id, fullName, phone, email, address);
                }
            }
            return client;
        }
        
        public static bool EditClient(string fullName, string phone, string email, string address, int id)
        {
            string query = "UPDATE ConstructionCompany.Clients SET FullName=@FullName,Phone=@phone,Email=@Email,Address=@Address WHERE ClientID=@ID;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@FullName", fullName);
            parameters.Add("@Phone", phone);
            parameters.Add("@Email", email);
            parameters.Add("@Address", address);
            parameters.Add("@ID", id.ToString());
            cmd = DBHelper.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool addCustomer(string fullName, string phone, string email, string address)
        {
            // INSERT INTO `staem`.`Customers` (`ID`, `Customer_name`, `Customer_surname`, `Customer_price_multiplier`, `Customer_games_bought`)
            // VALUES (1, 'Zniżka', 'Pracownik', 0.9, 0);
            string query = "INSERT INTO `ConstructionCompany`.`Clients` (`Fullname`, `Phone`, `Email`, `Address`)" +
                "VALUES ('" + fullName + "', '" + phone + "', '" + email + "', '" + address + "');";
            cmd = DBHelper.RunQueryNoParameters(query);
            return cmd != null;
        }

        public static bool RemoveCustomer(int id)
        {
            string query = "DELETE FROM ConstructionCompany.Clients WHERE ClientID = (@ID)";
            cmd = DBHelper.RunQueryWithID(query, id);
            return cmd != null;
        }
    }
}
