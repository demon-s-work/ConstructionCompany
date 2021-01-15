using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    class Status
    {
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
