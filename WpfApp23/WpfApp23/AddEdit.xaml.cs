using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            addEditWindow.DataContext = _plant;
        }
        private void btnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            

            if (Data.plant == null && (!int.TryParse(tbCod.Text, out int cod) || cod <= 0))
            {
                errors.AppendLine("Ошибка в коде");
            }

            
            if (string.IsNullOrWhiteSpace(tbName.Text))
                errors.AppendLine("Введите название");

            if (string.IsNullOrWhiteSpace(tbSem.Text))
                errors.AppendLine("Введите семейство");

            if (string.IsNullOrWhiteSpace(tbRaz.Text) )
            {
                errors.AppendLine("Введите раздел");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (Data.plant == null)
                {
                  
                    var allAteliers = APIMethod1.Get<List<Plant>>("api/PlantsController1");
                    if (allAteliers.Any(a => a.Код == _plant.Код))
                    {
                        MessageBox.Show("Растение с таким кодом уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    APIMethod1.Post(_plant, "api/PlantsController1");
                }
                else
                {
                    APIMethod1.Put(_plant, _plant.Код, "api/PlantsController1");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
