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
    /// Логика взаимодействия для ForAdmin.xaml
    /// </summary>
    public partial class ForAdmin : Window
    {
        public ForAdmin()
        {
            InitializeComponent();
        }

        private static SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect);
        static string q = "SELECT * FROM [User]";
        static string w = "SELECT * FROM [Ogol] ORDER BY Date DESC";
        public static SqlCommand comand = new SqlCommand(q, connection);
        public static SqlCommand comand1 = new SqlCommand(w, connection);
        static public SqlDataAdapter sda = new SqlDataAdapter(comand);
        static public SqlDataAdapter sda1 = new SqlDataAdapter(comand1);

        private static DataTable dt = new DataTable("User");
        private static DataTable dt1 = new DataTable("Ogol");

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
    
            sda.Fill(dt);
            GrUser.ItemsSource = dt.DefaultView;
            sda1.Fill(dt1);
            GrOgol.ItemsSource = dt1.DefaultView;
           
        }

        private void SaveAdd_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = dt.NewRow(); // добавляем новую строку в DataTable
            dt.Rows.Add(row);
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();

            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            sda.UpdateCommand = builder.GetUpdateCommand();
            sda.Update(dt);
            connection.Close();
        }

        private void OgolAdd_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = dt1.NewRow(); // добавляем новую строку в DataTable
            dt1.Rows.Add(row);
        }

        private void SaveOgol_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();

            SqlCommandBuilder builder = new SqlCommandBuilder(sda1);
            sda1.UpdateCommand = builder.GetUpdateCommand();
            sda1.Update(dt1);
            connection.Close();
        }
    }
    
}
