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

namespace BookMe
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        UserControls.AdminLocationsView MyAdminLocationsView;
        UserControls.AdminSettingsView MyAdminSettingsView;
        public Admin()
        {
            InitializeComponent();
        }
        private void UsersBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MyAdminLocationsView != null)
            {
                MyAdminLocationsView.Visibility = Visibility.Hidden;
            }
            if (MyAdminSettingsView != null)
            {
                MyAdminSettingsView.Visibility = Visibility.Hidden;
            }
            AdminUsersView.Visibility = Visibility.Visible;
        }

        private void LocationsBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminUsersView.Visibility = Visibility.Hidden;
            if (MyAdminSettingsView != null)
            {
                MyAdminSettingsView.Visibility = Visibility.Hidden;
            }
            if (MyAdminLocationsView == null)
            {
                MyAdminLocationsView = new UserControls.AdminLocationsView { };
                Grid.SetColumn(MyAdminLocationsView, 1);
                MyGrid.Children.Add(MyAdminLocationsView);
            }
            else
            {
                MyAdminLocationsView.Visibility = Visibility.Visible;
            }
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminUsersView.Visibility = Visibility.Hidden;
            if (MyAdminLocationsView != null)
            {
                MyAdminLocationsView.Visibility = Visibility.Hidden;
            }
            if (MyAdminSettingsView == null)
            {
                MyAdminSettingsView = new UserControls.AdminSettingsView { };
                Grid.SetColumn(MyAdminSettingsView, 1);
                MyGrid.Children.Add(MyAdminSettingsView);
            }
            else
            {
                MyAdminSettingsView.Visibility = Visibility.Visible;
            }
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
