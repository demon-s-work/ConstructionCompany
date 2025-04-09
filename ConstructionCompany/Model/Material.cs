using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Material
    {

        public Material(string id, string title, string unit, decimal price, decimal stockQuantity)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);

            Id = id_;
            Title = title;
            Unit = unit;
            Price = price;
            StockQuantity = stockQuantity;
        }

        private int id;
        private string title;
        private string unit;
        private decimal price;
        private decimal stockQuantity;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Unit { get => unit; set => unit = value; }
        public decimal Price { get => price; set => price = value; }
        public decimal StockQuantity { get => stockQuantity; set => stockQuantity = value; }


        public override string ToString()
        {
            return title + " : " + Id.ToString();
        }

    }
}
