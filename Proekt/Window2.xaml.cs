using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Proekt
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        
        public Window2()
        {
            InitializeComponent();

            
        }
        private static SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect);
        static string q = "SELECT * FROM Ogol where [iduser]= @Id ORDER BY Date DESC";
        public static SqlCommand comand = new SqlCommand(q, connection);
        static public SqlDataAdapter sda = new SqlDataAdapter(comand);
        private static DataTable dt = new DataTable("Ogol");

        //SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapterSize);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            comand.Parameters.Clear();
            comand.Parameters.AddWithValue(@"Id", id.Text);
            sda.Fill(dt);
            Gr.ItemsSource = dt.DefaultView;
            /*using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect))
            {   
    
                connection.Open();
                SqlCommand comand = new SqlCommand(q, connection);
                
                comand.ExecuteNonQuery();
                SqlDataAdapter adapterSize = new SqlDataAdapter(comand);
                recivedData = new DataSet();
                
                adapterSize.Fill(recivedData);
                adapterSize.Fill(dt);
                Gr.ItemsSource = dt.DefaultView;
                            
            }*/
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {

                connection.Open();
                
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                sda.UpdateCommand = builder.GetUpdateCommand();
                sda.Update(dt);
                connection.Close();

           /* using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect))
            {
                
                /*
                DataSet change = recivedData.GetChanges();
                if (change!=null)
                {
                    
                    recivedData.AcceptChanges();
                    adapterSize.Update(recivedData);
                }
                //adapterSize.UpdateCommand = cmdBuilder.GetUpdateCommand();               
               
             }*/
                




            
        }
        
    }
}
