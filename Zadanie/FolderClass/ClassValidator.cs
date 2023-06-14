using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Zadanie.FolderClass
{
    internal class ClassValidator
    {
        /// <summary>
        /// Проверка всех строк на то, что они не пустые
        /// </summary>
        /// <param name="inputs">Массив строк</param>
        /// <returns></returns>
        public static bool ValidateInput(params TextBox[] inputs)
        {
            foreach (var item in inputs)
            {
                if (string.IsNullOrEmpty(item.Text))
                {
                    ClassMessageBox.ErrorMB("Поле не должно быть пустым");
                    item.Focus();
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Проверка всех переданных ComboBox'ов, что у ниж имеется выбранный элемент
        /// </summary>
        /// <param name="inputs">Массив ComboBox</param>
        /// <returns></returns>
        public static bool ValidateComboBox(params ComboBox[] inputs)
        {
            foreach (var item in inputs)
            {
                if (item.SelectedItem == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
