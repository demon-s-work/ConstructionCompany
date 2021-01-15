using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    class Customer
    {
        public Customer(int id, String name, String surname, float priceMultiplier, int gamesBought)
        {
            //this.id = id;
            //this.name = name;
            //this.surname = surname;
            //this.priceMultiplier = priceMultiplier;
            //this.gamesBought = gamesBought;
            Id = id;
            Name = name;
            Surname = surname;
            PriceMultiplier = priceMultiplier;
            GamesBought = gamesBought;
        }

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
