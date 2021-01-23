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
    public partial class EditGameWindow : Window
    {
        private Game game;
        public EditGameWindow(Game game)
        {
            InitializeComponent();

            this.game = game;

            // Setting up game parameters
            nameTextBox.Text = game.Name;
            descriptionTextBox.Text = game.Description;
            quantityTextBox.Text = game.Quantity.ToString();
            priceTextBox.Text = game.Price.ToString();

            //  Setting up status and developer comboBox
            statusComboBox.ItemsSource = StatusDA.RetrieveAllStatuses();
            for(int i=0; i< statusComboBox.Items.Count; i++)
            {
                if (((Status)statusComboBox.Items.GetItemAt(i)).Id == game.Status.Id)
                {
                    statusComboBox.SelectedIndex = i;
                    break;
                }
            }

            developerComboBox.ItemsSource = DevelopersDA.RetriveAllDevelopers();
            for (int i = 0; i < developerComboBox.Items.Count; i++)
            {
                if (((Developer)developerComboBox.Items.GetItemAt(i)).Id == game.Developer.Id)
                {
                    developerComboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
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
                price = Double.Parse(priceTextBox.Text);
            }catch (Exception ex)
            {
                MessageBox.Show("Error while converting quantity and price.\nTry again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Game data is correct

            //Retrieve status and developer ID
            Status status = (Status)statusComboBox.SelectedItem;
            string statusID = status.Id.ToString();
            Developer developer = (Developer)developerComboBox.SelectedItem;
            string developerID = developer.Id.ToString();


            bool answer = GamesDA.EditGame(nameTextBox.Text, descriptionTextBox.Text, quantity, price, status.Id, developer.Id, game.Id);
            if (answer)
            {
                MessageBox.Show("Game was edited successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
