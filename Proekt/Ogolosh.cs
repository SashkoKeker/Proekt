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
    class Ogolosh
    {
        public int Id;
        public string IdUser;
        public string Name;
        public string Zmist;
        public string Date;
        public bool Tip;
        public int count;
        

        private static SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect);
        static string q = "SELECT * FROM Ogol where [iduser]= @Id ORDER BY Date DESC";
        public string w = "SELECT * FROM Ogol ORDER BY Date DESC";
        public string e = "SELECT * FROM Ogol where [Tip]= 'True' ORDER BY Date DESC";
        public  string r = "SELECT * FROM Ogol where [Tip]= 'False' ORDER BY Date DESC";

        public static SqlCommand comand = new SqlCommand(q, connection);
        static public SqlDataAdapter sda = new SqlDataAdapter(comand);
        private static DataTable dt = new DataTable("Ogol");

        public Ogolosh()
        {
            
            
        }

        public Ogolosh( int i)
        {
           
        }

   
        public Ogolosh(string idUser, string name, string zmist, string dateTime, bool tip)
        {
            
            IdUser = idUser;
            Name = name;
            Zmist = zmist;
            Date = dateTime;
            Tip = tip;
            Addd();
            MessageBox.Show("Entry added");

        }

        

        public void Addd()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect))
            {
           
                string q = "set language english  INSERT into [Ogol]([iduser], [Name], [Zmist], [Date], [Tip]) VALUES ('" + IdUser + "','" + Name + "','" + Zmist + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Tip + "')";
                connection.Open();

                SqlCommand comand = new SqlCommand(q, connection);
               
                comand.ExecuteNonQuery();
                    MessageBox.Show("U r in base, Sir");
            
                connection.Close();
            }
        }
        
        public void Load()
        {

        }

        
    }
}
