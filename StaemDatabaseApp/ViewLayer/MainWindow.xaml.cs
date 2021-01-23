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

        private void showCustomersButton_Click(object sender, RoutedEventArgs e)
        {
            customersDataGrid.ItemsSource = CustomersDA.RetrieveAllCustomers();
        }

        private void showDevelopersButton_Click(object sender, RoutedEventArgs e)
        {
            developersDataGrid.ItemsSource = DevelopersDA.RetriveAllDevelopers();
        }

        private void showGamesButton_Click(object sender, RoutedEventArgs e)
        {
            gamesDataGrid.ItemsSource = GamesDA.RetrieveAllGames();
        }

        private void showOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            ordersDataGrid.ItemsSource = OrderDA.RetrieveAllOrders();
        }

        private void showReservationsButton_Click(object sender, RoutedEventArgs e)
        {
            reservationsDataGrid.ItemsSource = ReservationsDA.RetrieveAllReservations();
        }

        private void showStatusesButton_Click(object sender, RoutedEventArgs e)
        {
            statusesDataGrid.ItemsSource = StatusDA.RetrieveAllStatuses();
        }

        private void showSuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            suppliersDataGrid.ItemsSource = SuppliersDA.RetrieveAllSuppliers();
        }

        private void addCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            Window addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Owner = this;
            addCustomerWindow.ShowDialog();
            customersDataGrid.Items.Refresh();
        }

        private void removeCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            Customer customer = (Customer)customersDataGrid.SelectedItem;

            if(customer == null)
            { // Typ wiadomosci i ikonka?
                MessageBox.Show("Select customer first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Creating customer info
            StringBuilder sb = new StringBuilder();
            sb.Append("This action will delete following customer from database!\n");
            sb.Append("ID: " + customer.Id + "\n");
            sb.Append("Name: " + customer.Name +"\n");
            sb.Append("Surname: " + customer.Surname + "\n");
            sb.Append("Price Multiplier: " + customer.PriceMultiplier + "\n");
            sb.Append("Games bought: " + customer.GamesBought + "\n");
            sb.Append("\nThis action may not be reversable. Do you want to continue?");

            // Ask if correct customer is selected
            MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                bool deleted = CustomersDA.RemoveCustomer(customer.Id);
                if (deleted)
                {
                    MessageBox.Show("Customer was removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    //customersDataGrid.Items.Remove(customersDataGrid.SelectedItem);
                }
                else
                {
                    MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
