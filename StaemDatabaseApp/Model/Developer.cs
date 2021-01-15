using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    class Developer
    {
        public Developer(int id, String name, String contact)
        {
            this.id = id;
            this.name = name;
            this.contact = contact;
        }

        private int id;
        private String name;
        private String contact;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Contact { get => contact; set => contact = value; }
    }
}
