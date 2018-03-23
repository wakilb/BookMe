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
using System.Data;

namespace BookMe.UserControls.AdminViews
{
    /// <summary>
    /// Interaction logic for ListView.xaml
    /// </summary>
    public partial class ListView : UserControl
    {
        //Database instnace
        Classes.DataBase Mydatabase = new Classes.DataBase();
        string[] userType = { "client", "service_personal", "admin_tbl" };

        public ListView()
        {
            InitializeComponent();
            Loaded += MyWindow_Loaded;
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
             DataTable MydataTable = Mydatabase.getAllFromDB(userType[0]);
            foreach (DataRow row in MydataTable.Rows)
            {
                

                //ListViewItem item = new ListViewItem(row[0].ToString());
                //for (int i = 1; i < data.Columns.Count; i++)
                //{
                //    item.SubItems.Add(row[i].ToString());
                //}
                //listView_Services.Items.Add(item);
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
