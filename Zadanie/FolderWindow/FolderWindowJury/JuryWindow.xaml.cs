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

namespace Zadanie.FolderWindow.FolderWindowJury
{
    /// <summary>
    /// Логика взаимодействия для JuryWindow.xaml
    /// </summary>
    public partial class JuryWindow : Window
    {
        public JuryWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new AutorizationWindow().Show();
            Close();
        }
    }
}