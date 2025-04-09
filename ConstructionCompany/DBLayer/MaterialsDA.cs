using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using StaemDatabaseApp.Helper;
using StaemDatabaseApp.Model;

namespace StaemDatabaseApp.DBLayer
{
	public class MaterialsDA
	{
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Material> RetrieveAllMaterials()
        {
            var query = "SELECT * FROM ConstructionCompany.Materials;";
            cmd = DBHelper.RunQueryNoParameters(query);
            var allEmployees = new List<Material>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    var id = dr["MaterialID"].ToString();
                    var title = dr["Title"].ToString();
                    var unit = dr["Unit"].ToString();
                    var price = decimal.Parse(dr["Price"].ToString());
                    var stockQuantity = decimal.Parse(dr["StockQuantity"].ToString());
                    allEmployees.Add(new Material(id, title, unit, price, stockQuantity));
                }
            }
            return allEmployees;
        }

        public static bool EditMaterial(int id, string title, string unit,decimal price, decimal stockQuantity)
        {
            string query = "UPDATE ConstructionCompany.Materials SET Title=@Title,Unit=@Unit,Price=@Price,StockQuantity=@StockQuantity WHERE MaterialID=@ID;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("@ID", id.ToString());
            parameters.Add("Title", title);
            parameters.Add("@Unit", unit);
            parameters.Add("@Price", price.ToString().Replace(',','.'));
            parameters.Add("@StockQuantity", stockQuantity.ToString());
            cmd = DBHelper.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool addMaterial(string title, string unit,decimal price, decimal stockQuantity)
        {
            string query = "INSERT INTO `ConstructionCompany`.`Materials` (`Title`, `Unit`, `Price`, `StockQuantity`)" +
                "VALUES ('" + title + "', '" + unit + "', '" + price.ToString().Replace(',','.') + "', '" + stockQuantity.ToString().Replace(',','.') + "');";
            cmd = DBHelper.RunQueryNoParameters(query);
            return cmd != null;
        }

        public static bool RemoveMaterial(int id)
        {
            string query = "DELETE FROM ConstructionCompany.Materials WHERE MaterialID = (@ID)";
            cmd = DBHelper.RunQueryWithID(query, id);
            return cmd != null;
        }
	}
}