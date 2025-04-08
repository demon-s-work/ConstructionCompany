using StaemDatabaseApp.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Reservation
    {
        public Reservation(int id, DateTime date, Client client, Game game)
        {
            Id = id;
            Date = date;
            Client = client;
            Game = game;
        }

        public Reservation(string id, string date, string customerID, string gameID)
        {
            int id_;
            Int32.TryParse(id, out id_);
            Id = id_;
            DateTime date_;
            DateTime.TryParse(date, out date_);
            Date = date_;
            int customerID_;
            Int32.TryParse(customerID, out customerID_);
            Client client = ClientsDA.RetrieveCustomerByID(customerID_);
            Client = client;
            this.customerID = customerID_;
            int gameID_;
            Int32.TryParse(gameID, out gameID_);
            Game game = GamesDA.RetrieveGameByID(gameID_);
            Game = game;
            this.gameID = gameID_;
        }

        private int id;
        private DateTime date;
        private int customerID;
        private int gameID;
        private Client client;
        private Game game;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        private Client Client { get => client; set => client = value; }
        private Game Game { get => game; set => game = value; }
        public int GameID { get => gameID; set => gameID = value; }
        public int CustomerID { get => customerID; set => customerID = value; }
    }
}
