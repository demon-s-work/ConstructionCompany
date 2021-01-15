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
    public static class DevelopersDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Developer> RetriveAllDevelopers()
        {
            string query = "SELECT * FROM staem.developers;";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Developer> allDevelopers = new List<Developer>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string developerName = dr["Developer_name"].ToString();
                    string developerContact = dr["Developer_contact"].ToString();
                    allDevelopers.Add(new Developer(id, developerName, developerContact));
                }
            }
            return allDevelopers;
        }
    }
}
