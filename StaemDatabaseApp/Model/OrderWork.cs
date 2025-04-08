using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class OrderWork
    {

        public OrderWork(string id, string orderID, string workTypeID, int quantity)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);

            int orderID_ = 0;
            Int32.TryParse(orderID, out orderID_);

            int workTypeID_ = 0;
            Int32.TryParse(workTypeID, out workTypeID_);

            Id = id_;
            WorkTypeID = workTypeID_
            OrderID = orderID_;
            Quantity = quantity;
        }

        private int id;
        private int orderID;
        private int workTypeID;
        private string quantity;

        public int Id { get => id; set => id = value; }
        public int OrderID { get => orderID; set => orderID = value; }
        public int WorkTypeID { get => workTypeID; set => workTypeID = value; }
        public string Quantity { get => quantity; set => quantity = value; }

        public override string ToString()
        {
            return orderID + " : " + Id.ToString();
        }

    }
}
