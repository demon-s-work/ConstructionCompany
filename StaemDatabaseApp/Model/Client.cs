using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Client
    {

        public Client(string id, string fullName, string phone, string email, string address)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);

            Id = id_;
            FullName = fullName;
            Phone = phone;
            Email = email;
            Address = address;
        }

        private int id;
        private string address;
        private string fullName;
        private string phone;
        private string email;

        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public int Id { get => id; set => id = value; }
        public string Address { get => address; set => address = value; }

        public override string ToString()
        {
            return fullName + " : " + Id.ToString();
        }

    }
}
