using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Андрианов Алексей Вариант 14\n Вариант 13 WEB API", "Информация", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Data.plant = null;
            AddEdit f = new AddEdit();
            f.Owner = this;
            f.ShowDialog();
            loadDB();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                Data.plant = (Plant)listView.SelectedItem;
                AddEdit f = new AddEdit();
                f.Owner = this;
                f.ShowDialog();
                loadDB();
            }
        }
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Plant row = (Plant)listView.SelectedItem;
                    String value = row.Название;
                    if (row != null)
                    {
                        APIMethod1.Delete(row.Код, "api/Plants");
                        loadDB();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else
            {
                listView.Focus();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadDB();
        }

        void loadDB()
        {
            int selectedIndex = listView.SelectedIndex;
            try
            {
                listView.ItemsSource = APIMethod1.Get<List<Plant>>("api/Plants");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            if (selectedIndex != -1)
            {
                if (selectedIndex >= listView.Items.Count) selectedIndex--;
                listView.SelectedIndex = selectedIndex;
                listView.ScrollIntoView(listView.SelectedItem);
            }
            listView.Focus();
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            Login f = new Login();
            f.ShowDialog();

            if (Data.Login == false) Close();
            if (Data.Right == "Администратор") ;
            else
            {
                btnDelete.IsEnabled = false;
                btnAdd.IsEnabled = false;
                btnEdit.IsEnabled = false;
            }

            mainWindow.Title = mainWindow.Title + " " + Data.UserSurname +
                " " + Data.UserName + " (" + Data.Right + ")";
        }
    }
}