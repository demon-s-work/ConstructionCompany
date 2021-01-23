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
    public static class StatusDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        public static List<Status> RetrieveAllStatuses()
        {
            string query = "SELECT * FROM staem.statuses;";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Status> allStatuses = new List<Status>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string name = dr["Status_name"].ToString();
                    string description = dr["Status_description"].ToString();
                    string priceMultiplier = dr["Status_price_multiplier"].ToString();
                    allStatuses.Add(new Status(id, name, description, priceMultiplier));
                }
            }
            return allStatuses;
        }

        public static Status RetrieveStatusByID(int statusID)
        {
            string query = "SELECT * FROM staem.statuses WHERE ID = (@ID) limit 1;";
            cmd = DBHelper.RunQueryWithID(query, statusID);
            Status status = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string name = dr["Status_name"].ToString();
                    string description = dr["Status_description"].ToString();
                    string priceMultiplier = dr["Status_price_multiplier"].ToString();
                    status = new Status(id, name, description, priceMultiplier);
                }
            }
            return status;
        }
    }
}
