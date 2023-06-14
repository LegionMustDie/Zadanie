using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using Zadanie.FolderWindow.FolderWindowModerator;

namespace Zadanie.FolderWindow.FolderWindowOrganizator
{
    /// <summary>
    /// Логика взаимодействия для RegistrationJuryWindow.xaml
    /// </summary>
    public partial class RegistrationJuryWindow : Window
    {
        private JuryAndModerator_ moderator_ = new JuryAndModerator_();
        private User_ user_ = new User_();

        public RegistrationJuryWindow()
        {
            InitializeComponent();
            LoadComboBox();
            GenerateIdNumber();
        }

        /// <summary>
        /// Метод загрузки данных из базы данных в выпадающие списки
        /// </summary>
        private void LoadComboBox()
        {
            DirectionCb.ItemsSource = DBEntities.GetContext().Directory_.ToList();
            EventCb.ItemsSource = DBEntities.GetContext().Event_.ToList();
            MaleCb.ItemsSource = DBEntities.GetContext().Gender_.ToList();
            RoleCb.ItemsSource = DBEntities.GetContext().Role_.ToList();
        }


        /// <summary>
        /// Метод для генерации идентификатора для жюри/модератора
        /// </summary>
        private void GenerateIdNumber()
        {
            int lastId = DBEntities.GetContext().JuryAndModerator_.Max(j => j.IdJuryAndModerator);
            int currentId = lastId++;
            IdTb.Text = currentId.ToString();
        }

        private void PinToEventChb_Checked(object sender, RoutedEventArgs e)
        {
            EventCb.IsEnabled = true;
        }

        private void PinToEventChb_Unchecked(object sender, RoutedEventArgs e)
        {
            EventCb.IsEnabled = false;
        }

        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "";
            openFileDialog.Filter = "All suported graphics |*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                // moderator_.Image = ClassImage.ConvertImageToByteArray(openFileDialog.FileName);
                // AddPhotoBtn.Content = ClassImage.ConvertByteArrayToImage(moderator_.Image);
            }
        }

        private void EnablePasswordChb_Checked(object sender, RoutedEventArgs e)
        {
            PasswordRepeatTb.Text = PasswordRepeatPb.Password;
            PasswordRepeatTb.Visibility = Visibility.Visible;
            PasswordRepeatPb.Visibility = Visibility.Hidden;
        }

        private void EnablePasswordChb_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordRepeatTb.Visibility = Visibility.Hidden;
            PasswordRepeatPb.Visibility = Visibility.Visible;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ClassValidator.ValidateInput(EmailTb, FIOTb, PhoneTb))
                return;
            else if (!ClassValidator.ValidateComboBox(MaleCb, RoleCb, DirectionCb))
                return;
            else
            {
                string alphapet = "qwertyuiopasdfghjklzxcvbnm";
                string upperAlphabet = alphapet.ToUpper();
                string nums = "1234567890";
                string symbols = "!@#$%^&*()_-+=";
                if (PasswordPb.Password != PasswordRepeatPb.Password)
                {
                    ClassMessageBox.ErrorMB("Пароли не совпадают!");
                }
                else if (PasswordPb.Password.Length < 6)
                {
                    ClassMessageBox.ErrorMB("Пароль должен быть больше 6 символов!");
                }
                else if (!PasswordPb.Password.Any(alphapet.Contains))
                {
                    ClassMessageBox.ErrorMB("Пароль должен содержать буквы!");
                }
                else if (!PasswordPb.Password.Any(upperAlphabet.Contains))
                {
                    ClassMessageBox.ErrorMB("Пароль должен содержать заглавные буквы!");
                }
                else if (!PasswordPb.Password.Any(nums.Contains))
                {
                    ClassMessageBox.ErrorMB("Пароль должен содержать цифры!");
                }
                else if (!PasswordPb.Password.Any(symbols.Contains))
                {
                    ClassMessageBox.ErrorMB("Пароль должен содержать символы!");
                }
                else if (EventCb.IsEditable && EventCb.SelectedItem == null)
                {
                    ClassMessageBox.ErrorMB("Вы не выбрали мероприятие!");
                }
                else if (!EmailTb.Text.Contains('@') && !EmailTb.Text.Contains('.'))
                {
                    ClassMessageBox.ErrorMB("Почта должна содержать знаки @ и . !");
                }
                else
                {
                    try
                    {
                        AddUser();
                        AddJuryAndModerator();
                        ClassMessageBox.InfoMB("Добавление успешно!");
                    }
                    catch (Exception ex)
                    {
                        ClassMessageBox.ErrorMB("Ошибка базы данных: " + ex.Message);
                    }

                }

            }
        }


        /// <summary>
        /// Метод добавления жюри/модератора в базу данных
        /// </summary>
        private void AddJuryAndModerator()
        {
            string[] fio = FIOTb.Text.Split(' ');
            if (fio.Length < 2)
            {
                ClassMessageBox.ErrorMB("Вы не ввели имя или фамилию!");
                FIOTb.Focus();
                return;
            }
            moderator_.LastName = fio[0];
            moderator_.FirstName = fio[1];
            moderator_.MiddleName = fio[2];
            moderator_.IdGender = int.Parse(MaleCb.SelectedValue.ToString());
            moderator_.IdUser = user_.IdUser;
            moderator_.Email = EmailTb.Text;
            moderator_.Phone = PhoneTb.Text;
            moderator_.IdDirectory = int.Parse(DirectionCb.SelectedValue.ToString());
            moderator_.IdEvent = int.Parse(EventCb.SelectedValue.ToString() ?? null);
            DBEntities.GetContext().JuryAndModerator_.Add(moderator_);
            DBEntities.GetContext().SaveChanges();
        }

        /// <summary>
        /// Метод добавления пользователя в базу данных
        /// </summary>
        private void AddUser()
        {
            user_.IdNumber = IdTb.Text;
            user_.Password = PasswordPb.Password;
            user_.IdRole = int.Parse(RoleCb.SelectedValue.ToString());
            DBEntities.GetContext().User_.Add(user_);
            DBEntities.GetContext().SaveChanges();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var organizer = DBEntities.GetContext().OrganizerParticipants_.FirstOrDefault
                (o => o.IdOrganizerParticipants == ClassVariable.IdOrganizer);
            new OrganizatorWindow(organizer).Show();
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClassMessageBox.QuestionMB("Отменить добавление?"))
            {
                new ModeratorWindow().Show();
                Close();
            }
        }
    }
}
