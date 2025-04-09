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
using StaemDatabaseApp.Model;

namespace StaemDatabaseApp.ViewLayer
{
    /// <summary>
    /// Interaction logic for EditMaterials.xaml
    /// </summary>
    public partial class EditMaterialsWindow : Window
    {
        private Material material;
        public EditMaterialsWindow (Material material)
        {
            InitializeComponent ();
            this.material = material;
            MaterialsTitleTextBox.Text = material.Title;
            MaterialsUnitTextBox.Text = material.Unit.ToString();
            MaterialsPriceTextBox.Text = material.Price.ToString();
            MaterialsStockQuantityTextBox.Text = material.StockQuantity.ToString();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            bool answer = MaterialsDA.EditMaterial(material.Id,
                MaterialsTitleTextBox.Text,
                MaterialsUnitTextBox.Text,
                decimal.Parse (MaterialsPriceTextBox.Text),
                decimal.Parse (MaterialsStockQuantityTextBox.Text));
            if (answer)
            {
                MessageBox.Show("Materials was edited successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}