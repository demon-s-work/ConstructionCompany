using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using StaemDatabaseApp.Helper;
using StaemDatabaseApp.Model;

namespace StaemDatabaseApp.DBLayer
{
    public static class EmployeesDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Employee> RetrieveAllEmployees()
        {
            string query = "SELECT * FROM ConstructionCompany.Employees;";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Employee> allEmployees = new List<Employee>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["EmployeeID"].ToString();
                    string fullName = dr["FullName"].ToString();
                    string phone = dr["Phone"].ToString();
                    string email = dr["Email"].ToString();
                    string login = dr["Login"].ToString();
                    string password = dr["Password"].ToString();
                    int positionID = int.Parse(dr["PositionID"].ToString());
                    allEmployees.Add(new Employee(id, fullName,positionID, phone, email, login, password));
                }
            }
            return allEmployees;
        }

        public static bool EditEmployee(int id, string fullName, string phone, string email, string login, string password, int positionID)
        {
            string query = "UPDATE ConstructionCompany.Employees SET FullName=@FullName,PositionID=@PositionID,Phone=@phone,Email=@Email,Login=@Login,Password=@Password WHERE EmployeeID=@ID;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("@FullName", fullName);
            parameters.Add("@Phone", phone);
            parameters.Add("@Email", email);
            parameters.Add("@Login", login);
            parameters.Add("@Password", password);
            parameters.Add("@PositionID", positionID.ToString());
            parameters.Add("@ID", id.ToString());
            cmd = DBHelper.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool addEmployee(string fullName, string phone, string email, string login, string password, int positionID)
        {
            string query = "INSERT INTO `ConstructionCompany`.`Employees` (`Fullname`, `Phone`, `Email`, `PositionID`, `Login`, `Password`)" +
                "VALUES ('" + fullName + "', '" + phone + "', '" + email + "', '" + positionID + "','" + login + "', '" + password + "');";
            cmd = DBHelper.RunQueryNoParameters(query);
            return cmd != null;
        }

        public static bool RemoveEmployee(int id)
        {
            string query = "DELETE FROM ConstructionCompany.Employees WHERE EmployeeID = (@ID)";
            cmd = DBHelper.RunQueryWithID(query, id);
            return cmd != null;
        }
    }
}