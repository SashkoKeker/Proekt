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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proekt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        User u;
        public MainWindow()
        {
            InitializeComponent();
        }



         
        

        private void LoginB_Click(object sender, RoutedEventArgs e)
        {
            u = new User(Login.Text, Pass.Text);
        }

        private void RegB_Click(object sender, RoutedEventArgs e)
        {
            Registration f = new Registration();
            f.Show();
        }
    }
}
