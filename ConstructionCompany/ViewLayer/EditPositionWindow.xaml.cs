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
	/// Interaction logic for AddCustomer.xaml
	/// </summary>
	public partial class EditPositionWindow : Window
	{
		private Position position;

		public EditPositionWindow(Position position)
		{
			InitializeComponent();

			this.position = position;

			// Setting up position parameters
			positionTitleTextBox.Text = position.Title;
			positionSalaryTextBox.Text = position.Salary.ToString();
			positionAccessLevelTextBox.Text = position.AccessLevel.ToString();
		}

		private void applyButton_Click(object sender, RoutedEventArgs e)
		{
			//Retrieve status and developer ID

			bool answer = PositionsDA.EditPosition(positionTitleTextBox.Text, decimal.Parse(positionSalaryTextBox.Text), int.Parse(positionAccessLevelTextBox.Text), position.Id);
			if (answer)
			{
				MessageBox.Show("Position was edited successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
				Close();
			}
			else
			{
				MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}