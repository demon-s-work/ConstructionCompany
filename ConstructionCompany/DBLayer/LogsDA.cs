using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using MySql.Data.MySqlClient;
using StaemDatabaseApp.Helper;
using StaemDatabaseApp.Model;

namespace StaemDatabaseApp.DBLayer
{
	public static class LogsDA
	{
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Log> RetrieveAllLogs()
        {
            string query = "SELECT * FROM ConstructionCompany.Logs;";
            cmd = DBHelper.RunQueryNoParameters(query);
            var allLogs = new List<Log>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    var employeeId = int.Parse(dr["EmployeeID"].ToString());
                    var id = dr["LogID"].ToString();
                    string action = dr["Action"].ToString();
                    var actionDate = DateTime.Parse(dr["ActionDate"].ToString());
                    allLogs.Add(new Log(id, employeeId, action, actionDate));
                }
            }
            return allLogs;
        }

        public static bool EditLog(int id, int employeeID, string action, DateTime actionDate)
        {
            string query = "UPDATE ConstructionCompany.Logs SET EmployeeID=@EmployeeID,Action=@Action,ActionDate=@ActionDate WHERE LogID=@ID;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("@EmployeeId", employeeID.ToString());
            parameters.Add("@Action", action);
            parameters.Add("@ActionDate", actionDate.ToString(CultureInfo.InvariantCulture));
            parameters.Add("@ID", id.ToString());
            cmd = DBHelper.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool addLog(int employeeID, string action, DateTime actionDate)
        {
            string query = "INSERT INTO `ConstructionCompany`.`Logs` (`EmployeeID`, `Action`, `ActionDate`)" +
                "VALUES ('" + employeeID + "', '" + action+ "', '" + actionDate + "');";
            cmd = DBHelper.RunQueryNoParameters(query);
            return cmd != null;
        }

        public static bool RemoveLog(int id)
        {
            string query = "DELETE FROM ConstructionCompany.Logs WHERE LogID = (@ID)";
            cmd = DBHelper.RunQueryWithID(query, id);
            return cmd != null;
        }
		
	}
}