using StaemDatabaseApp.DBLayer;
using StaemDatabaseApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class AddGameWindow : Window
    {
        public AddGameWindow()
        {
            InitializeComponent();

            //  Setting up status and developer comboBox
            statusComboBox.ItemsSource = StatusDA.RetrieveAllStatuses();
            statusComboBox.SelectedIndex = 0;

            developerComboBox.ItemsSource = DevelopersDA.RetrieveAllDevelopers();
            developerComboBox.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            // Verify game data
            if (nameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Game name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (priceTextBox.Text.Length == 0)
            {
                MessageBox.Show("Game price cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int quantity;
            double price;
            try
            {
                quantity = Int32.Parse(quantityTextBox.Text);
                priceTextBox.Text = priceTextBox.Text.Replace(',', '.');
                price = Double.Parse(priceTextBox.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while converting quantity and price.\nTry again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(quantity < 0)
            {
                MessageBox.Show("Error - game quantity value below 0.\nTry again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (price <= 0)
            {
                MessageBox.Show("Error - game price below 0.\nTry again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Game data is correct

            //Retrieve status and developer ID
            Status status = (Status)statusComboBox.SelectedItem;
            Developer developer = (Developer)developerComboBox.SelectedItem;


            bool answer = GamesDA.AddGame(nameTextBox.Text, descriptionTextBox.Text, quantity, price, status.Id, developer.Id);
            if (answer)
            {
                MessageBox.Show("Game was added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
