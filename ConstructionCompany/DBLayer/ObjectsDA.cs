using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using StaemDatabaseApp.Helper;
using StaemDatabaseApp.Model;

namespace StaemDatabaseApp.DBLayer
{
	public class ObjectsDA
	{
		
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Object> RetrieveAllObjects()
        {
            string query = "SELECT * FROM ConstructionCompany.Objects;";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Object> allObjects = new List<Object>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ObjectID"].ToString();
                    int clientId = int.Parse(dr["ClientID"].ToString());
                    string address = dr["Address"].ToString();
                    string type = dr["Type"].ToString();
                    allObjects.Add(new Object(id, clientId, type, address));
                }
            }
            return allObjects;
        }

        public static bool EditObject(int id, int clientId, string address, string type)
        {
            string query = "UPDATE ConstructionCompany.Objects SET ClientID=@ClientId,Address=@Address,Type=@Type WHERE ObjectID=@ID;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("@ClientId", clientId.ToString());
            parameters.Add("@Address", address);
            parameters.Add("@Type", type);
            parameters.Add("@ID", id.ToString());
            cmd = DBHelper.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool addObject(int clientId, string address, string type)
        {
            string query = "INSERT INTO `ConstructionCompany`.`Objects` (`ClientID`, `Address`, `Type`)" +
                "VALUES ('" + clientId + "', '" + address + "', '" + type + "');";
            cmd = DBHelper.RunQueryNoParameters(query);
            return cmd != null;
        }

        public static bool RemoveObject(int id)
        {
            string query = "DELETE FROM ConstructionCompany.Objects WHERE ObjectID = (@ID)";
            cmd = DBHelper.RunQueryWithID(query, id);
            return cmd != null;
        }
	}
}