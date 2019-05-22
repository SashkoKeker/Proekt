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
        public MainWindow qq = new MainWindow();
        

        public Main()
        {
            InitializeComponent();
        }

        public string anton;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
          List<Ogolosh> l = new List<Ogolosh>();
            Ogolosh og = new Ogolosh();
           
            for (int i = 0; i < og.count; i++)
            {
                l.Add(new Ogolosh(i));
            }

            foreach (Ogolosh ogol in l)
            {
                StackPanel SP = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Background = Brushes.Black

                };
                

                Gridd.Children.Add(SP);
                TextBlock Tb1 = new TextBlock
                {
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Background = new SolidColorBrush(Color.FromArgb(0x33, 0xFA, 0xFF, 0xFF)),
                    //"33FAFFFF"
                    Foreground = Brushes.White
                };
                /*Thickness margin = Tb1.Margin;
                margin.Top = 10;
                Tb1.Margin = margin;*/
                TextBlock Tb2 = new TextBlock
                {
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Background = new SolidColorBrush(Color.FromArgb(0x33, 0xFA, 0xFF, 0xFF)),
                   //"33FAFFFF"
                   Foreground = Brushes.White
                };
                     
                    
                TextBlock Tb3 = new TextBlock
                {
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Background = new SolidColorBrush(Color.FromArgb(0x33, 0xFA, 0xFF, 0xFF)),
                    //"33FAFFFF"
                    Foreground = Brushes.White
                };
                Tb1.Width = 110;
                //Tb1.IsEnabled =  false;
                SP.Children.Add(Tb1);
                Tb1.Text = "Name: "+ ogol.IdUser;
                Tb2.Text = "Date: " + ogol.Date;
                Tb3.Text = ogol.Zmist;
                SP.Children.Add(Tb2);
                SP.Children.Add(Tb3);

            }
            
                //  b.Click.Button_Click(sender, e);
                // MessageBox.Show(Convert.ToString(bidder.bid), bidder.Name);

           
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            
            Window1 q = new Window1();
            q.IdUser.Text = Idd.Text;
            q.Show();
        }

        private void Advertisement_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Main m = new Main();
            m.Show();
        }

        private void Myadvertisement_Click(object sender, RoutedEventArgs e)
        {
            Window2 w = new Window2();
            w.id.Text = Idd.Text;
            w.Show();
        }
    }
}
