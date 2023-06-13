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
using Zadanie.FolderClass;

namespace Zadanie.FolderWindow.FolderWindowOrganizator
{
    /// <summary>
    /// Логика взаимодействия для OrganizatorWindow.xaml
    /// </summary>
    public partial class OrganizatorWindow : Window
    {
        public OrganizatorWindow()
        {
            InitializeComponent();
            WelcomeMessage();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new AutorizationWindow().Show();
            Close();
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlayers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnJury_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Метод, который определяет время и выводит соответствующее сообщение
        /// </summary>
        private void WelcomeMessage()
        {
            var currentTimeinHours = DateTime.Now.Hour;
            if (currentTimeinHours >= 9 && currentTimeinHours <= 11)
            {
                lbWelcomeUser.Content = "Доброе утро!";
            }
            else if (currentTimeinHours > 11 && currentTimeinHours <= 18)
            {
                lbWelcomeUser.Content = "Добрый день!";
            }
            else if (currentTimeinHours > 18 && currentTimeinHours <= 23)
            {
                lbWelcomeUser.Content = "Добрый вечер!";
            }
        }
    }
}
