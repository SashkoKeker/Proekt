﻿using System;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        Main m = new Main();
        
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Date.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //Ogolosh o = new Ogolosh(Convert.ToInt32(m.Idd.Text),m.Name.Text);
                
        }

        
    }
}