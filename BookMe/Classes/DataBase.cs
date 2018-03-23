using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace BookMe.Classes
{
    class DataBase
    {
        //DataBase Connection Credentials
        private string server = "localhost";
        private string database = "bookme";
        private string userid = "root";
        private string password = "";

        private MySqlConnection connectM;


        public void addToDB(object MyObject, string type)
        {
            //Check The Type of the object 
            if (type == "Client")
            {
                //assign the object type to the relevent type 
                Client MyClient = (Client)MyObject;
                //Database handling
                string connectstring;
                connectstring = $"SERVER={server};DATABASE={database};UID={userid};PASSWORD={password};";
                connectM = new MySqlConnection(connectstring);
                connectM.Open();
                string query = $" INSERT INTO " + type + " (client_id,f_name,l_name,email,password) VALUES ('" + MyClient.Id + "','" + MyClient.Firstname + "','" + MyClient.Lastname + "','" + MyClient.email + "','" + MyClient.password + "')";
                MySqlCommand cmd = new MySqlCommand(query, connectM);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                connectM.Close(); //all good & end of database process
            }


            //Check The Type of the object 
            if (type == "service_personal")
            {
                //assign the object type to the relevent type 
                ServicePersonal MyServicePersonal = (ServicePersonal)MyObject;
                //Database handling
                string connectstring;
                connectstring = $"SERVER={server};DATABASE={database};UID={userid};PASSWORD={password};";
                connectM = new MySqlConnection(connectstring);
                connectM.Open();
                string query = $" INSERT INTO " + type + " (service_personal_id,f_name,l_name,email,password) VALUES ('" + MyServicePersonal.Id + "','" + MyServicePersonal.Firstname + "','" + MyServicePersonal.Lastname + "','" + MyServicePersonal.email + "','" + MyServicePersonal.password + "')";
                MySqlCommand cmd = new MySqlCommand(query, connectM);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                connectM.Close(); //all good & end of database process
            }

        }

        public string[,] LoginHandle(string email, string passwordUser)
        {
            string[,] answer= new string[,] { { "name", ""}, { "type","" } };
            string[] Dbtable = { "client", "service_personal", "admin_tbl" };
            int i = 0;
            int result = 0;
            

            string connectstring;
            connectstring = $"SERVER={server};DATABASE={database};UID={userid};PASSWORD={password};";

            connectM = new MySqlConnection(connectstring);
            connectM.Open();


            do
            {
                string query = "Select * from " + Dbtable[i] + "  where email='" + email + "'  and password='" + passwordUser + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectM);
                adapter.SelectCommand.CommandType = CommandType.Text;
                DataTable MydataTable = new DataTable();
                adapter.Fill(MydataTable);

                if (MydataTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in MydataTable.Rows)
                    {
                        answer[0,0] = dr["f_name"].ToString();
                        answer[1, 1] = Dbtable[i];
                    }
                    result = 1;
                }
                i++;

            } while (result == 0 && i <= 2);


            connectM.Close();
            return answer;
        }


        public DataTable getAllFromDB(string type)
        {
            //Database handling
            string connectstring;
            connectstring = $"SERVER={server};DATABASE={database};UID={userid};PASSWORD={password};";
            connectM = new MySqlConnection(connectstring);
            connectM.Open();
            string query = $" SELECT * FROM " + type + "";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectM);
            adapter.SelectCommand.CommandType = CommandType.Text;
            DataTable MydataTable = new DataTable();
            adapter.Fill(MydataTable);
            connectM.Close(); //all good & end of database process
            return MydataTable;

            
        }
    }
}
