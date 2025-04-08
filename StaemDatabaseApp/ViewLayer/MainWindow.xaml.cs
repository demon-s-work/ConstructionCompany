using StaemDatabaseApp.DBLayer;
using StaemDatabaseApp.Helper;
using StaemDatabaseApp.Model;
using StaemDatabaseApp.ViewLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StaemDatabaseApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowClientsButton_OnClick(object sender, RoutedEventArgs e)
        {
            clientsDataGrid.ItemsSource = ClientsDA.RetrieveAllCustomers();
        }

        private void AddClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            Window addCustomerWindow = new AddClientWindow();
            addCustomerWindow.Owner = this;
            addCustomerWindow.ShowDialog();
            clientsDataGrid.Items.Refresh();
        }

        private void RemoveClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            Client client = (Client)clientsDataGrid.SelectedItem;

            if(client == null)
            {
                MessageBox.Show("Select client first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Creating client info
            StringBuilder sb = new StringBuilder();
            sb.Append("This action will delete following client from database!\n");
            sb.Append("ID: " + client.Id + "\n");
            sb.Append("Name: " + client.FullName +"\n");
            sb.Append("\nThis action may not be reversable. Do you want to continue?");

            // Ask if correct client is selected
            MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                bool deleted = ClientsDA.RemoveCustomer(client.Id);
                if (deleted)
                {
                    MessageBox.Show("Client was removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    //customersDataGrid.Items.Remove(customersDataGrid.SelectedItem);
                    ClientsDA.RemoveCustomer(client.Id);
                }
                else
                {
                    MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ModifyClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            Client client = (Client)clientsDataGrid.SelectedItem;

            if (client == null)
            {
                MessageBox.Show("Select game first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Window editGameWindow = new EditClientWindow(client);
            editGameWindow.Owner = this;
            editGameWindow.ShowDialog();
            clientsDataGrid.Items.Refresh();
        }

        private void FilterClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowEmployeesButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowLogsButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowMaterialsButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowObjectsButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddEmployeeButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RemoveEmployeeButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ModifyEmployeeButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddLogButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RemoveLogButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ModifyLogButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddMaterialButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RemoveMaterialButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ModifyMaterialButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddObjectButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RemoveObjectButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ModifyObjectButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
