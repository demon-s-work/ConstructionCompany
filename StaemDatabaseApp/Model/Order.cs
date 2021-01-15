using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    class Order
    {
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
