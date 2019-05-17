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
        public int IdUser;
        public string Name;
        public string Zmist;
        public string Date;
        public bool Tip;

        List<Ogolosh> list = new List<Ogolosh>();


        SqlDataReader reader = null;

        public Ogolosh() { }

        public Ogolosh(int idUser, string name, string zmist, string dateTime, bool tip)
        {
            
            IdUser = idUser;
            Name = name;
            Zmist = zmist;
            Date = dateTime;
            Tip = tip;

        }

        public void addd()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect))
            {
                string q = "INSERT into [Ogol]([iduser], [Name], [Zmist], [Date], [Tip]) VALUES ('" + IdUser + "','" + Name + "','" + Zmist + "','" + Date + "','" + Tip + "')";
                connection.Open();
                
                    SqlCommand comand = new SqlCommand(q, connection);

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
