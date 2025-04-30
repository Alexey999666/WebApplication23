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

namespace WpfApp23
{
    /// <summary>
    /// Логика взаимодействия для AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Window
    {
        public AddEdit()
        {
            InitializeComponent();
        }
        Plant _plant;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Data.plant == null)
            {
                addEditWindow.Title = "Добавление";
                btnAdd.Content = "Добавить";
                _plant = new Plant();
            }
            else
            {
                addEditWindow.Title = "Редактирование";
                btnAdd.Content = "Изменить";
                _plant = Data.plant;
            }
            addEditWindow.DataContext = _atelier;
        }
    }
}
