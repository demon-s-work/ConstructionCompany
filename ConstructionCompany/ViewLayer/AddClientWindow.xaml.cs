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
    /// Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            // Verify client data
            if (customerFullNameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Client name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (customerPhoneTextBox.Text.Length == 0)
            {
                MessageBox.Show("Client phone cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Client data is correct
            // Inserting to database
            bool answer = ClientsDA.addCustomer(customerFullNameTextBox.Text, customerPhoneTextBox.Text, customerEmailTextBox.Text, CustomerAddressTextBox.Text);
            if (answer)
            {
                MessageBox.Show("Client was added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
