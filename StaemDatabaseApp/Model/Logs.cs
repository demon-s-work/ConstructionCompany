using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Logs
    {

        public Logs(string id, string employeeID, string action, DateTime actionDate)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);

            int employeeID_ = 0;
            Int32.TryParse(employeeID, out employeeID_);

            Id = id_;
            EmployeeID = employeeID
            Action = action;
            ActionDat = actionDat;
        }

        private int id;
        private int employeeID;
        private string action;
        private DateTime actionDate;

        public int Id { get => id; set => id = value; }
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string Action { get => action; set => action = value; }
        public DateTime ActionDate { get => actionDate; set => actionDate = value; }

        public override string ToString()
        {
            return action + " : " + Id.ToString();
        }

    }
}
