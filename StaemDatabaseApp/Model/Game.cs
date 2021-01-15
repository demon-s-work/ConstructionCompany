using StaemDatabaseApp.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Game
    {
        public Game(string id, string name, string description, string quantity, string price, string statusID, string developerID)
        {
            int id_;
            Int32.TryParse(id, out id_);
            Id = id_;
            Name = name;
            Description = description;
            int quantity_;
            Int32.TryParse(quantity, out quantity_);
            Quantity = quantity_;
            float price_;
            Single.TryParse(price, out price_);
            Price = price_;
            int statusID_;
            Int32.TryParse(statusID, out statusID_);
            Status = StatusDA.RetrieveStatusByID(statusID_);
            int developerID_;
            Int32.TryParse(developerID, out developerID_);
            Developer = DevelopersDA.RetrieveDeveloperByID(developerID_);
        }

        public Game(int id, string name, string description, int quantity, float price, Status status, Developer developer)
        {
            Id = id;
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
            Status = status;
            Developer = developer;
        }

        private int id;
        private string name;
        private string description;
        private int quantity;
        private float price;
        private Status status;
        private Developer developer;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float Price { get => price; set => price = value; }
        internal Status Status { get => status; set => status = value; }
        internal Developer Developer { get => developer; set => developer = value; }
    }
}
