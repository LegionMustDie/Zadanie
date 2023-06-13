using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Zadanie.FolderClass
{
    internal class ClassMessageBox
    {

        /// <summary>
        /// Информационное сообщение
        /// </summary>
        /// <param name="message"> Входная информация </param>
        public static void InfoMB(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        /// <param name="message"> Входная ошибка </param>
        public static void ErrorMB(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Сообщение с вопросом
        /// </summary>
        /// <param name="message"> Входной вопрос </param>
        /// <returns></returns>
        public static bool QuestionMB(string message)
        {
          return MessageBoxResult.Yes == MessageBox.Show(message, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        /// <summary>
        /// Вопрос об выходе из программы
        /// </summary>
        public static void ExitMB()
        {
            if(QuestionMB("Exit?"))
                App.Current.Shutdown();
        }
    }
}
