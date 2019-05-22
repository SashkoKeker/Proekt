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
        List<Ogolosh> list = new List<Ogolosh>();


        public Ogolosh()
        {
            GetCount();
            MessageBox.Show(count.ToString());
        }



        public Ogolosh( int i)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect))
            {

                
                string q = "SELECT * FROM Ogol ORDER BY Date DESC";
                connection.Open();
                
                SqlDataAdapter sda = new SqlDataAdapter(q, connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Id = int.Parse(dt.Rows[i][0].ToString());

                IdUser = dt.Rows[i][1].ToString();
                Name = dt.Rows[i][2].ToString();
                Zmist = dt.Rows[i][3].ToString();
                Date = dt.Rows[i][4].ToString();
                Tip = Boolean.Parse(dt.Rows[i][5].ToString());
              
                count = int.Parse(dt.Rows[0][0].ToString());
               
                SqlCommand comand = new SqlCommand(q, connection);
                /*
                 int d;
                 if (int.TryParse(IdUser, out d))
                 {
                     MessageBox.Show(d.ToString());
                     comand.Parameters.AddWithValue("@idus", IdUser);
                 }
                */
                //comand.Parameters.AddWithValue("Login", Name);
                //comand.Parameters.AddWithValue("Pass", Password);

                comand.ExecuteNonQuery();
                //MessageBox.Show("U r in base, Sir");


                // SqlCommand command = new SqlCommand(q, connection);
                //command.ExecuteNonQuery();
                //MessageBox.Show("Stvoreno and Dodano v DB");
                connection.Close();
            }
        }

       

       

        public Ogolosh(string idUser, string name, string zmist, string dateTime, bool tip)
        {
            
            IdUser = idUser;
            Name = name;
            Zmist = zmist;
            Date = dateTime;
            Tip = tip;
            Addd();
            MessageBox.Show("U r in base, Sir");

        }

        public int GetCount()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect))
            {

                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From [Ogol]", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MessageBox.Show(dt.Rows[0][0].ToString());
                count = int.Parse(dt.Rows[0][0].ToString());
                connection.Close();
            }
            return count;
        }

        public void Addd()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect))
            {

                
                string q = "set language english  INSERT into [Ogol]([iduser], [Name], [Zmist], [Date], [Tip]) VALUES ('" + IdUser + "','" + Name + "','" + Zmist + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Tip + "')";
                connection.Open();

                SqlCommand comand = new SqlCommand(q, connection);
               /*
                int d;
                if (int.TryParse(IdUser, out d))
                {
                    MessageBox.Show(d.ToString());
                    comand.Parameters.AddWithValue("@idus", IdUser);
                }
               */
                //comand.Parameters.AddWithValue("Login", Name);
                //comand.Parameters.AddWithValue("Pass", Password);

                comand.ExecuteNonQuery();
                    MessageBox.Show("U r in base, Sir");
                
               
                // SqlCommand command = new SqlCommand(q, connection);
                //command.ExecuteNonQuery();
                //MessageBox.Show("Stvoreno and Dodano v DB");
                connection.Close();
            }
        }
        
        /*  public List<Ogolosh> getoll()
          {
              using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect))
              {
                  connection.Open();
                  SqlCommand comand = new SqlCommand("Select * From [Ogol]", connection);
                  try
                  {
                      reader = comand.ExecuteReader();
                      while (reader.Read())
                      {
                          Ogolosh og = new Ogolosh()
                          {
                              id = Convert.ToInt32(reader[0].ToString()),
                              idUser = Convert.ToInt32(reader[1].ToString()),
                              Name = reader[2].ToString(),
                              Zmist = reader[3].ToString(),
                              date = Convert.ToDateTime(reader[4].ToString()),
                              tip = Convert.ToBoolean(reader[5].ToString()),
                          };
                          list.Add(og);
                      }

                   }
                  catch (Exception ex)
                  {
                      reader.Close();
                      throw ex;
                  }
                  connection.Close();
              }
              return list;   // Получаем таблицу пользователей
          }*/

        
    }
}
