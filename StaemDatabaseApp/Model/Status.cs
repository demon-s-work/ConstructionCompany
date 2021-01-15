using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    class Status
    {
        public Status(int id, String name, String description, float priceMultiplier)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.priceMultiplier = priceMultiplier;
        }

        private int id;
        private String name;
        private String description;
        private float priceMultiplier;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public float PriceMultiplier { get => priceMultiplier; set => priceMultiplier = value; }
    }
}
