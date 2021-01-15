using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    class Status
    {
        public Status(int id, string name, string description, float priceMultiplier)
        {
            Id = id;
            Name = name;
            Description = description;
            PriceMultiplier = priceMultiplier;
        }

        private int id;
        private string name;
        private string description;
        private float priceMultiplier;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public float PriceMultiplier { get => priceMultiplier; set => priceMultiplier = value; }
    }
}
