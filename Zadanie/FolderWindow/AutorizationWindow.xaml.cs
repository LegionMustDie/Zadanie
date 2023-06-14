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
using Zadanie.FolderWindow.FolderWindowJury;
using Zadanie.FolderWindow.FolderWindowModerator;
using Zadanie.FolderWindow.FolderWindowOrganizator;
using Zadanie.FolderWindow.FolderWindowPlayer;

namespace Zadanie.FolderWindow
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNumber.Text))
            {
                ClassMessageBox.ErrorMB("Неверно введены логин или пароль");
            }
            else if (string.IsNullOrEmpty(pbPassword.Password))
            {
                ClassMessageBox.ErrorMB("Неверно введены логин или пароль");
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext().User_.FirstOrDefault(u=>u.IdNumber == tbNumber.Text && u.Password == pbPassword.Password);
                    if(user == null) 
                    { 
                        ClassMessageBox.ErrorMB("Неверно введены логин или пароль"); 
                    }
                    else if (pbPassword.Password != user.Password) 
                    {
                        ClassMessageBox.ErrorMB("Неверно введены логин или пароль");
                    }
                    else
                    {
                        switch(user.IdRole)
                        {
                            case 1:
                                new PlayerWindow().Show();
                                Close();
                                break;
                            case 2:
                                new ModeratorWindow().Show();
                                Close();
                                break;
                            case 3:
                                OrganizerParticipants_ organizer = DBEntities.GetContext().OrganizerParticipants_.FirstOrDefault(o => o.IdUser == user.IdUser);
                                ClassVariable.IdOrganizer = organizer.IdOrganizerParticipants;
                                new OrganizatorWindow(organizer).Show();
                                Close();
                                break;
                            case 4:
                                new JuryWindow().Show();
                                Close();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ClassMessageBox.ErrorMB(ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new WelcomeWindowSystem().Show();
            Close();
        }
    }
}
