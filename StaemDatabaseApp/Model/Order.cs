using StaemDatabaseApp.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Order
    {

        public Order(string id, string clientID, string objectID, string managerID, DateTime startDate, DateTime endDate, string Status)
        {
            int id_;
            Int32.TryParse(id, out id_);
            Id = id_;
            int clientID_;
            Int32.TryParse(clientID, out clientID_);
            Quantity = quantity_;
            int gameID_;
            Int32.TryParse(gameID, out gameID_);
            Game = GamesDA.RetrieveGameByID(gameID_);
            int supplierID_;
            Int32.TryParse(supplierID, out supplierID_);
            Supplier = SuppliersDA.RetrieveSupplierByID(supplierID_);
            // ID
            GameID = gameID_;
            SupplierID = supplierID_;

        }

        private int id;
        private int quantity;
        private int gameID;
        private int supplierID;
        private Game game;
        private Supplier supplier;

        public int Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int GameID { get => gameID; set => gameID = value; }
        public int SupplierID { get => supplierID; set => supplierID = value; }

        internal Game Game { get => game; set => game = value; }
        internal Supplier Supplier { get => supplier; set => supplier = value; }
    }
}
