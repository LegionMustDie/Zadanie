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
using Zadanie.FolderData;

namespace Zadanie.FolderWindow.FolderWindowOrganizator
{
    /// <summary>
    /// Логика взаимодействия для OrganizatorWindow.xaml
    /// </summary>
    public partial class OrganizatorWindow : Window
    {
        private OrganizerParticipants_ organizer;
        public OrganizatorWindow(OrganizerParticipants_ organizer)
        {
            InitializeComponent();
            this.organizer = organizer;
            btnAddPhoto.Content = ClassImage.ConvertArrayToImage(organizer.Photo);
            WelcomeMessage();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new AutorizationWindow().Show();
            Close();
        }



        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {
            //Просто MessageBox
        }

        private void btnPlayers_Click(object sender, RoutedEventArgs e)
        {
            //Просто MessageBox
        }

        private void btnJury_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationJuryWindow().Show();
            Close();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            //Просто MessageBox
        }

        /// <summary>
        /// Метод, который определяет время и выводит соответствующее сообщение
        /// </summary>
        private void WelcomeMessage()
        {
            var currentTimeinHours = DateTime.Now.Hour;
            string organizerName = $"{organizer.FirstName} {organizer.MiddleName}";
            string welcomeMessage = "";
            if (currentTimeinHours >= 9 && currentTimeinHours <= 11)
            {
                welcomeMessage = "Доброе утро!\n" + organizerName;
            }
            else if (currentTimeinHours > 11 && currentTimeinHours <= 18)
            {
                welcomeMessage = "Добрый день!\n" + organizerName;
            }
            else if (currentTimeinHours > 18 && currentTimeinHours <= 23)
            {
                welcomeMessage = "Добрый вечер!\n" + organizerName;
            }

            lbWelcomeUser.Content = welcomeMessage;
        }
    }
}
