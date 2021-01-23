using StaemDatabaseApp.DBLayer;
using StaemDatabaseApp.Helper;
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
            //ordersDataGrid.ItemsSource = OrderDA.RetrieveAllOrders();
        }

        private void showReservationsButton_Click(object sender, RoutedEventArgs e)
        {
            //reservationsDataGrid.ItemsSource = ReservationsDA.RetrieveAllOrders();
        }

        private void showStatusesButton_Click(object sender, RoutedEventArgs e)
        {
            //statusesDataGrid.ItemsSource = StatusesDA.RetrieveAllStatuses();
        }

        private void showSuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            suppliersDataGrid.ItemsSource = SuppliersDA.retrieveAllSuppliers();
        }
    }
}
