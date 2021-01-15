using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    class Customer
    {
        private int id;
        private String name;
        private String surname;
        private float priceMultiplier;
        private int gamesBought;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public float PriceMultiplier { get => priceMultiplier; set => priceMultiplier = value; }
        public int GamesBought { get => gamesBought; set => gamesBought = value; }
        public int Id { get => id; set => id = value; }

    }
}
