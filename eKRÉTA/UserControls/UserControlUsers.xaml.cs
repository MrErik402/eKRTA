using eKRÉTA.Models;
using System.Windows;
using System.Windows.Controls;

namespace eKRÉTA.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlUsers.xaml
    /// </summary>
    public partial class UserControlUsers : UserControl
    {
        List<User> users;
        User selectedUser;
        public UserControlUsers()
        {
            InitializeComponent();
            users = new List<User>();
            ReadDatabase();
            saveBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void ReadDatabase()
        {
            fullnameTextBox.Text = "";
            usernameTextBox.Text = "";
            //NEW!
            passwordBox.Password = "";


            //Generic Repo használata
            var UserRepo = new GenericRepository<User>(App.databasePath);
            var query = UserRepo.GetAll();
            datagridUsers.ItemsSource = query;

            //Régi kód

            /*using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.databasePath))
            {
                sQLiteConnection.CreateTable<User>();
                var query = sQLiteConnection.Table<User>().ToList();
                if (query != null)
                {
                    datagridUsers.ItemsSource = query;
                }
            }*/

            saveBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            //MODIFIED
            User user = new User(usernameTextBox.Text, fullnameTextBox.Text, PasswordHelper.HashPassword(passwordBox.Password));

            //User user = new User()
            //{
            //    FelhasznaloNev = usernameTextBox.Text,
            //    TeljesNev = fullnameTextBox.Text
            //};


            
            var UserRepo = new GenericRepository<User>(App.databasePath);
            UserRepo.insert(user);
            ReadDatabase();


            //Régi kód
            /* using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.databasePath))
             {
                 sQLiteConnection.CreateTable<User>();
                 sQLiteConnection.Insert(user);
             }
             ReadDatabase();*/
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var UserRepo = new GenericRepository<User>(App.databasePath);
            UserRepo.delete(selectedUser);
            ReadDatabase();

            //Régi kód
            /*using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.databasePath))
            {
                sQLiteConnection.CreateTable<User>();
                sQLiteConnection.Delete(selectedUser);
            }
            */

        }

        private void datagridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            saveBtn.Visibility = Visibility.Collapsed;
            modBtn.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;

            if (datagridUsers.SelectedItem != null)
            {
                selectedUser = (User)datagridUsers.SelectedItem;
                fullnameTextBox.Text = selectedUser.TeljesNev;
                usernameTextBox.Text = selectedUser.FelhasznaloNev;
            }
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedUser.FelhasznaloNev = usernameTextBox.Text;
            selectedUser.TeljesNev = fullnameTextBox.Text;

            // NEW!
            if (passwordBox.Password != "")
            {
                selectedUser.Jelszo = PasswordHelper.HashPassword(passwordBox.Password);
            }


            var UserRepo = new GenericRepository<User>(App.databasePath);
            UserRepo.update(selectedUser);
            ReadDatabase();

            //Régi kód

            /*using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.databasePath))
            {
                sQLiteConnection.CreateTable<User>();
                sQLiteConnection.Update(selectedUser);
            }

            ReadDatabase();*/

        }


    }
}
