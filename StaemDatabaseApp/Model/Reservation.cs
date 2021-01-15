using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    class Reservation
    {
        public Reservation(int id, DateTime date, Customer customer, Game game)
        {
            this.id = id;
            this.date = date;
            this.customer = customer;
            this.game = game;
        }

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
