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
            clientID = clientID_;


            int objectID_;
            Int32.TryParse(objectID, out objectID_);
            objectID = objectID_;

            
            int managerID_;
            Int32.TryParse(managerID, out managerID_);
            managerID = managerID_
        }

        private int id;
        private int clientID;
        private int objectID;
        private int managerID;
        private DateTime startDate;
        private DateTime endDate;
        private string status;

        public int Id { get => id; set => id = value; }
        public int ClientID { get => clientID; set => clientID = value; }
        public int ObjectID { get => objectID; set => objectID = value; }
        public int ManagerID { get => managerID; set => managerID = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public string Status { get => status; set => status = value; }

    }
}
