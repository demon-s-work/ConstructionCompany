using StaemDatabaseApp.DBLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Object
    {

        public Object(string id, int clientID, string type, string address)
        {
        
            int id_ = 0;
            Int32.TryParse(id, out id_);

            Id = id_;
            ClientID = clientID;
            Type = type;
            Address = address;
        }

        private int id;
        private int clientID;
        private string address;
        private string type;

        public string Type { get => type; set => type = value; }
        public int ClientID { get => clientID; set => clientID = value; }
        public int Id { get => id; set => id = value; }
        public string Address { get => address; set => address = value; }

        public override string ToString()
    {
            return address + " : " + Id.ToString();
        }

    }
}
