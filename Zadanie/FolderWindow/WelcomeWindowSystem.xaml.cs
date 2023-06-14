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

namespace Zadanie.FolderWindow
{
    /// <summary>
    /// Логика взаимодействия для WelcomeWindowSystem.xaml
    /// </summary>
    public partial class WelcomeWindowSystem : Window
    {
        public WelcomeWindowSystem()
        {
            InitializeComponent();
            cbWay.ItemsSource = DBEntities.GetContext().Directory_.ToList();
            lvEventList.ItemsSource = DBEntities.GetContext().ActionPlan_.ToList();
        }

        private void btnAutorization_Click(object sender, RoutedEventArgs e)
        {
            new AutorizationWindow().Show();
            Close();
        }

        private void cbWay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbWay.SelectedItem is Directory_ directory)
            {
                lvEventList.ItemsSource = DBEntities.GetContext().ActionPlan_.Where(a => a.Event_.IdDirectory == directory.IdDirectory).ToList();
                if (lvEventList.Items.Count <= 0)
                {
                    ClassMessageBox.ErrorMB("Нет мероприятий");
                    lvEventList.ItemsSource = DBEntities.GetContext().ActionPlan_.ToList();
                }
            }
        }

        private void dpDateEvent_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lvEventList.ItemsSource = DBEntities.GetContext().ActionPlan_.Where(a => a.Date == dpDateEvent.SelectedDate).ToList();
            if (lvEventList.Items.Count <= 0)
            {
                ClassMessageBox.ErrorMB("Нет мероприятий");
                lvEventList.ItemsSource = DBEntities.GetContext().ActionPlan_.ToList();
            }
        }
    }
}
