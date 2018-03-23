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
using System.Text.RegularExpressions;


namespace BookMe.UserControls.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageMenuView.xaml
    /// </summary>
    /// 

    public partial class ManageMenuView : UserControl
    {
        //What Kind of User we are dealling with 
        public string userType;

        //Database instnace
        Classes.DataBase Mydatabase = new Classes.DataBase();

        UserControls.AdminViews.ListView MyListView;
        UserControls.AdminViews.TxBView MyTxBView;
        public ManageMenuView()
        {
            InitializeComponent();
            ConfirmeBtn.Visibility = Visibility.Hidden;
            CancelBtn.Visibility = Visibility.Hidden;
            
        }

        private void AddNewBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmeBtn.Visibility = Visibility.Visible;
            CancelBtn.Visibility = Visibility.Visible;
            DeleteBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = false;
            ConfirmeBtn.Content = "Add";
            if (MyTxBView != null)
            {
                MyTxBView.Visibility = Visibility.Visible;
            }
            if (MyListView != null)
            {
                MyListView.Visibility = Visibility.Hidden;
            }
            if (MyTxBView == null)
            {
                MyTxBView = new TxBView { };
                Grid.SetColumn(MyTxBView, 1);
                MyGrid.Children.Add(MyTxBView);
            }
        }

        public void ClearValues()
        {
            MyTxBView.FirstNameTxb.Clear();
            MyTxBView.LastNameTxb.Clear();
            MyTxBView.EmailTxb.Clear();
            MyTxBView.PasswordPbx.Clear();
            MyTxBView.RePasswordPbx.Clear();
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmeBtn.Visibility = Visibility.Hidden;
            CancelBtn.Visibility = Visibility.Hidden;
            DeleteBtn.IsEnabled = true;
            UpdateBtn.IsEnabled = true;
            AddNewBtn.IsEnabled = true;
            ConfirmeBtn.Content = "";
            if (MyTxBView != null)
            {
                MyTxBView.Visibility = Visibility.Hidden;
                ClearValues();
                MyTxBView.errormessage.Text = "";
            }
            if (MyListView != null)
            {
                MyListView.Visibility = Visibility.Hidden;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmeBtn.Visibility = Visibility.Visible;
            CancelBtn.Visibility = Visibility.Visible;
            UpdateBtn.IsEnabled = false;
            AddNewBtn.IsEnabled = false;
            ConfirmeBtn.Content = "Delete";
            if (MyTxBView != null)
            {
                MyTxBView.Visibility = Visibility.Hidden;
            }
            if (MyListView != null)
            {
                MyListView.Visibility = Visibility.Visible;
            }
            if (MyListView == null)
            {
                MyListView = new ListView { };
                Grid.SetColumn(MyListView, 1);
                MyGrid.Children.Add(MyListView);

            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmeBtn.Visibility = Visibility.Visible;
            CancelBtn.Visibility = Visibility.Visible;
            DeleteBtn.IsEnabled = false;
            AddNewBtn.IsEnabled = false;
            ConfirmeBtn.Content = "Update";
            if (MyTxBView != null)
            {
                MyTxBView.Visibility = Visibility.Hidden;
            }
            if (MyListView != null)
            {
                MyListView.Visibility = Visibility.Visible;
            }
            if (MyListView == null)
            {
                MyListView = new ListView { };
                Grid.SetColumn(MyListView, 1);
                MyGrid.Children.Add(MyListView);
            }
        }

        private void ConfirmeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MyTxBView != null)
            {
                if (MyTxBView.EmailTxb.Text.Length == 0)
                {
                    MyTxBView.errormessage.Text = "Enter an email.";
                    MyTxBView.EmailTxb.Focus();
                }
                else if (!Regex.IsMatch(MyTxBView.EmailTxb.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    MyTxBView.errormessage.Text = "Enter a valid email.";
                    MyTxBView.EmailTxb.Select(0, MyTxBView.EmailTxb.Text.Length);
                    MyTxBView.EmailTxb.Focus();
                }
                else
                {

                    string f_name = MyTxBView.FirstNameTxb.Text;
                    string l_name = MyTxBView.LastNameTxb.Text;
                    string email = MyTxBView.EmailTxb.Text;
                    string password = MyTxBView.PasswordPbx.Password;
                    if (MyTxBView.PasswordPbx.Password.Length == 0)
                    {
                        MyTxBView.errormessage.Text = "Enter password.";
                        MyTxBView.EmailTxb.Focus();
                    }
                    else if (MyTxBView.RePasswordPbx.Password.Length == 0)
                    {
                        MyTxBView.errormessage.Text = "Enter Confirm password.";
                        MyTxBView.RePasswordPbx.Focus();
                    }
                    else if (MyTxBView.PasswordPbx.Password != MyTxBView.RePasswordPbx.Password)
                    {
                        MyTxBView.errormessage.Text = "re-password must be the same as password.";
                        MyTxBView.RePasswordPbx.Focus();
                    }
                    else
                    {
                        MyTxBView.errormessage.Text = "";
                        //trail from here
                        if (userType == "client")
                        {
                            Classes.Client MyClient = new Classes.Client(f_name, l_name, email, password);
                            Mydatabase.addToDB(MyClient, userType);
                        }
                        else
                        {
                            Classes.ServicePersonal MyServicePersonal = new Classes.ServicePersonal(f_name, l_name, email, password);
                            Mydatabase.addToDB(MyServicePersonal, userType);
                        }
                        MyTxBView.errormessage.Text = "You have Registered successfully.";
                        ClearValues();

                    }

                }
            }
        }
    }
}
