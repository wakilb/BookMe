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


namespace BookMe.UserControls
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    /// 
    public partial class AdminUsersView : UserControl
    {
        
        AdminViews.ManageMenuView MyManageMenu;
        public AdminUsersView()
        {
            InitializeComponent();
            MyManageMenu = new UserControls.AdminViews.ManageMenuView { Visibility = Visibility.Hidden };
            MyManageMenu.userType = "service_personal";
            MyGrid.Children.Add(MyManageMenu);
        }

        private void SpManageBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientManageBtn.Visibility = Visibility.Hidden;
            SpManageBtn.Visibility = Visibility.Hidden;
            UserTypeLbl.Content = "Service personal Managment";
            UserTypeLbl.Visibility = Visibility.Visible;
            BackBtn.Visibility = Visibility.Visible;
            MyManageMenu.Visibility = Visibility.Visible;
            MyManageMenu.userType = "service_personal";


        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientManageBtn.Visibility = Visibility.Visible;
            SpManageBtn.Visibility = Visibility.Visible;
            UserTypeLbl.Visibility = Visibility.Hidden;
            BackBtn.Visibility = Visibility.Hidden;
            MyManageMenu.Visibility = Visibility.Hidden;

        }

        private void ClientManageBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientManageBtn.Visibility = Visibility.Hidden;
            SpManageBtn.Visibility = Visibility.Hidden;
            UserTypeLbl.Content = "Client/Student Managment";
            UserTypeLbl.Visibility = Visibility.Visible;
            BackBtn.Visibility = Visibility.Visible;
            MyManageMenu.Visibility = Visibility.Visible;
            MyManageMenu.userType = "client";
        }
    }
}
