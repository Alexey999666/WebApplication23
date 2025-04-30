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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            tbLogin.Focus();
            Data.Login = false;
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = APIMethod1.Get<List<User>>("api/Users").Where(user => user.UserLogin == tbLogin.Text
                && user.UserPassword == tbPass.Password).ToList();
                if (user.Count() == 1)
                {
                    Data.Login = true;
                    Data.UserSurname = user.First().UserSurname;
                    Data.UserName = user.First().UserName;
                    Data.UserPatronymic = user.First().UserPatronymic;
                    Data.Right = user.First().UserRoleNavigation.RoleName;
                    Close();
                }
                if (user.Count() == 1)
                {

                }
                else
                {
                    MessageBox.Show("Логин, пароль неверны! Повторите вход.", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            Data.Login = true;
            Data.UserSurname = "Гость";
            Data.UserName = "";
            Data.UserPatronymic = "";
            Data.Right = "Клиент";
            Close();
        }
    }
}

