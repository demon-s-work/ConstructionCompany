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
    public partial class AddReservationWindow : Window
    {
        public AddReservationWindow()
        {
            InitializeComponent();

            //  Setting up status and developer comboBox
            gameComboBox.ItemsSource = GamesDA.RetrieveAllGames();
            gameComboBox.SelectedIndex = 0;

            customerComboBox.ItemsSource = CustomersDA.RetrieveAllCustomers();
            customerComboBox.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve date
            var date = (DateTime)datePicker.SelectedDate;

            // Check if date is correct
            if(DateTime.Compare(date, DateTime.Now) <= 0)
            {
                MessageBox.Show("Time travel is illegal in this shop", "Eggor", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            //Retrieve customer and game
            Game game = (Game)gameComboBox.SelectedItem;
            Customer customer = (Customer)customerComboBox.SelectedItem;


            bool answer = ReservationsDA.AddReservation(date, game.Id, customer.Id);
            if (answer)
            {
                MessageBox.Show("Reservation was added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
