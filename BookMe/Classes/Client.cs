using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMe.Classes
{
    class Client
    {
        //Atributes 
        private static int ID;
        private string FirstName;
        private string LastName;
        private string Email;
        private string Password;

        //Constructors 
        public Client()
        {

        }
        public Client(string FirsName, string LastName, string Email, string Password)
        {
            this.FirstName = FirsName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
            ID++;
        }

        //accessors
        public int Id
        {
            get { return ID; }
            set { ID = value; }
        }
        public string Firstname
        {
            get { return FirstName; }
            set { FirstName = value; }
        }
        public string Lastname
        {
            get { return LastName; }
            set { LastName = value; }
        }
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

    }
}
