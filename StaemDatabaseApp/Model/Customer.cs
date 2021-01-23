using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Customer
    {

        public Customer(string id, string name, string surname, string priceMultiplier, string gamesBought)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);
            float priceMultiplier_ = 0.0f;
            Single.TryParse(priceMultiplier, out priceMultiplier_);
            int gamesBought_ = 0;
            Int32.TryParse(gamesBought, out gamesBought_);

            Id = id_;
            Name = name;
            Surname = surname;
            PriceMultiplier = priceMultiplier_;
            GamesBought = gamesBought_;
        }

        public Customer(int id, string name, string surname, float priceMultiplier, int gamesBought)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PriceMultiplier = priceMultiplier;
            GamesBought = gamesBought;
        }

        private int id;
        private string name;
        private string surname;
        private float priceMultiplier;
        private int gamesBought;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public float PriceMultiplier { get => priceMultiplier; set => priceMultiplier = value; }
        public int GamesBought { get => gamesBought; set => gamesBought = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return Name + " " + Surname + " " + PriceMultiplier +  " : " + Id.ToString();
        }

    }
}
