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
using Object=StaemDatabaseApp.Model.Object;

namespace StaemDatabaseApp.ViewLayer
{
    /// <summary>
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditObjectWindow : Window
    {
        private Object @object;
        public EditObjectWindow(Object @object)
        {
            InitializeComponent();
            this.@object = @object;
            ObjectClietnIDTextBox.Text = @object.ClientID.ToString();
            ObjectAddressTextBox.Text = @object.Address;
            ObjectTypeComboBox.SelectedValue = @object.Type;
            ObjectTypeComboBox.Text = @object.Type;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            bool answer = ObjectsDA.EditObject(@object.Id, int.Parse(ObjectClietnIDTextBox.Text), ObjectAddressTextBox.Text, (ObjectTypeComboBox.SelectedValue as ComboBoxItem).Content.ToString());
            if (answer)
            {
                MessageBox.Show("Object was edited successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}