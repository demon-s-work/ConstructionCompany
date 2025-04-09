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
    /// Interaction logic for AddMaterialsWindow.xaml
    /// </summary>
    public partial class AddMaterialsWindow : Window
    {
        public AddMaterialsWindow()
        {
            InitializeComponent();
        }
        
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            // Verify Materials data
            if (MaterialsTitleTextBox.Text.Length == 0)
            {
                MessageBox.Show("Employee Title cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (MaterialsUnitTextBox.Text.Length == 0)
            {
                MessageBox.Show("Employee Unit cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (MaterialsPriceTextBox.Text.Length == 0)
            {
                MessageBox.Show("Employee Price cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Employee data is correct
            // Inserting to database
            bool answer = MaterialsDA.addMaterial(MaterialsTitleTextBox.Text, MaterialsUnitTextBox.Text,
                decimal.Parse (MaterialsPriceTextBox.Text),
                decimal.Parse (MaterialsStockQuantityTextBox.Text));
            if (answer)
            {
                MessageBox.Show("Employee was added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}