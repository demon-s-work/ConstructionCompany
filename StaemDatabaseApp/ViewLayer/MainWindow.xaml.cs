﻿using StaemDatabaseApp.DBLayer;
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
            customersDataGrid.ItemsSource = ClientsDA.RetrieveAllCustomers();
        }

        private void showDevelopersButton_Click(object sender, RoutedEventArgs e)
        {
            developersDataGrid.ItemsSource = DevelopersDA.RetrieveAllDevelopers();
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

            Client client = (Client)customersDataGrid.SelectedItem;

            if(client == null)
            { // Typ wiadomosci i ikonka?
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
                }
                else
                {
                    MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void addGameButton_Click(object sender, RoutedEventArgs e)
        {
            Window addGameWindow = new AddGameWindow();
            addGameWindow.Owner = this;
            addGameWindow.ShowDialog();
            gamesDataGrid.Items.Refresh();
        }

        private void removeGameButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            Game game = (Game)gamesDataGrid.SelectedItem;

            if (game == null)
            { // Typ wiadomosci i ikonka?
                MessageBox.Show("Select game first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Creating game info
            StringBuilder sb = new StringBuilder();
            sb.Append("This action will delete following customer from database!\n");
            sb.Append("ID: " + game.Id + "\n");
            sb.Append("Name: " + game.Name + "\n");
            sb.Append("Developer: " + game.Developer.Name + "\n");
            sb.Append("Description: " + game.Description + "\n");
            sb.Append("Quantity: " + game.Quantity + "\n");
            sb.Append("Price: " + game.Price + "\n");
            sb.Append("Status: " + game.Status.Name + "\n");
            sb.Append("\nThis action may not be reversable. Do you want to continue?");

            // Ask if correct game is selected
            MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                bool deleted = GamesDA.RemoveGame(game.Id);
                if (deleted)
                {
                    MessageBox.Show("Game was removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    //customersDataGrid.Items.Remove(customersDataGrid.SelectedItem);
                }
                else
                {
                    MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void modifyGameButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            Game game = (Game)gamesDataGrid.SelectedItem;

            if (game == null)
            { // Typ wiadomosci i ikonka?
                MessageBox.Show("Select game first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Window editGameWindow = new EditGameWindow(game);
            editGameWindow.Owner = this;
            editGameWindow.ShowDialog();
            gamesDataGrid.Items.Refresh();
        }

        private void sellGameButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            Game game = (Game)gamesDataGrid.SelectedItem;

            if (game == null)
            { // Typ wiadomosci i ikonka?
                MessageBox.Show("Select game first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Check quantity
            if (game.Quantity <= 0)
            {
                MessageBox.Show("There is no game in stock.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Check status
            if (String.Equals(game.Status.Name, "Unavailable", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("This game is unavailable currently.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Try to sell game
            if (GamesDA.SellGame(game.Id, game.Quantity - 1))
            {

                // Creating game info
                StringBuilder sb = new StringBuilder();
                sb.Append("Game informations:\n");
                //sb.Append("ID: " + game.Id + "\n");
                sb.Append("Name: " + game.Name + "\n");
                //sb.Append("Developer: " + game.Developer.Name + "\n");
                //sb.Append("Description: " + game.Description + "\n");
                //sb.Append("Quantity: " + game.Quantity + "\n");
                sb.Append("Price: " + game.Price + "\n");
                sb.Append("Status: " + game.Status.Name + "\n");
                sb.Append("Status price multiplier: " + game.Status.PriceMultiplier + "\n");

                MessageBox.Show(sb.ToString(), "Game sold!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addNewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Window addOrderWindow = new AddOrderWindow();
            addOrderWindow.Owner = this;
            addOrderWindow.ShowDialog();
            ordersDataGrid.Items.Refresh();
        }

        private void addReservation_Click(object sender, RoutedEventArgs e)
        {
            Window addReservationWindow = new AddReservationWindow();
            addReservationWindow.Owner = this;
            addReservationWindow.ShowDialog();
            ordersDataGrid.Items.Refresh();
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
