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

namespace remont
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        private AuthService _authService;
        private AuthorizationService _authorizationService;
        public Auth()
        {
            InitializeComponent();
            var context = new remontEntities();
            _authService = new AuthService(context);
            _authorizationService = new AuthorizationService();
        }
            private void LoginButton_Click(object sender, RoutedEventArgs e)
            {
                string login = LoginTextBox.Text;
                string password = PasswordBox.Password;

                User user = _authService.Authenticate(login, password);

                if (user != null)
                {
                    MessageBox.Show("Аутентификация успешна!");

                    

                    if (_authorizationService.Authorize(user, "Admin"))
                    {

                        MainWindow MainWindow = new MainWindow();
                        //vhod.ShowDialog();
                        MainWindow.Show();
                        this.Close();
                }
                    else if (_authorizationService.Authorize(user, "User"))
                    {
                        ForUser ForUser = new ForUser();
                        //vhod.ShowDialog();
                        ForUser.Show();
                        this.Close();
                }
                    else
                    {
                        MessageBox.Show("У вас нет доступа к этому ресурсу.");
                        
                    }
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль.");
                }
            }
        }
    }