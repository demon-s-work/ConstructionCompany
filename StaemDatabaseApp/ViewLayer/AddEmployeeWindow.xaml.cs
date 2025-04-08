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

namespace StaemDatabaseApp.ViewLayer
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            // Verify customer data
            if(EmployeeNameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Employee name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            // Employee data is correct
            // Inserting to database
            bool answer = EmployeeDA.addEmployee(EmployeeNameTextBox.Text, EmployeePhoneTextBox.Text, EmployeeEmailTextBox.Text, EmployeeLoginTextBox.Text, EmployeePasswordTextBox.Text
                , int.Parse(EmployeePositionIdTextBox.Text));
            if (answer)
            {
                MessageBox.Show("Employee was added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}