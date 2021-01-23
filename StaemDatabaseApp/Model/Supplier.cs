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
            Id = id;
            Name = name;
            Address = address;
            Contact = contact;
        }

        public Supplier(string id, string name, string address, string contact)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);
            Id = id_;
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

        public override string ToString()
        {
            return Name + " : " + Id.ToString();
        }
    }
}
