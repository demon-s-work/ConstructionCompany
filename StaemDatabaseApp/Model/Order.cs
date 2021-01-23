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
        public Order(int id, int quantity, Game game, Supplier supplier)
        {
            Id = id;
            Quantity = quantity;
            Game = game;
            Supplier = supplier;
        }

        public Order(string id, string quantity, string gameID, string supplierID)
        {
            int id_;
            Int32.TryParse(id, out id_);
            Id = id_;
            int quantity_;
            Int32.TryParse(quantity, out quantity_);
            Quantity = quantity_;
            int gameID_;
            Int32.TryParse(gameID, out gameID_);
            Game = GamesDA.RetrieveGameByID(gameID_);
            int supplierID_;
            Int32.TryParse(supplierID, out supplierID_);
            Supplier = SuppliersDA.RetrieveSupplierByID(supplierID_);
        }

        private int id;
        private int quantity;
        private Game game;
        private Supplier supplier;

        public int Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        internal Game Game { get => game; set => game = value; }
        internal Supplier Supplier { get => supplier; set => supplier = value; }
    }
}
