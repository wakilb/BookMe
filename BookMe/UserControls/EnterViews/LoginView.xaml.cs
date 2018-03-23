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


namespace BookMe.UserControls.EnterViews
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    /// 

    
    public partial class LoginView : UserControl
    {

        //Database instnace
        Classes.DataBase Mydatabase = new Classes.DataBase();
        
        public LoginView()
        {
            InitializeComponent();
            
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTxb.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                EmailTxb.Focus();
            }
            else if (!Regex.IsMatch(EmailTxb.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                EmailTxb.Select(0, EmailTxb.Text.Length);
                EmailTxb.Focus();
            }
            else
            {
                string email = EmailTxb.Text;
                string password = PasswordPb.Password;
                ////trial from here
                Mydatabase.LoginHandle(email, password);
                string[,] DataResult = Mydatabase.LoginHandle(email, password);
                if (DataResult[1, 1] == "admin_tbl")
                {
                    Admin Myadmin = new Admin();
                    Myadmin.Show();
                    this.Content = null;
                }
                if (DataResult[1, 1] == "service_personal")
                {
                    ServicePersonal MyServicePersonal = new ServicePersonal();
                    MyServicePersonal.Show();
                    this.Content = null;
                }
                if (DataResult[1, 1] == "client")
                {
                    Client MyClient = new Client();
                    MyClient.Show();
                    this.Content = null;
                }


            }
        }
    }
}
