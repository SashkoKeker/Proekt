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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public MainWindow qq = new MainWindow();
        

        public Main()
        {
            InitializeComponent();
        }
        private static SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conect);
        static string q = "SELECT [Name],[Zmist],[Date] FROM [Ogol] ORDER BY Date DESC";
        public static SqlCommand comand = new SqlCommand(q, connection);
        static public SqlDataAdapter sda = new SqlDataAdapter(comand);
        private static DataTable dt = new DataTable("Ogol");
        public string anton;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            sda.Fill(dt);
            DG.ItemsSource = dt.DefaultView;

        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            
            Window1 q = new Window1();
            q.IdUser.Text = Idd.Text;
            q.Show();
        }

        private void Advertisement_Click(object sender, RoutedEventArgs e)
        {   DataTable t = new DataTable();           
            sda.Fill(dt);
            DG.ItemsSource = dt.DefaultView;
        }

        private void Myadvertisement_Click(object sender, RoutedEventArgs e)
        {
            
            Window2 w = new Window2();
            w.id.Text = Idd.Text;
            w.Show();
        }

        private void Adm_Click(object sender, RoutedEventArgs e)
        {
            ForAdmin ad = new ForAdmin();
            ad.Show();
        }
    }
}
