using MySql.Data.MySqlClient;
using StaemDatabaseApp.Helper;
using StaemDatabaseApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.DBLayer
{
    public static class ReservationsDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        public static List<Reservation> RetrieveAllReservations()
        {
            string query = "SELECT * FROM staem.reservations;";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Reservation> allReservations = new List<Reservation>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string date = dr["Reservation_date"].ToString();
                    string customerID = dr["Customer_id"].ToString();
                    string gameID = dr["Game_id"].ToString();
                    allReservations.Add(new Reservation(id, date, customerID, gameID));
                }
            }
            return allReservations;
        }

        public static Reservation RetrieveReservationByID(int reservationID)
        {
            string query = "SELECT * FROM staem.reservations WHERE ID = (@ID) limit 1;";
            cmd = DBHelper.RunQueryWithID(query, reservationID);
            Reservation reservation = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string name = dr["Reservation_date"].ToString();
                    string customerID = dr["Customer_id"].ToString();
                    string gameID = dr["Game_id"].ToString();
                    reservation = new Reservation(id, name, customerID, gameID);
                }
            }
            return reservation;
        }

        public static bool AddReservation(DateTime date, int game, int client)
        {
            string query = "INSERT INTO staem.Reservations (Reservation_date, Customer_id, Game_id)" +
                " VALUES (@Reservation_date, @Customer_id, @Game_id);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Reservation_date", date.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo));
            parameters.Add("@Customer_id", game.ToString());
            parameters.Add("@Game_id", client.ToString());
            cmd = DBHelper.RunQueryWithParamList(query, parameters);
            return cmd != null;
        }
    }
}
