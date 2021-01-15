using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Supplier
    {
        public Supplier(int id, string name, string address, string contact)
        {
            //this.id = id;
            //this.name = name;
            //this.address = address;
            //this.contact = contact;
            Id = id;
            Name = name;
            Address = address;
            Contact = contact;
        }

        public Supplier(string id, string name, string address, string contact)
        {
            //this.id = id;
            //this.name = name;
            //this.address = address;
            //this.contact = contact;
            Id = Int32.Parse(id);
            Name = name;
            Address = address;
            Contact = contact;
        }

        private int id;
        private string name;
        private string address;
        private string contact;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Contact { get => contact; set => contact = value; }
    }
}
