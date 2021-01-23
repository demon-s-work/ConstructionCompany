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
    public static class GamesDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        public static List<Game> RetrieveAllGames()
        {
            string query = "SELECT * FROM staem.games;";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Game> allGames = new List<Game>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string name = dr["Game_name"].ToString();
                    string description = dr["Game_description"].ToString();
                    string quantity = dr["Game_quantity"].ToString();
                    string price = dr["Game_price"].ToString();
                    string statusID = dr["Status_id"].ToString();
                    string developerID = dr["Developer_id"].ToString();
                    allGames.Add(new Game(id, name, description, quantity, price, statusID, developerID));
                }
            }
            return allGames;
        }

        public static Game RetrieveGameByID(int gameID)
        {
            string query = "SELECT * FROM staem.games WHERE ID = (@ID) limit 1;";
            cmd = DBHelper.RunQueryWithID(query, gameID);
            Game game = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string name = dr["Game_name"].ToString();
                    string description = dr["Game_description"].ToString();
                    string quantity = dr["Game_quantity"].ToString();
                    string price = dr["Game_price"].ToString();
                    string statusID = dr["Status_id"].ToString();
                    string developerID = dr["Developer_id"].ToString();
                    game = new Game(id, name, description, quantity, price, statusID, developerID);
                }
            }
            return game;
        }

        public static bool AddGame(String name, String description, string quantity, string price, string statusID, string developerID)
        {
            string query = "INSERT INTO staem.Games (`Game_name`, `Game_description`, `Game_quantity`, `Game_price`, `Status_id`, `Developer_id`)" +
                "VALUES ('" + name + "', '" + description + "', " + quantity + ", " + price + ", " + statusID + ", " + developerID + ");";
            cmd = DBHelper.RunQueryNoParameters(query);
            return cmd != null;
        }

        public static bool RemoveGame(int id)
        {
            string query = "DELETE FROM staem.Games WHERE ID = (@ID)";
            cmd = DBHelper.RunQueryWithID(query, id);
            return cmd != null;
        }

    }
}
