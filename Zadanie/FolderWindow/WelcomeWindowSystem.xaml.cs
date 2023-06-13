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
        }

        private void btnAutorization_Click(object sender, RoutedEventArgs e)
        {
            new AutorizationWindow().Show();
            Close();
        }
    }
}
