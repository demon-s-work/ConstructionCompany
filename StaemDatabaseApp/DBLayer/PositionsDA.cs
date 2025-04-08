using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using StaemDatabaseApp.Helper;
using StaemDatabaseApp.Model;

namespace StaemDatabaseApp.DBLayer
{
	public class PositionsDA
	{
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Position> RetrieveAllPositions()
        {
            string query = "SELECT * FROM ConstructionCompany.Positions;";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Position> allPositions = new List<Position>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["PositionID"].ToString();
                    string title = dr["Title"].ToString();
                    decimal.TryParse(dr["Salary"].ToString(), out decimal salary);
                    int.TryParse(dr["AccessLevel"].ToString(), out int accessLevel);
                    allPositions.Add(new Position(id, title, salary, accessLevel));
                }
            }
            return allPositions;
        }

        public static Position RetrievePositionByID(int positionId)
        {
            string query = "SELECT * FROM ConstructionCompany.Positions WHERE PositionId = (@ID) limit 1;";
            cmd = DBHelper.RunQueryWithID(query, positionId);
            Position position = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["PositionID"].ToString();
                    string title = dr["Title"].ToString();
                    decimal.TryParse(dr["Salary"].ToString(), out decimal salary);
                    int.TryParse(dr["AccessLevel"].ToString(), out int accessLevel);
                    position = new Position(id, title, salary, accessLevel);
                }
            }
            return position;
        }
        
        public static bool EditPosition(string title, decimal salary, int accessLevel, int id)
        {
            string query = "UPDATE ConstructionCompany.Positions SET Title=@Title,Salary=@Salary,AccessLevel=@AccessLevel WHERE PositionID=@ID;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Title", title);
            parameters.Add("@Salary", salary.ToString().Replace(',', '.'));
            parameters.Add("@AccessLevel", accessLevel.ToString());
            parameters.Add("@ID", id.ToString());
            cmd = DBHelper.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool AddPosition(string title, decimal salary, int accessLevel)
        {
            string query = "INSERT INTO `ConstructionCompany`.`Positions` (`Title`, `Salary`, `AccessLevel`)" +
                "VALUES ('" + title + "', '" + salary.ToString().Replace(',','.') + "', " + accessLevel + ");";
            cmd = DBHelper.RunQueryNoParameters(query);
            return cmd != null;
        }

        public static bool RemovePosition(int id)
        {
            string query = "DELETE FROM ConstructionCompany.Positions WHERE PositionID = (@ID)";
            cmd = DBHelper.RunQueryWithID(query, id);
            return cmd != null;
        }
	}
}