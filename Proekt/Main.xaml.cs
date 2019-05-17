using System;
using System.Collections.Generic;
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

        public double Move;
        public double chek;

        public bool ch = true;

        public Main()
        {
            InitializeComponent();
        }



        

        public string anton;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           // List<Ogolosh> l = new List<Ogolosh>();
            
            
            StackPanel SP = new StackPanel();
            SP.Orientation = Orientation.Horizontal;
            Gridd.Children.Add(SP);
            TextBox Tb1 = new TextBox();
            TextBox Tb2 = new TextBox();
            Tb1.Width = 150;
            
            
            
            SP.Children.Add(Tb1);
            Tb1.Text = "Name: " + anton;
            Tb2.Text = "Bid: " + anton + "$";
            SP.Children.Add(Tb2);
            
           
            
            //  b.Click.Button_Click(sender, e);
            // MessageBox.Show(Convert.ToString(bidder.bid), bidder.Name);
        }

        private void LoginB_Click(object sender, RoutedEventArgs e)
        {
            Window1 q = new Window1();
            q.Show();
        }
    }
}
