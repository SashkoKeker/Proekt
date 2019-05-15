using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proekt
{
    class User
    {

        public string Name;
        public string Surname;
        public string Password;
        public string Email;
        Main m = new Main();

        public User(string name, string password)
        {
            Name = name;
            Password = password;
            Log();
        }
        public User(string name, string surname, string password , string email)
        {
            Name = name;
            Surname = surname;
            Password = password;
            Email = email;

            Reg();

        }

        void Reg()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect))
            {
                string q = "INSERT into [User]([Name], [Surname], [Password], [Email]) VALUES ('" + Name + "','" + Surname + "','" + Password + "','" + Email + "')";
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From [User] where [Name] = '" + Name + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "0")
                {
                    SqlCommand comand = new SqlCommand(q, connection);

                    //comand.Parameters.AddWithValue("Login", Name);
                    //comand.Parameters.AddWithValue("Pass", Password);

                    comand.ExecuteNonQuery();
                    MessageBox.Show("U r in base, Sir");
                }
                else
                    MessageBox.Show("This login zanyat, Sir. Sorry((9(");
               // SqlCommand command = new SqlCommand(q, connection);
                //command.ExecuteNonQuery();
                //MessageBox.Show("Stvoreno and Dodano v DB");
                connection.Close();
            }
           
        }

        public void Log()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect))
            {
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From [User] where [Name] = '" + Name + "' and [Password] = '" + Password + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Welcome, Sir");
                    m.Show();

                }
                else
                {
                    MessageBox.Show("Incorrect Data. Retry, Sir");
                }
            }
        }
    }
}


