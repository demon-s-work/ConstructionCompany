using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Positions
    {

        public Positions(string id, string Title, decimal Salary, int AccessLevel)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);

            Id = id_;
            Title = title;
            Salary = salary;
            AccessLevel = accessLevel;
        }

        private int id;
        private string title;
        private string salary;
        private string accessLevel;

        public string Title { get => title; set => title = value; }
        public string Salary { get => salary; set => salary = value; }
        public string AccessLevel { get => accessLevel; set => accessLevel = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return title + " : " + Id.ToString();
        }

    }
}
