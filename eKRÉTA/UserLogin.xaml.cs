using eKRÉTA.Models;
using System.Windows;

namespace eKRÉTA
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = loginUserText.Text;
            string passwordHash = PasswordHelper.HashPassword(loginPasswordText.Password);

            if (!string.IsNullOrEmpty(loginUserText.Text) || !string.IsNullOrEmpty(loginPasswordText.Password))
            {
                using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.databasePath))
                {
                    var user = sQLiteConnection.Table<User>().FirstOrDefault(u => u.FelhasznaloNev == username);

                    if (user != null)
                    {
                        if (user.Jelszo == (passwordHash))
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Belépés megtagadva! ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Belépés megtagadva! ");
                    }
                }
            }
            else
            {
                MessageBox.Show("Kérlek add meg a felhasználónevet és a jelszót!");
            }
        }
    }
}
