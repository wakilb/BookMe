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
    /// Interaction logic for ServicePersonal.xaml
    /// </summary>
    public partial class ServicePersonal : Window
    {
        
        public ServicePersonal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void AddServiceBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListServiceBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
