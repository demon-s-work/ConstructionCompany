using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Employee
    {
        public Employee(string id, string fullName, int positionID, string phone, string email, string login, string password)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);

            Id = id_;
            FullName = fullName;
            PositionID = positionID;
            Phone = phone;
            Email = email;
            Login = login;
            Password = password;
        }

        private int id;
        private string fullName;
        private int positionID;
        private string phone;
        private string email;
        private string login;
        private string password;



        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public int PositionID { get => positionID; set => positionID = value; }
        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }

    public override string ToString()
        {
            return fullName + " : " + Id.ToString();
        }

    }
}
