using StaemDatabaseApp.DBLayer;
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
using Object=StaemDatabaseApp.Model.Object;

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

		private void filterButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ShowClientsButton_OnClick(object sender, RoutedEventArgs e)
		{
			clientsDataGrid.ItemsSource = ClientsDA.RetrieveAllCustomers();
		}

		private void AddClientButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window addCustomerWindow = new AddClientWindow();
			addCustomerWindow.Owner = this;
			addCustomerWindow.ShowDialog();
			clientsDataGrid.Items.Refresh();
		}

		private void RemoveClientButton_OnClick(object sender, RoutedEventArgs e)
		{
			Client client = (Client)clientsDataGrid.SelectedItem;

			if (client == null)
			{
				MessageBox.Show("Select client first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			// Creating client info
			StringBuilder sb = new StringBuilder();
			sb.Append("This action will delete following client from database!\n");
			sb.Append("ID: " + client.Id + "\n");
			sb.Append("Name: " + client.FullName + "\n");
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
					ClientsDA.RemoveCustomer(client.Id);
				}
				else
				{
					MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void ModifyClientButton_OnClick(object sender, RoutedEventArgs e)
		{
			Client client = (Client)clientsDataGrid.SelectedItem;

			if (client == null)
			{
				MessageBox.Show("Select game first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			Window editGameWindow = new EditClientWindow(client);
			editGameWindow.Owner = this;
			editGameWindow.ShowDialog();
			clientsDataGrid.Items.Refresh();
		}

		private void FilterClientButton_OnClick(object sender, RoutedEventArgs e)
		{
		}

		private void ShowEmployeesButton_OnClick(object sender, RoutedEventArgs e)
		{
			employeeDataGrid.ItemsSource = EmployeesDA.RetrieveAllEmployees();
		}

		private void ShowLogsButton_OnClick(object sender, RoutedEventArgs e)
		{
			logsDataGrip.ItemsSource = LogsDA.RetrieveAllLogs();
		}

		private void ShowMaterialsButton_OnClick(object sender, RoutedEventArgs e)
		{
			materialsDataGrid.ItemsSource = MaterialsDA.RetrieveAllMaterials();
		}

		private void ShowObjectsButton_OnClick(object sender, RoutedEventArgs e)
		{
			objectsDataGrid.ItemsSource = ObjectsDA.RetrieveAllObjects();
		}

		private void AddEmployeeButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window addEmployeeWindow = new AddEmployeeWindow();
			addEmployeeWindow.Owner = this;
			addEmployeeWindow.ShowDialog();
			clientsDataGrid.Items.Refresh();
		}

		private void RemoveEmployeeButton_OnClick(object sender, RoutedEventArgs e)
		{
			var employee = (Employee)employeeDataGrid.SelectedItem;

			if(employee == null)
			{
				MessageBox.Show("Select employee first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			// Creating client info
			StringBuilder sb = new StringBuilder();
			sb.Append("This action will delete following client from database!\n");
			sb.Append("ID: " + employee.Id + "\n");
			sb.Append("Name: " + employee.FullName +"\n");
			sb.Append("\nThis action may not be reversable. Do you want to continue?");

			// Ask if correct client is selected
			MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.Yes)
			{
				bool deleted = EmployeesDA.RemoveEmployee(employee.Id);
				if (deleted)
				{
					MessageBox.Show("Client was removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
					//customersDataGrid.Items.Remove(customersDataGrid.SelectedItem);
					ClientsDA.RemoveCustomer(employee.Id);
				}
				else
				{
					MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void ModifyEmployeeButton_OnClick(object sender, RoutedEventArgs e)
		{
			var employee = (Employee)employeeDataGrid.SelectedItem;

			if (employee == null)
			{
				MessageBox.Show("Select employee first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			Window editGameWindow = new EditEmployeeWindow(employee);
			editGameWindow.Owner = this;
			editGameWindow.ShowDialog();
			clientsDataGrid.Items.Refresh();
		}

		private void AddLogButton_OnClick(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void RemoveLogButton_OnClick(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void ModifyLogButton_OnClick(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void AddMaterialButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window addCustomerWindow = new AddMaterialsWindow();
			addCustomerWindow.Owner = this;
			addCustomerWindow.ShowDialog();
			clientsDataGrid.Items.Refresh();
		}

		private void RemoveMaterialButton_OnClick(object sender, RoutedEventArgs e)
		{
			var material = (Material)materialsDataGrid.SelectedItem;

			if(material == null)
			{
				MessageBox.Show("Select client first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			// Creating client info
			StringBuilder sb = new StringBuilder();
			sb.Append("This action will delete following client from database!\n");
			sb.Append("ID: " + material.Id + "\n");
			sb.Append("Name: " + material.Title +"\n");
			sb.Append("\nThis action may not be reversable. Do you want to continue?");

			// Ask if correct client is selected
			MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.Yes)
			{
				bool deleted = ClientsDA.RemoveCustomer(material.Id);
				if (deleted)
				{
					MessageBox.Show("Client was removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
					//customersDataGrid.Items.Remove(customersDataGrid.SelectedItem);
					MaterialsDA.RemoveMaterial(material.Id);
				}
				else
				{
					MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void ModifyMaterialButton_OnClick(object sender, RoutedEventArgs e)
		{
			var material = (Material)materialsDataGrid.SelectedItem;

			if (material == null)
			{
				MessageBox.Show("Select game first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			Window editGameWindow = new EditMaterialsWindow(material);
			editGameWindow.Owner = this;
			editGameWindow.ShowDialog();
			clientsDataGrid.Items.Refresh();
		}

		private void AddObjectButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window window = new AddObjectWindow();
			window.Owner = this;
			window.ShowDialog();
			objectsDataGrid.Items.Refresh();
		}

		private void RemoveObjectButton_OnClick(object sender, RoutedEventArgs e)
		{
			Object @object = (Object)objectsDataGrid.SelectedItem;

			if (@object == null)
			{
				MessageBox.Show("Select client first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			// Creating client info
			StringBuilder sb = new StringBuilder();
			sb.Append("This action will delete following client from database!\n");
			sb.Append("ID: " + @object.Id + "\n");
			sb.Append("Address: " + @object.Address + "\n");
			sb.Append("\nThis action may not be reversable. Do you want to continue?");

			// Ask if correct client is selected
			MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.Yes)
			{
				bool deleted = ClientsDA.RemoveCustomer(@object.Id);
				if (deleted)
				{
					MessageBox.Show("Client was removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
					//customersDataGrid.Items.Remove(customersDataGrid.SelectedItem);
					ObjectsDA.RemoveObject(@object.Id);
				}
				else
				{
					MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void ModifyObjectButton_OnClick(object sender, RoutedEventArgs e)
		{
			Object @object = (Object)objectsDataGrid.SelectedItem;

			if (@object == null)
			{
				MessageBox.Show("Select game first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			Window editGameWindow = new EditObjectWindow(@object);
			editGameWindow.Owner = this;
			editGameWindow.ShowDialog();
			clientsDataGrid.Items.Refresh();

		}

		private void ShowPositionsButton_OnClick(object sender, RoutedEventArgs e)
		{
			positionsDataGrid.ItemsSource = PositionsDA.RetrieveAllPositions();
		}

		private void AddPositionButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window addPositionWindow = new AddPositionWindow();
			addPositionWindow.Owner = this;
			addPositionWindow.ShowDialog();
			clientsDataGrid.Items.Refresh();
		}

		private void RemovePositionButton_OnClick(object sender, RoutedEventArgs e)
		{
			Position position = (Position)positionsDataGrid.SelectedItem;

			if (position == null)
			{
				MessageBox.Show("Select client first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			// Creating client info
			StringBuilder sb = new StringBuilder();
			sb.Append("This action will delete following client from database!\n");
			sb.Append("ID: " + position.Id + "\n");
			sb.Append("Name: " + position.Title + "\n");
			sb.Append("\nThis action may not be reversable. Do you want to continue?");

			// Ask if correct client is selected
			MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.Yes)
			{
				bool deleted = PositionsDA.RemovePosition(position.Id);
				if (deleted)
				{
					MessageBox.Show("Client was removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
					//customersDataGrid.Items.Remove(customersDataGrid.SelectedItem);
					ClientsDA.RemoveCustomer(position.Id);
				}
				else
				{
					MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void ModifyPositionButton_OnClick(object sender, RoutedEventArgs e)
		{
			Position position = (Position)positionsDataGrid.SelectedItem;

			if (position == null)
			{
				MessageBox.Show("Select game first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			Window editGameWindow = new EditPositionWindow(position);
			editGameWindow.Owner = this;
			editGameWindow.ShowDialog();
			clientsDataGrid.Items.Refresh();
		}

		private void ShowOrdersButton_OnClick(object sender, RoutedEventArgs e)
		{
			ordersDataGrid.ItemsSource = OrdersDA.RetrieveAllOrders();
		}

		private void AddOrderButton_OnClick(object sender, RoutedEventArgs e)
		{
		}

		private void RemoveOrderButton_OnClick(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void ModifyOrderButton_OnClick(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}