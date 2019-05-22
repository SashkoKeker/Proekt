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
        public string Id;
        public string Login;
        public string Name;
        public string Surname;
        public string Password;
        public string Email;
        public bool Root;
        Main m = new Main();

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            Log();
            
        }
        public User(string login, string name, string surname, string password, string email, bool root)
        {
            Login = login;
            Name = name;
            Surname = surname;
            Password = password;
            Email = email;
            Root = root;
            Reg();
           

        }

        void Reg()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conects))
            {
                string q = "INSERT into [User]([Login], [Name], [Surname], [Password], [Email],[admin]) VALUES ('" + Login + "','" + Name + "','" + Surname + "','" + Password + "','" + Email + "','" + Root + "')";
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From [User] where [Name] = '" + Login + "'", connection);
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
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conects))
            {
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From [User] where [Login] = '" + Login + "' and [Password] = '" + Password + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {

                    MessageBox.Show("Welcome, Sir");
                    m.Title.Text = Login;
                    Getid();
                    m.Idd.Text = Id;
                    m.Surname.Text = Surname;
                    m.Email.Text = Email;
                    m.Show();

                    MainWindow q = new MainWindow();
                    
                    q.Hide();

                }
                else
                {
                    MessageBox.Show("Incorrect Data. Retry, Sir");
                }
            }
        }
        public void Getid()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conects))
            {
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select [Id] From [User] where [Login] = '" + Login + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MessageBox.Show(dt.Rows[0][0].ToString());
                Id =  dt.Rows[0][0].ToString();
                connection.Close();
            }
        }
        
    }
}


