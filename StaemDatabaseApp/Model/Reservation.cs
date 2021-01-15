using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    class Reservation
    {
        private int id;
        private DateTime date;
        private Customer customer;
        private Game game;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        internal Customer Customer { get => customer; set => customer = value; }
        internal Game Game { get => game; set => game = value; }
    }
}
