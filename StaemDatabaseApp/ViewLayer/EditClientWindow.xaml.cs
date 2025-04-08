using StaemDatabaseApp.DBLayer;
using StaemDatabaseApp.Model;
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
    /// Interaction logic for AddGameWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        private Client client;
        public EditClientWindow(Client client)
        {
            InitializeComponent();

            this.client = client;

            // Setting up client parameters
            clientNameTextBox.Text = client.FullName;
            clientPhoneTextBox.Text = client.Phone;
            clientEmailTextBox.Text = client.Email;
            clientAddressTextBox.Text = client.Address;
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            //Retrieve status and developer ID

            bool answer = ClientsDA.EditClient(clientNameTextBox.Text, clientPhoneTextBox.Text, clientEmailTextBox.Text, clientAddressTextBox.Text, client.Id);
            if (answer)
            {
                MessageBox.Show("Client was edited successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
