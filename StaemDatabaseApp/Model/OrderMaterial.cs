using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class OrderMaterial
    {

        public OrderMaterial(string id, string orderID, string materialID, decimal quantity)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);

            int orderID_ = 0;
            Int32.TryParse(orderID, out orderID_);

            int materialID_ = 0;
            Int32.TryParse(materialID, out materialID_);

            Id = id_;
            OrderID = orderID_;
            MaterialID = materialID_;
            Quantity = quantity;
        }

        private int id;
        private int orderID;
        private int materialID;
        private string quantity;

        public int Id { get => id; set => id = value; }
        public int OrderID { get => orderID; set => orderID = value; }
        public int MaterialID { get => materialID; set => materialID = value; }
        public string Quantity { get => quantity; set => quantity = value; }

        public override string ToString()
        {
            return materialID + " : " + Id.ToString();
        }

    }
}
