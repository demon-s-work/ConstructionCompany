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
        public Reservation(int id, DateTime date, Customer customer, Game game)
        {
            Id = id;
            Date = date;
            Customer = customer;
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
            Customer customer = CustomersDA.retrieveCustomerByID(customerID_);
            Customer = customer;
            int gameID_;
            Int32.TryParse(gameID, out gameID_);
            Game game = GamesDA.RetrieveGameByID(gameID_);
            Game = game;
        }

        private int id;
        private DateTime date;
        private Customer customer;
        private Game game;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        private Customer Customer { get => customer; set => customer = value; }
        private Game Game { get => game; set => game = value; }
    }
}
