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
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();

            //  Setting up status and developer comboBox
            gameComboBox.ItemsSource = GamesDA.RetrieveAllGames();
            gameComboBox.SelectedIndex = 0;

            supplierComboBox.ItemsSource = SuppliersDA.RetrieveAllSuppliers();
            supplierComboBox.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (quantityTextBox.Text.Length == 0)
            {
                MessageBox.Show("Quantity cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int quantity;
            try
            {
                quantity = Int32.Parse(quantityTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while converting quantity.\nTry again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(quantity <= 0)
            {
                MessageBox.Show("Error - quantity value below 0.\nTry again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            //Retrieve status and developer ID
            Game game = (Game)gameComboBox.SelectedItem;
            Supplier supplier = (Supplier)supplierComboBox.SelectedItem;


            bool answer = OrderDA.AddOrder(quantity, game.Id, supplier.Id);
            if (answer)
            {
                MessageBox.Show("Order was completed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
