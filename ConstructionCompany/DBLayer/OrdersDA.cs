using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using StaemDatabaseApp.Helper;
using StaemDatabaseApp.Model;

namespace StaemDatabaseApp.DBLayer
{
	public class OrdersDA
	{
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Order> RetrieveAllOrders()
        {
            string query = "SELECT * FROM ConstructionCompany.Orders;";
            cmd = DBHelper.RunQueryNoParameters(query);
            var allOrders = new List<Order>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["OrderID"].ToString();
                    var clientId = dr["ClientID"].ToString();
                    var objectId = dr["ObjectID"].ToString();
                    var managerId = dr["ManagerID"].ToString();
                    var startDate = DateTime.Parse(dr["StartDate"].ToString());
                    var endDate = DateTime.Parse(dr["EndDate"].ToString());
                    var status = dr["Status"].ToString();
                    allOrders.Add(new Order(id, clientId, objectId, managerId, startDate, endDate, status));
                }
            }
            return allOrders;
        }

        public static bool EditOrder(int id, int clientId, int objectId, int managerId, DateTime startDate, DateTime endDate, string status)
        {
            string query = "UPDATE ConstructionCompany.Orders SET ClientId=@ClientID,ObjectID=@ObjectID,ManagerID=@ManagerID,StartDate=@StartDate,EndDate=@EndDate,Status=@Status WHERE OrderID=@ID;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("@ID", id.ToString());
            parameters.Add("@ClientID", clientId.ToString());
            parameters.Add("@ObjectID", objectId.ToString());
            parameters.Add("@ManagerID", managerId.ToString());
            parameters.Add("@StartDate", startDate.ToString());
            parameters.Add("@EndDate", endDate.ToString());
            parameters.Add("@Status", status);
            cmd = DBHelper.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool AddOrder(int clientId, int objectId, int managerId, DateTime startDate, DateTime endDate, string status)
        {
            string query = "INSERT INTO `ConstructionCompany`.`Orders` (`ClientID`, `ObjectID`, `ManagerID`, `StartDate`, `EndDate`, `Status`)" +
                "VALUES ('" + clientId + "', '" + objectId + "', '" + managerId + "', '" + startDate.ToString() + "','" + endDate + "', '" + status + "');";
            cmd = DBHelper.RunQueryNoParameters(query);
            return cmd != null;
        }

        public static bool RemoveOrder(int id)
        {
            string query = "DELETE FROM ConstructionCompany.Orders WHERE OrderID = (@ID)";
            cmd = DBHelper.RunQueryWithID(query, id);
            return cmd != null;
        }
	}
}