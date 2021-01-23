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
    public partial class AddCustomerWindow : Window
    {
        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            // Verify customer data
            if(customerNameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Customer name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (customerSurnameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Customer surname cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Customer data is correct
            // Inserting to database
            bool answer = CustomersDA.addCustomer(customerNameTextBox.Text, customerSurnameTextBox.Text, customerPriceMultiplierTextBox.Text, CustomerGamesBoughtTextBox.Text);
            if (answer)
            {
                MessageBox.Show("Customer was added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
