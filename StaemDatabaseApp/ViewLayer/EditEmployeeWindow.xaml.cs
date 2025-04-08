using StaemDatabaseApp.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StaemDatabaseApp.Model;

namespace StaemDatabaseApp.ViewLayer
{
    /// <summary>
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        private Employee employee;
        public EditEmployeeWindow(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            EmployeeNameTextBox.Text = employee.FullName;
            EmployeePositionIdTextBox.Text = employee.PositionID.ToString();
            EmployeePhoneTextBox.Text = employee.Phone;
            EmployeeEmailTextBox.Text = employee.Email;
            EmployeeLoginTextBox.Text = employee.Login;
            EmployeePasswordTextBox.Text = employee.Password;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            bool answer = EmployeeDA.EditEmployee(employee.Id, EmployeeNameTextBox.Text,
                EmployeePhoneTextBox.Text,
                EmployeeEmailTextBox.Text,
                EmployeeLoginTextBox.Text,
                EmployeePasswordTextBox.Text,
                int.Parse(EmployeePositionIdTextBox.Text));
            if (answer)
            {
                MessageBox.Show("Employee was edited successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}